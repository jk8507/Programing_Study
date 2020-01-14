using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public int TargetHitCount;
    public int currentHitCount;
    private BoxCollider2D mCollider;
    private GameController mGameController;

    // Start is called before the first frame update
    void Start()
    {
        currentHitCount = 0;
        mCollider = GetComponent<BoxCollider2D>(); // 소문자 gameObject가 숨어져 있는 것, gameObject는 이 스크립트가 붙어있는 오브젝트를 의미.
        GameObject obj = GameObject.FindGameObjectWithTag("GameController");
        mGameController = obj.GetComponent<GameController>();
    }

    public void Hit(int value)
    {
        Debug.Log(value);
        currentHitCount++;
        if (currentHitCount == TargetHitCount)
        {
            StartCoroutine(CheckUP());
        }
    }

    private IEnumerator CheckUP()
    {
        yield return new WaitForSeconds(5);
        if(currentHitCount == TargetHitCount)
        {
            mGameController.AddStageNumber();
            mCollider.enabled = false;
        }
    }
}
