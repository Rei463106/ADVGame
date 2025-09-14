using UnityEngine;
using UnityEngine.UI;      // UI �𑀍삷�邽�߂ɒǉ����Ă���
using UnityEngine.SceneManagement;  // �V�[���J�ڂ��s�����߂ɒǉ����Ă���

public class SceneLoader : MonoBehaviour
{
    /// <summary>���[�h����V�[����</summary>
    [SerializeField] string m_sceneNameToBeLoaded = "SceneNameToBeLoaded";
    /// <summary>�t�F�[�h���邽�߂̃}�X�N�ƂȂ� Panel (Image) ���w�肷��B�A���t�@�� 0 �ɂ��Ă����A�K�v�Ȃ�� Raycast Target ���I�t�ɂ��Ă������ƁB</summary>
    [SerializeField] Image m_fadePanel = null;
    /// <summary>�t�F�[�h����X�s�[�h</summary>
    [SerializeField] float m_fadeSpeed = 1f;
    /// <summary>���[�h�J�n�t���O</summary>
    bool m_isLoadStarted = false;

    Talking _talking;

    private void Start()
    {
        _talking=FindAnyObjectByType<Talking>();
    }

    void Update()
    {
        // ���[�h���J�n���ꂽ��
        if (m_isLoadStarted)
        {
            // m_panel ���ݒ肳��Ă�����A���X�ɃA���t�@���グ�ĕs�����ɂ���
            if (m_fadePanel)
            {
                Color panelColor = m_fadePanel.color;
                panelColor.a += m_fadeSpeed * Time.deltaTime;
                m_fadePanel.color = panelColor;

                // �قڕs�����ɂȂ�����
                if (panelColor.a > 0.99f)
                {
                    // �V�[�������[�h����
                    SceneManager.LoadScene(m_sceneNameToBeLoaded);
                    m_isLoadStarted = false;
                    Invoke("_talking.StartMessage()", 2);
                }
            }
            else
            {
                // m_panel ���ݒ肳��Ă��Ȃ����́A�����ɃV�[�������[�h����
                SceneManager.LoadScene(m_sceneNameToBeLoaded);
                m_isLoadStarted = false;
            }
        }
    }

    /// <summary>
    /// �V�[�������[�h����
    /// </summary>
    public void LoadScene()
    {
        m_isLoadStarted = true;
    }

    /// <summary>
    /// ���O���w�肵�ăV�[�������[�h����
    /// </summary>
    /// <param name="sceneName"></param>
    public void LoadScene(string sceneName)
    {
        m_isLoadStarted = true;
        m_sceneNameToBeLoaded = sceneName;
    }
}
