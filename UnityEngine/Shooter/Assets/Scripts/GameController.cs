using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public SoundController soundControl;
    public UIController UIControl;

    public BGScroller[] BGArr;
    public float BGScrollSpeed;

    public Player player;
    private bool mbGameOver;

    private bool mbBossAlive;
    public BossController boss;
    public EnemyPool enemyPool;
    public AsteroidPool asteroidPool;
    public float SpawnZPos;
    public float SpawnXMax;
    public float SpawnXMin;
    public int AstSpawnCount;
    public int EnemySpawnCount;
    private int mScore;
    private Coroutine hazardRoutine;

    // Start is called before the first frame update
    void Start()
    {
        mScore = 0;
        hazardRoutine = StartCoroutine(SpawnHazard());

        for(int i = 0; i  < BGArr.Length; i++)
        {
            BGArr[i].SetSpeed(BGScrollSpeed);
        }

        mbGameOver = false;
        UIControl.ShowStatus("");
        UIControl.ShowScore(mScore);
    }

    public SoundController GetSoundController()
    {
        return soundControl;
    }

    public void AddScore(int amount)
    {
        mScore += amount;
        UIControl.ShowScore(mScore);
    }

    public void GameOver()
    {
        UIControl.ShowStatus("Game Over...");
        for (int i = 0; i < BGArr.Length; i++)
        {
            BGArr[i].SetSpeed(0);
        }
        StopCoroutine(hazardRoutine);
        mbGameOver = true;
    }

    public void RestartGame()
    {
        UIControl.ShowStatus("");
        mScore = 0;
        UIControl.ShowScore(mScore);
        for (int i = 0; i < BGArr.Length; i++)
        {
            BGArr[i].SetSpeed(BGScrollSpeed);
        }

        hazardRoutine = StartCoroutine(SpawnHazard());
        player.transform.position = Vector3.zero;
        player.gameObject.SetActive(true);
        mbGameOver = false;
    }
    private IEnumerator SpawnHazard()
    {
        int currentAstCount = AstSpawnCount;
        int currentEnemyCount = EnemySpawnCount;
       

        yield return new WaitForSeconds(3); // 괄호안에 지정된 숫자 만큼 대기 후 실행

        while (true)
        {
            if (currentAstCount > 0 && currentEnemyCount > 0)
            {
                float randVal = Random.Range(0, 100f);
                if (randVal < 30) // enemy spawn
                {
                    EnemyController enemy = enemyPool.GetFromPool();
                    enemy.transform.position = new Vector3(Random.Range(SpawnXMin, SpawnXMax), 0, SpawnZPos);
                    yield return new WaitForSeconds(.4f);
                    currentEnemyCount--;
                }
                else // asteroid spawn
                {
                    AsteroidMovement ast = asteroidPool.GetFromPool(Random.Range(0, 3));
                    ast.transform.position = new Vector3(Random.Range(SpawnXMin, SpawnXMax), 0, SpawnZPos);
                    yield return new WaitForSeconds(.4f);
                    currentAstCount--; 
                }
            }
            else if (currentAstCount > 0)
            {
                for (int i = 0; i < currentAstCount; i++)
                {
                    AsteroidMovement ast = asteroidPool.GetFromPool(Random.Range(0, 3));
                    ast.transform.position = new Vector3(Random.Range(SpawnXMin, SpawnXMax), 0, SpawnZPos);
                    yield return new WaitForSeconds(.4f);
                }

                currentAstCount = 0;
            }
            else if (currentEnemyCount > 0)
            {
                for (int i = 0; i < currentEnemyCount; i++)
                {
                    EnemyController enemy = enemyPool.GetFromPool();
                    enemy.transform.position = new Vector3(Random.Range(SpawnXMin, SpawnXMax), 0, SpawnZPos);
                    yield return new WaitForSeconds(.4f);
                }

                currentEnemyCount = 0;
            }
            else
            {
                mbBossAlive = true;
                boss.gameObject.SetActive(true);
                while(mbBossAlive)
                {
                    yield return new WaitForSeconds(0.5f);
                }
                currentAstCount = AstSpawnCount;
                currentEnemyCount = EnemySpawnCount;
                yield return new WaitForSeconds(3); // 괄호안에 지정된 숫자 만큼 대기 후 실행
            }
        }
    }

    public void ClearBoss()
    {
        mbBossAlive = false; 
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && mbGameOver)
        {
            RestartGame();
        }
    }
}
