using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorIdou : MonoBehaviour
{
    //�����ňړ��ꏊ�𔻒f����
    [SerializeField] int idouIdou;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //�Ԃ������̂�����������Door�ɔ��

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DoorChange();
        }
    }
    void DoorChange()
    {
        if (idouIdou == 0)
        {
            SceneManager.LoadScene("Scene_Right");


        }
        if (idouIdou == 1)
        {

            SceneManager.LoadScene("");
        }
    }
}
