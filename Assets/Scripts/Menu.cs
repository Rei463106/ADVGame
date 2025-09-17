using UnityEngine;

public class Menu : MonoBehaviour
{
    MenuController _controller = default;
    BoxHyouji _boxHyouji = default;
    Cursor _cursor = default;
    Talking _talking;

    private void Awake()
    {
        _controller = GameObject.FindObjectOfType<MenuController>();
        _boxHyouji = GameObject.FindObjectOfType<BoxHyouji>();
        _cursor = GameObject.FindObjectOfType<Cursor>();
        _talking = GameObject.FindObjectOfType<Talking>();

        for (int i = 0; i < _boxHyouji._menuBox.Length; i++)
        {
            _boxHyouji._menuBox[i].enabled = false;
            _boxHyouji._menuText[i].enabled = false;

        }
        _boxHyouji._menuHaikei.enabled = false;
        _cursor._cursorImage.enabled = false;
    }
    void OnEnable()
    {
        //�v���p�e�B�̂Ƃ���ɏ������ށH�H
        _controller.OnMenuResume += MenuResume;
    }

    private void OnDisable()
    {
        _controller.OnMenuResume -= MenuResume;
    }

    //�����V���ɓo�^�����̂ŁA�����ɏ����������B
    //����ɍׂ��������͎��̃��\�b�h�ցB
    void MenuResume(bool isPause)
    {
        if (isPause)
        {
            Pause();
            _talking.Savepower();
        }
        else
        {
            Resume();
            _talking.Loadpower();
        }
    }

    public void Pause()
    {
        //���j���[���J���B
        //�Ƃ肠�����摜��\��������B
        Debug.Log("���j���[���J���܂���");
        //�摜��\�����邽�߂̌v�Z��ʂ̃X�N���v�g�ōs���I�I

        _boxHyouji.Hyouji();

    }
    public void Resume()
    {

        Debug.Log("���j���[����܂���");
        _boxHyouji.Hihyouji();
    }
}
