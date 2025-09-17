using UnityEngine;

public class MenuController : MonoBehaviour
{
    /// <summary> /// true�̎��͈ꎞ��~ /// </summary>
    bool _menuFlg = false;
    /// <summary> /// �ꎞ��~�E�ĊJ�𐧌䂷�邽�߂̊֐��̌^�i�f���Q�[�g�j���` /// </summary>
    public delegate void Menu(bool isMenu);
    /// <summary>/// �f���Q�[�g�����Ă������߂̕ϐ� /// </summary>
    Menu _omMenuResume = default;

    /// <summary> /// �ꎞ��~�E�ĊJ������f���Q�[�g�v���p�e�B /// </summary>
    public Menu OnMenuResume
    {
        get { return _omMenuResume; }
        set { _omMenuResume = value; }
    }
    void Update()
    {
        // ��b���̓��j���[�֎~
        if (Talking.IsInConversation)
            return;

        if (Input.GetKeyDown(KeyCode.X))
        {
            MenuResume();
        }
       
    }

    void MenuResume()
    {
        _menuFlg = !_menuFlg;
        //true�̎��A�����ɓo�^�������̂��Ăяo�����
        _omMenuResume(_menuFlg);
    }
}
