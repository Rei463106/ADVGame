using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorIdou : MonoBehaviour
{
    [SerializeField] int idouIdou;
    PlayerFlag _playerFlag;

    //�X�^�[�g�̉�b���I��莟��P�����Ă������̏�ԂȂ牽�x���j�󂷂�
    static public int breaking;

    private void Start()
    {
        _playerFlag = FindObjectOfType<PlayerFlag>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DoorChange();
        }
    }

    void DoorChange()
    {
        //��b���rightdoor���P�ɂȂ��Ă���͂��B
        if (idouIdou == 0 && PlayerFlag.rightdoor == 1)
        {
            // �V�[���ǂݍ��݌�ɌĂ΂��R�[���o�b�N��o�^
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene("Scene_Right");

        }


        if (idouIdou == 1)
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene("Scene_Middle");
        }
        if (idouIdou == 2 && PlayerFlag.leftdoor == 1)
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene("Scene_Left");
        }

    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // �o�^�����i�厖�j
        SceneManager.sceneLoaded -= OnSceneLoaded;

        // SpawnPoint ��T���ăv���C���[���ړ�
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            GameObject spawn = GameObject.Find("SpawnPoint");
            if (spawn != null)
            {
                player.transform.position = spawn.transform.position;
            }
        }
        if (breaking == 1)
        {
            GameObject startScened = GameObject.Find("StartTalk");
            if (startScened != null)
            {
                Destroy(startScened);
            }
        }

    }

    public void Tashizan()
    {
        breaking = 1;
    }
}
