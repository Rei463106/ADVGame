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


    private void Awake()
    {
        _controller = GameObject.FindObjectOfType<MenuController>();
        _boxHyouji = GameObject.FindObjectOfType<BoxHyouji>();
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

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {

            Downkey();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Upkey();
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
            PlayerFlag.leftdoor = 1;
        }
        else if (itemName == "FireProtein"||itemName== "AquaProtein")
        {
            Debug.Log("プロテインの効果発動！");
            PlayerFlag.goal++;
            MacchoTalking.talker = 1;
        }

        // 使ったスロットを空にして下に詰める
        for (int i = slotIndex; i < _boxHyouji._menuText.Length - 1; i++)
        {
            _boxHyouji._menuText[i].text = _boxHyouji._menuText[i + 1].text;
        }
        _boxHyouji._menuText[_boxHyouji._menuText.Length - 1].text = "";
    }

}
