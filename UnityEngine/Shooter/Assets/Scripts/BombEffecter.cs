using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEffecter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy")) ;
        {
            other.SendMessage("EnterBomb", 5, SendMessageOptions.DontRequireReceiver); // 굉장히 무거운 기능 해당 태그의 모든 오브젝트에게 메세지를 송신하여 필요한 부분을 찾아내므로
            
        }
    }
}
