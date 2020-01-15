using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody mRB;

    public Bomb bomb;

    public Transform BoltPos;
    public BoltPool boltpool;

    public float Speed;
    public float Tilt;

    public float MinX;
    public float MaxX;
    public float MinZ;
    public float MaxZ;

    public float FireRate;
    private float currentFireTimer;

    public GameObject ChargingObj;
    public float ChargeMaxValue;
    private float currentChargeValue;

    private EffectPool effect;
    private GameController gameController;
    private SoundController soundController;
  
    void Start()
    {
        currentChargeValue = 0;
        currentFireTimer = 0;
        mRB = GetComponent<Rigidbody>();
        GameObject effectObj = GameObject.FindGameObjectWithTag("EffectPool");
        effect = effectObj.GetComponent<EffectPool>();
        GameObject control = GameObject.FindGameObjectWithTag("GameController");
        gameController = control.GetComponent<GameController>();
        soundController = gameController.GetSoundController();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 velocity = new Vector3(horizontal * Speed, 0, vertical * Speed);
        mRB.velocity = velocity;

        transform.rotation = Quaternion.Euler(0, 0, horizontal * -Tilt);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, MinX, MaxX), 0, Mathf.Clamp(transform.position.z, MinZ, MaxZ));
        currentFireTimer -= Time.deltaTime;

        if (Input.GetButton("Fire3"))
        {
            ChargingObj.SetActive(true);
            currentChargeValue += Time.deltaTime;
        }
        else if(Input.GetButtonUp("Fire3"))
        {
            if(currentChargeValue >= ChargeMaxValue)
            {
                StartCoroutine(ChargingFire(20));
            }
            currentChargeValue = 0;
            ChargingObj.SetActive(false);
        }
        else if (Input.GetButton("Fire1") && currentFireTimer <= 0)
        {
            Bolt newBolt = boltpool.GetFromPool(); //instantiate는 인스턴스 생성이라는 의미를 가진다.(계층란에 새로운 으브젝트를 복제하여 만듬)
            newBolt.transform.position = BoltPos.position; //그냥 position은 월드 포지션이고 localPosition이 유니티에서 보이는 포지션이다.
            currentFireTimer = FireRate;
            soundController.PlayEffectSound((int)eEffectSoundType.FirePlayer);
        }

        if(Input.GetButton("Fire2") && !bomb.gameObject.activeInHierarchy)
        {
            bomb.transform.position = BoltPos.position;
            bomb.gameObject.SetActive(true);
        }
    }

    private IEnumerator ChargingFire(int boltCount)
    {
        int count = boltCount;
        while(count> 0)
        {
            Bolt newBolt = boltpool.GetFromPool();
            newBolt.transform.position = BoltPos.position;
            soundController.PlayEffectSound((int)eEffectSoundType.FirePlayer);
            count--;
            yield return new WaitForFixedUpdate();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        Timer newEffect = effect.GetFromPool((int)eEffectType.PlayerExp);
        newEffect.transform.position = transform.position;
        soundController.PlayEffectSound((int)eEffectSoundType.ExpPlayer);
        gameController.GameOver();
    }
}