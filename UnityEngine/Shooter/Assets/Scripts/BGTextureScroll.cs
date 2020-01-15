using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGTextureScroll : MonoBehaviour
{
    // Scroll main texture based on time

    public float scrollSpeed = 0.5f;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        float offset = Time.time * scrollSpeed; //Time.time 게임 시작부터 지난 시간을 의미
        rend.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
    }
}
