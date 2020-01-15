using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Rigidbody mRB;
    public GameObject Effect;
    public float Speed;
    private SoundController mSoundcontroller;

    private void Awake()
    {
        mRB = GetComponent<Rigidbody>();
        mSoundcontroller = GameObject.FindGameObjectWithTag("GameController").
                           GetComponent<GameController>().
                           GetSoundController();
    }

    private void OnEnable()
    {
        mRB.velocity = transform.forward * Speed;
    }

    private void OnDisable()
    {
        Effect.transform.position = transform.position;
        Effect.SetActive(true);
        mSoundcontroller.PlayEffectSound((int)eEffectSoundType.ExpPlayer);
    }
}
