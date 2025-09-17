using System.Collections;
using System.Collections.Generic;
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

    void Start()
    {
        green = 0;
        rightdoor = 0;
        leftdoor = 0;
        goal = 0;
    }


    void Update()
    {

    }
}
