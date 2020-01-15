using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameArea : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        //Destroy(other.gameObject); destroy를 쓰면 언어 특징으로 인해 가비지 콜렉터가 발동하여 프레임 드랍이 일어날수 있어서 사용을 잘 하지 않음
        other.gameObject.SetActive(false);
    }
}
