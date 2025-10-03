using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerFlag : MonoBehaviour
{
    [Header("マッチョとの会話用のフラグ")]
    public static float green;
    [Header("右のドアで移動するためのフラグ")]
    public static float rightdoor;
    [Header("左のドアで移動するためのフラグ")]
    public static float leftdoor;
    [Header("ゴールに行くためのフラグ")]
    public static float goal;

    //ものを破壊するフラグ
    public static int breakobje;
    //プレイヤーの表示、非表示を切り替えるフラグ
    public static bool appear;

    SpriteRenderer sr;
    void Start()
    {
        green = 0;
        rightdoor = 0;
        leftdoor = 0;
        goal = 0;

        sr = GetComponent<SpriteRenderer>();
        appear = false;

    }
    


    void Update()
    {
        sr.enabled = !appear;  // appear が true なら非表示、false なら表示
    }
}
