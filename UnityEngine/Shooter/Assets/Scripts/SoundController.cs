using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eEffectSoundType
{
    ExpAst,
    ExpEnemy,
    ExpPlayer,
    FireEnemy,
    FirePlayer
}

public class SoundController : MonoBehaviour
{
    public AudioClip[] EffectSoundArr;
    public AudioClip[] BGMArr;

    public AudioSource BGMSource;
    public AudioSource EffectSource;

    // Start is called before the first frame update
    void Start()
    {
        /*BGMSource.clip = BGMArr[0];
        BGMSource.Play(); // play on awake가 꺼져있을 때 사운드 실행 시키는 법 */
    }

    public void PlayEffectSound(int effectSoundID)
    {
        EffectSource.PlayOneShot(EffectSoundArr[effectSoundID]);
        //AudioSource.PlayClipAtPoint(EffectSoundArr[effectSoundID], transform.position); //hierachy에 생성했다 제거하는 역할 destroy를 실행하므로 조작을 못한다. 그러므로 성능상에 문제가 생기므로 쓰지말것.

    }
}
