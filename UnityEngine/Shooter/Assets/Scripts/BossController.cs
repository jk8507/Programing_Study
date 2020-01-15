using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private Rigidbody mRB;
    public BoltPool boltPool;
    public Transform FirePos;
    public Vector3 OriginalPos;
    public float Speed;
    public float BossPhaseZPos;
    private GameController gameController;
    private SoundController soundController;
    public int MaxHP;
    private int CurrentHP;
    private bool mbInvincible;
    private EffectPool effect;

    private void Awake()
    {
        mRB = GetComponent<Rigidbody>();
        GameObject controlObj = GameObject.FindGameObjectWithTag("GameController");
        gameController = controlObj.GetComponent<GameController>();
        soundController = gameController.GetSoundController();
        GameObject effectObj = GameObject.FindGameObjectWithTag("EffectPool");
        effect = effectObj.GetComponent<EffectPool>();
    }

    private void OnEnable()
    {
        transform.position = OriginalPos;
        StartCoroutine(BossMovement());
        CurrentHP = MaxHP;
        mbInvincible = true;
    }

    private IEnumerator AutoFire(float time)
    {
        while(time > 0)
        {
            Bolt newBolt = boltPool.GetFromPool();
            newBolt.transform.position = FirePos.position;
            soundController.PlayEffectSound((int)eEffectSoundType.FireEnemy);
            time -= 0.3f;
            yield return new WaitForSeconds(0.3f);
        }
    }

    private IEnumerator BossMovement()
    {
        mRB.velocity = Vector3.back * Speed;
        while(transform.position.z > BossPhaseZPos)
        {
            yield return new WaitForSeconds(0.3f);
        }
        mRB.velocity = Vector3.zero;

        while(true)
        {
            mRB.velocity = Vector3.left * Speed;
            StartCoroutine(AutoFire(2.2f));
            yield return new WaitForSeconds(2);

            mRB.velocity = Vector3.zero;
            yield return new WaitForSeconds(0.5f);

            mRB.velocity = Vector3.right * Speed;
            StartCoroutine(AutoFire(4.2f));
            yield return new WaitForSeconds(4);

            mRB.velocity = Vector3.zero;
            yield return new WaitForSeconds(0.5f);

            mRB.velocity = Vector3.left * Speed;
            StartCoroutine(AutoFire(2.2f));
            yield return new WaitForSeconds(2);

            mRB.velocity = Vector3.zero;
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void Hit(int damage)
    {
        if (mbInvincible)
        {
            return;
        }

        CurrentHP -= damage;
        Debug.Log(CurrentHP);
        if (CurrentHP <= 0)
        {
            gameController.AddScore(100);
            gameController.ClearBoss();
            Timer newEffect = effect.GetFromPool((int)eEffectType.EnemyExp);
            newEffect.transform.position = transform.position;
            soundController.PlayEffectSound((int)eEffectSoundType.ExpEnemy);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bolt") ||
           other.gameObject.CompareTag("Player"))
        {
            Hit(1);
            other.gameObject.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
