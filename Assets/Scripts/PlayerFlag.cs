using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlag : MonoBehaviour
{
    [Header("�}�b�`���Ƃ̉�b�p�̃t���O")]
    public static float green;
    [Header("�E�̃h�A�ňړ����邽�߂̃t���O")]
    public static float rightdoor;
    [Header("���̃h�A�ňړ����邽�߂̃t���O")]
    public static float leftdoor;
    [Header("�S�[���ɍs�����߂̃t���O")]
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
