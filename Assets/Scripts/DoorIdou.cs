using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorIdou : MonoBehaviour
{
    //”š‚ÅˆÚ“®êŠ‚ğ”»’f‚·‚é
    [SerializeField] int idouIdou;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //‚Ô‚Â‚©‚Á‚½‚Ì‚ª•ª‚©‚Á‚½‚çDoor‚É”ò‚Ô

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
