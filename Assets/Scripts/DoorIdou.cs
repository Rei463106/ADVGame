using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorIdou : MonoBehaviour
{
    [SerializeField] int idouIdou;
    PlayerFlag _playerFlag;

    //スタートの会話が終わり次第１足してもうその状態なら何度も破壊する
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
        //会話後にrightdoorが１になっているはず。
        if (idouIdou == 0 && PlayerFlag.rightdoor == 1)
        {
            // シーン読み込み後に呼ばれるコールバックを登録
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
        // 登録解除（大事）
        SceneManager.sceneLoaded -= OnSceneLoaded;

        // SpawnPoint を探してプレイヤーを移動
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
