using UnityEngine;

public class GameSceneInitializer : MonoBehaviour
{
    void Awake()
    {
        PlayerFlag.appear = false; // �Q�[���J�n���͕\��ON�ɖ߂�
        SoundTantou.soundstay = false;
        
    }
    private void Start()
    {
        if (!SoundTantou.soundstay)
        {
            AudioSource _soundMixer = GameObject.Find("SoundMixer").GetComponent<AudioSource>();
            if (!_soundMixer.isPlaying)   // �� ���łɗ���Ă��牽�����Ȃ�
            {
                _soundMixer.Play();
            }
        }
    }

    private void Update()
    {
       
    }
}
