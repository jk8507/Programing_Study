using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaugeBarPool : MonoBehaviour
{
    public GaugeBar Origin;
    public Transform OriginParents; // transform을 통해 부모 관계를 형성
    private List<GaugeBar> Pool;

    // Start is called before the first frame update
    void Awake()
    {
        Pool = new List<GaugeBar>();
    }

    public GaugeBar GetFromPool()
    {
        for(int i = 0; i < Pool.Count; i++)
        {
            if(!Pool[i].gameObject.activeInHierarchy)
            {
                Pool[i].gameObject.SetActive(true);
                return Pool[i];
            }
        }
        GaugeBar newObj = Instantiate(Origin, OriginParents);
        //GaugeBar newObj = Instantiate(Origin);
        //newObj.transform.SetParent(OriginParents);
        //newObj.transform.localScale = Vector3.one;
        //newObj.transform.position = Vector3.zero;
        Pool.Add(newObj);
        return newObj;
    }
}
