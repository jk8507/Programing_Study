using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataController : MonoBehaviour
{
    public Item[] ItemArr;
    public Sprite[] IconArr;
    public UIElement[] ElementArr;

    // Start is called before the first frame update
    void Start()
    {
        ItemArr = new Item[2];
        for(int i = 0; i < ItemArr.Length; i++)
        {
            ItemArr[i] = new Item();
        }
        ItemArr[0].Title = "공격력";
        ItemArr[0].Contents = "현재 공격력 : ";
        ItemArr[0].Level = 1;
        ItemArr[0].LevelMax = 10;
        ItemArr[0].CostBase = 100;
        ItemArr[0].CostWeight = 300;
        ItemArr[0].Cost = ItemArr[0].CostBase;
        ItemArr[0].ValueBase = 1;
        ItemArr[0].ValueWeight = 2;
        ItemArr[0].Value = ItemArr[0].ValueBase;

        ItemArr[1].Title = "방어력";
        ItemArr[1].Contents = "현재 방어력 : ";
        ItemArr[1].Level = 0;
        ItemArr[1].LevelMax = 100;
        ItemArr[1].CostBase = 1000;
        ItemArr[1].CostWeight = 600;
        ItemArr[1].Cost = ItemArr[0].CostBase;
        ItemArr[1].ValueBase = 1;
        ItemArr[1].ValueWeight = 1;
        ItemArr[1].Value = ItemArr[1].ValueBase;

        for(int i = 0; i < ElementArr.Length; i++)
        {
            ElementArr[i].Setup(ItemArr[i].Title, 
                                ItemArr[i].Contents + ItemArr[i].Value, 
                                ItemArr[i].Cost.ToString(), 
                                "구매",
                                IconArr[i]);
        }
    }

    public void LevelUP(int id)
    {
        ItemArr[id].Level++;
        string purchase = "구매";
        if(ItemArr[id].Level >= ItemArr[id].LevelMax)
        {
            ItemArr[id].Level = ItemArr[id].LevelMax;
            purchase = "최대치";
        }

        ItemArr[id].Cost = ItemArr[id].CostBase + (ItemArr[id].Level * ItemArr[id].CostWeight);
        ItemArr[id].Value = ItemArr[id].ValueBase + (ItemArr[id].Level * ItemArr[id].ValueWeight);

        ElementArr[id].Renew(ItemArr[id].Contents + ItemArr[id].Value, ItemArr[id].Cost.ToString(), purchase);
    }
}

[System.Serializable]
public class Item
{
    public string Title;
    public string Contents;

    public int Cost;
    public int CostBase;
    public int CostWeight;

    public int Level;
    public int LevelMax;

    public int Value;
    public int ValueBase;
    public int ValueWeight;
}