using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;

    [SerializeField] AudioSource _bgmPrefab = null;
    [SerializeField] AudioSource _sfxPrefab= null;
    [SerializeField] AudioClip[] _bgmClip = new AudioClip[0];
    AudioSource _bgm = null;
    AudioSource _sfx = null;
    void Start()
    {
        if (instance != null)
        {
            Debug.Log("Objek\"Audio Manager\" sudah ada. \n" +
                "Hapus Objek Serupa.", instance);
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);

        _bgm = Instantiate(_bgmPrefab);
        DontDestroyOnLoad(_bgm);

        _sfx = Instantiate(_sfxPrefab);
        DontDestroyOnLoad(_sfx);
    }

    private void OnDestroy()
    {
        if (this == instance)
        {
            instance= null;

            if (_bgm != null)
                Destroy(_bgm.gameObject);
            if (_sfx != null)
                Destroy(_sfx.gameObject);
        }
    }

    public void PlayBGM(int Index)
    {
        if (_bgm.clip == _bgmClip[Index])
            return;

        _bgm.clip= _bgmClip[Index];
        _bgm.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        _sfx.PlayOneShot(clip);
    }
}
