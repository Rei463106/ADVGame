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
        //�X�^�[�g�̉�b���I��莟��P�����Ă������̏�ԂȂ牽�x���j�󂷂�
        DoorIdou.breaking = 0;
        //�X�^�[�g���ď����Ă��邯�ǃS�[���ˁB
        GoalTalk.hasShownGoalMessage = false;
        //��x�Ɠ����Ȃ��悤�ɂ��邽�߂Ɏg��
        GoalTalkAfter.hasShownGoalAfterMessage = false;
        // �V�[�����܂������畜�����Ȃ����߂̃t���O
        ItemGet.notitem = 0;
        ItemGet.notitem2 = 0;
        ItemGet.notitem3 = 0;
        //�X�^�[�g�p�t���O
        MacchoTalking.talker = 0;
        PlayerFlag.green = 0;
        PlayerFlag.rightdoor = 0;
        PlayerFlag.leftdoor = 0;
        PlayerFlag.goal = 0;
        //���̂�j�󂷂�t���O
        PlayerFlag.breakobje = 0;
        SceneStartHandler.hasShownStartMessage = false;
        StartTalkAfter.hasShownStartAfterMessage = false;

        //MacchoTalking.talkto = 0;
        MacchoTalking.talker = 0;
        //GameObject _gameObject = GameObject.Find("StartTalk");
        //_gameObject.SetActive(true);
    }
}
