using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIElement : MonoBehaviour
{
    public Button PurchaseButton;
    public Text TitleText, ContentsText, CostText, PurchaseText;
    public Image Icon;

    public void Setup(string title, string contents, string cost, string purchase, Sprite icon)
    {
        TitleText.text = title;
        ContentsText.text = contents;
        CostText.text = cost;
        PurchaseText.text = purchase;
        Icon.sprite = icon;
    }

    public void Renew(string contents, string cost, string purchase)
    {
        ContentsText.text = contents;
        CostText.text = cost;
        PurchaseText.text = purchase;
    }
}
