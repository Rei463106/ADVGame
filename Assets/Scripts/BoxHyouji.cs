using UnityEngine;
using UnityEngine.UI;

public class BoxHyouji : MonoBehaviour
{
    //メニューの背景
    [SerializeField] public Image _menuHaikei;
    //メニューのボックス（配列）
    [SerializeField] public Image[] _menuBox;
    //メニューのテキスト（配列）
    [SerializeField] public Text[] _menuText;
    //メニューボックスの0番目の座標が入ってる
    Vector2 _boxPosition;
    //テキストの0番目の座標が入ってる
    Vector2 _textPosition;
    //下にどのくらい座標をずらすか
    [SerializeField] int _boxHeight = 10;
    //下にどのくらい座標をずらすか
    [SerializeField] int _textHeight = 10;
    //ボックスを表示した時の効果音
    [SerializeField]AudioClip _audioClip;

    AudioSource _audioSource;
    public bool IsMenuOpen { get; private set; } = false;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Hyouji()
    {
        IsMenuOpen = true;
        _menuHaikei.enabled = true;
        if (_audioClip != null && _audioSource != null)
            _audioSource.PlayOneShot(_audioClip);


        // Sceneに置いた0番目の位置を基準にする（anchoredPosition必須！）
        //anchoredPositionにしたらうまく行った…
        Vector2 boxPos = _menuBox[0].rectTransform.anchoredPosition;
        Vector2 textPos = _menuText[0].rectTransform.anchoredPosition;

        for (int i = 0; i < _menuBox.Length; i++)
        {
            _menuBox[i].enabled = true;
            _menuBox[i].rectTransform.anchoredPosition = boxPos;

            _menuText[i].enabled = true;
            _menuText[i].rectTransform.anchoredPosition = textPos;

            // 下に並べる
            boxPos.y -= _boxHeight;
            textPos.y -= _boxHeight;
        }
    }


    public void Hihyouji()
    {
        //非表示の際の処理を書く
         IsMenuOpen = false;
        if (_audioClip != null && _audioSource != null)
            _audioSource.PlayOneShot(_audioClip);

        for (int i = 0; i < _menuBox.Length; i++)
        {
            _menuBox[i].enabled = false;
            _menuText[i].enabled = false;

        }
        _menuHaikei.enabled = false;
    }

}
