using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDOL : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //�Ȃ��Ƃǂ��Ȃ邩�Ŋm���߂�
        if (FindObjectsOfType<DDOL>().Length > 1)
        {
            // �d�����Ȃ��悤�ɁA���ɂ��鎞�͎������g��j������
            //�V���O���g���H
            //�N���X�̃C���X�^���X�̐���1�ȏ�H�H
            Destroy(this.gameObject);
        }
        else
        {
            // �����������Ȃ����́A������ DontDestroyOnLoad �ɓo�^����
            //System��DDOL�Ɏ��s�������
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
