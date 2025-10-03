using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleContoroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ReturnAll();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void ReturnAll()
    {
        //スタートの会話が終わり次第１足してもうその状態なら何度も破壊する
        DoorIdou.breaking = 0;
        //スタートって書いてあるけどゴールね。
        GoalTalk.hasShownGoalMessage = false;
        //二度と動かないようにするために使う
        GoalTalkAfter.hasShownGoalAfterMessage = false;
        // シーンをまたいだら復活しないためのフラグ
        ItemGet.notitem = 0;
        ItemGet.notitem2 = 0;
        ItemGet.notitem3 = 0;
        //スタート用フラグ
        MacchoTalking.talker = 0;
        PlayerFlag.green = 0;
        PlayerFlag.rightdoor = 0;
        PlayerFlag.leftdoor = 0;
        PlayerFlag.goal = 0;
        //ものを破壊するフラグ
        PlayerFlag.breakobje = 0;
        SceneStartHandler.hasShownStartMessage = false;
        StartTalkAfter.hasShownStartAfterMessage = false;

        //MacchoTalking.talkto = 0;
        MacchoTalking.talker = 0;
        //GameObject _gameObject = GameObject.Find("StartTalk");
        //_gameObject.SetActive(true);
    }
}
