using UnityEngine;
using UnityEngine.UI;

public class Cursor : MonoBehaviour
{
    MenuController _controller = default;
    BoxHyouji _boxHyouji = default;
    [SerializeField] public Image _cursorImage;
    int currentIndex = 0;
    //�͈͓��ɓ��������̂����m����
    public string triggers = default;
    ItemUseMessage _itemUseMessage;
    Talking _talking;

    [SerializeField] AudioClip _audioClip2;

    [SerializeField] AudioClip _audioClip3;

    [SerializeField] AudioClip _audioClip4;

    AudioSource _audioSource;

    private void Awake()
    {
        _controller = GameObject.FindObjectOfType<MenuController>();
        _boxHyouji = GameObject.FindObjectOfType<BoxHyouji>();
        _itemUseMessage= GameObject.FindObjectOfType<ItemUseMessage>();
        _talking = GameObject.FindObjectOfType<Talking>();
        _cursorImage.rectTransform.anchoredPosition = _boxHyouji._menuBox[0].rectTransform.anchoredPosition;

    }

    private void OnEnable()
    {
        _controller.OnMenuResume += MenuResume;
    }

    private void OnDisable()
    {
        _controller.OnMenuResume -= MenuResume;
    }

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // ��b�� or �A�C�e���擾���b�Z�[�W���͑���֎~
        if (Talking.IsInConversation)
        {
            return;
        }
        if (!_boxHyouji.IsMenuOpen) return; // ���j���[�����Ă���Ή������Ȃ�

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Downkey();
            _audioSource.PlayOneShot(_audioClip2);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Upkey();
            _audioSource.PlayOneShot(_audioClip2);
        }
        if (Input.GetKeyDown(KeyCode.Z) && triggers != null)
        {
            UseItem(currentIndex);
            Debug.Log("������܂���");
        }
    }


    void MenuResume(bool isPause)
    {
        if (isPause)
        {
            //���̌��܂蕶�傢�����������̂߂�ǂ��������A�I�[�o�[���C�h�̕����悳�������ȁc�B
            //�����ɃJ�[�\���̏����������Ă����B

            _cursorImage.enabled = true;

        }
        else
        {
            _cursorImage.enabled = false;
        }
    }
    void Downkey()
    {
        if (currentIndex < _boxHyouji._menuBox.Length - 1)
            currentIndex++;

        _cursorImage.rectTransform.anchoredPosition =
            _boxHyouji._menuBox[currentIndex].rectTransform.anchoredPosition;
    }

    void Upkey()
    {
        if (currentIndex > 0)
            currentIndex--;

        _cursorImage.rectTransform.anchoredPosition =
            _boxHyouji._menuBox[currentIndex].rectTransform.anchoredPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        triggers = collision.gameObject.name;
    }

    void UseItem(int slotIndex)
    {
        string itemName = _boxHyouji._menuText[slotIndex].text;

        if (string.IsNullOrEmpty(itemName)) return;

        // ���ʔ���
        if (itemName == "Key")
        {
            Debug.Log("�J�M�̌��ʔ����I");
            //_boxHyouji.Hihyouji();
           // _cursorImage.enabled = false;
           // Talking.IsInConversation = false;
           // _controller.ForceCloseMenu(); // MenuController���ɂ��̊֐���ǉ�
           // _itemUseMessage.UseItemMessage("Key"); // �� Loadpower�͂����ŌĂ΂Ȃ�
            PlayerFlag.leftdoor = 1;
            _audioSource.PlayOneShot(_audioClip3);
        }
        else if (itemName == "FireProtein"||itemName== "AquaProtein")
        {
            Debug.Log("�v���e�C���̌��ʔ����I");
            //_boxHyouji.Hihyouji();
            //_cursorImage.enabled = false;
            //_itemUseMessage.UseItemMessage("Protein");
            PlayerFlag.goal++;
            MacchoTalking.talker = 1;
           
            _audioSource.PlayOneShot(_audioClip4);
        }

        // �g�����X���b�g����ɂ��ĉ��ɋl�߂�
        for (int i = slotIndex; i < _boxHyouji._menuText.Length - 1; i++)
        {
            _boxHyouji._menuText[i].text = _boxHyouji._menuText[i + 1].text;
        }
        _boxHyouji._menuText[_boxHyouji._menuText.Length - 1].text = "";
    }

}
