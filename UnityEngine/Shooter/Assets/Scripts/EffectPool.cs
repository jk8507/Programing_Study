using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eEffectType
{
    AsteroidExp,
    EnemyExp,
    PlayerExp
}

public class EffectPool : MonoBehaviour
{
    public Timer[] Prefabs;
    private List<Timer>[] Pools;

    // Start is called before the first frame update
    void Start()
    {

        Pools = new List<Timer>[Prefabs.Length];
        for (int i = 0; i < Pools.Length; i++)
        {
            Pools[i] = new List<Timer>();
        }
        //new List<AsteroidMovement>();
    }

    public Timer GetFromPool(int id)
    {
        for (int i = 0; i < Pools[id].Count; i++)
        {
            if (!Pools[id][i].gameObject.activeInHierarchy)
            {
                Pools[id][i].gameObject.SetActive(true);
                return Pools[id][i];
            }
        }

        Timer newObj = Instantiate(Prefabs[id]); //instantiate는 인스턴스 생성이라는 의미를 가진다.(계층란에 새로운 으브젝트를 복제하여 만듬)
        Pools[id].Add(newObj);
        return newObj;
    }
}
