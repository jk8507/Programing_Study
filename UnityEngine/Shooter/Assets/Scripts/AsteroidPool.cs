using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidPool : MonoBehaviour
{
    public AsteroidMovement[] Prefabs;
    private List<AsteroidMovement>[] Pools;

    // Start is called before the first frame update
    void Start()
    {

        Pools = new List<AsteroidMovement>[Prefabs.Length];
        for(int i = 0; i < Pools.Length; i++)
        {
            Pools[i] = new List<AsteroidMovement>();
        }
        //new List<AsteroidMovement>();
    }

    public AsteroidMovement GetFromPool(int id)
    {
        for (int i = 0; i < Pools[id].Count; i++)
        {
            if (!Pools[id][i].gameObject.activeInHierarchy)
            {
                Pools[id][i].gameObject.SetActive(true);
                return Pools[id][i];
            }
        }

        AsteroidMovement newObj = Instantiate(Prefabs[id]); //instantiate는 인스턴스 생성이라는 의미를 가진다.(계층란에 새로운 으브젝트를 복제하여 만듬)
        Pools[id].Add(newObj);
        return newObj;
    }
}
