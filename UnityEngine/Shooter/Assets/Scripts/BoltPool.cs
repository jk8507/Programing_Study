using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltPool : MonoBehaviour
{
    public Bolt Prefab;
    private List<Bolt> Pool;

    // Start is called before the first frame update
    void Start()
    {
        Pool = new List<Bolt>();
    }

    public Bolt GetFromPool()
    {
        for(int i = 0; i < Pool.Count; i++)
        {
            if(!Pool[i].gameObject.activeInHierarchy)
            {
                Pool[i].gameObject.SetActive(true);
                return Pool[i];
            }
        }

        Bolt newObj = Instantiate(Prefab); //instantiate는 인스턴스 생성이라는 의미를 가진다.(계층란에 새로운 으브젝트를 복제하여 만듬)
        Pool.Add(newObj);
        return newObj;
    }
}
