using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    private Rigidbody mRB;
    public float Speed;
    private EffectPool effect;
    private GameController gameController;
    private SoundController soundController;

    private void Awake()
    {
        mRB = GetComponent<Rigidbody>();
        mRB.velocity = Vector3.back * Speed;
        GameObject effectObj = GameObject.FindGameObjectWithTag("EffectPool");
        effect = effectObj.GetComponent<EffectPool>();
        GameObject controller = GameObject.FindGameObjectWithTag("GameController");
        gameController = controller.GetComponent<GameController>();
        soundController = gameController.GetSoundController();
        //Random.Range(3.0f, 6.0f) - 랜덤 스피는 주는 방법 (인트형이랑 플롯형 2가지가 있으며 random.randomrange는 구버전의 라이브러리로 지금은 안씀
    } // unity execution order를  구글에 치면 관련 정보를 얻을 수 있다.

    private void OnEnable()
    {
        mRB.angularVelocity = Random.insideUnitSphere * 3;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void EnterBomb(float damage)
    {
        Hit();
    }

    private void Hit()
    {
        gameController.AddScore(1);
        Timer newEffect = effect.GetFromPool((int)eEffectType.AsteroidExp);
        newEffect.transform.position = transform.position;
        soundController.PlayEffectSound((int)eEffectSoundType.ExpAst);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Bolt") || 
           other.gameObject.CompareTag("Player"))
        {
            Hit();
            other.gameObject.SetActive(false);
        }
    }
}
