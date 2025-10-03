using UnityEngine;

public class GameSceneInitializer : MonoBehaviour
{
    void Awake()
    {
        PlayerFlag.appear = false; // ゲーム開始時は表示ONに戻す
        SoundTantou.soundstay = false;
        
    }
    private void Start()
    {
        if (!SoundTantou.soundstay)
        {
            AudioSource _soundMixer = GameObject.Find("SoundMixer").GetComponent<AudioSource>();
            if (!_soundMixer.isPlaying)   // ← すでに流れてたら何もしない
            {
                _soundMixer.Play();
            }
        }
    }

    private void Update()
    {
       
    }
}
