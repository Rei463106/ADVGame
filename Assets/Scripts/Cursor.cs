using UnityEngine;
using UnityEngine.UI;

public class Cursor : MonoBehaviour
{
    MenuController _controller = default;
    BoxHyouji _boxHyouji = default;
    [SerializeField] public Image _cursorImage;
    int currentIndex = 0;
    //範囲内に入ったものを検知する
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
        // 会話中 or アイテム取得メッセージ中は操作禁止
        if (Talking.IsInConversation)
        {
            return;
        }
        if (!_boxHyouji.IsMenuOpen) return; // メニューが閉じていれば何もしない

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
            Debug.Log("押されました");
        }
    }


    void MenuResume(bool isPause)
    {
        if (isPause)
        {
            //この決まり文句いちいち書くのめんどくさいし、オーバーライドの方がよさそうだな…。
            //ここにカーソルの処理を書いていく。

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

        // 効果発動
        if (itemName == "Key")
        {
            Debug.Log("カギの効果発動！");
            //_boxHyouji.Hihyouji();
           // _cursorImage.enabled = false;
           // Talking.IsInConversation = false;
           // _controller.ForceCloseMenu(); // MenuController側にこの関数を追加
           // _itemUseMessage.UseItemMessage("Key"); // ← Loadpowerはここで呼ばない
            PlayerFlag.leftdoor = 1;
            _audioSource.PlayOneShot(_audioClip3);
        }
        else if (itemName == "FireProtein"||itemName== "AquaProtein")
        {
            Debug.Log("プロテインの効果発動！");
            //_boxHyouji.Hihyouji();
            //_cursorImage.enabled = false;
            //_itemUseMessage.UseItemMessage("Protein");
            PlayerFlag.goal++;
            MacchoTalking.talker = 1;
           
            _audioSource.PlayOneShot(_audioClip4);
        }

        // 使ったスロットを空にして下に詰める
        for (int i = slotIndex; i < _boxHyouji._menuText.Length - 1; i++)
        {
            _boxHyouji._menuText[i].text = _boxHyouji._menuText[i + 1].text;
        }
        _boxHyouji._menuText[_boxHyouji._menuText.Length - 1].text = "";
    }

}
