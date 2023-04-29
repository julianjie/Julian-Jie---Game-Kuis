using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelMenuDataManager : MonoBehaviour
{
    [SerializeField] UI_LevelPackList _levelPackList = null;
    [SerializeField] PlayerProgres _playerProgress = null;
    [SerializeField] TextMeshProUGUI _tempatKoin = null;
    [Space, SerializeField] LevelPackKuis[] _levelPacks = new LevelPackKuis[0];

    private void Start()
    {
        if (!_playerProgress.MuatProgress())
        {
            _playerProgress.SimpanProgress();
        }

        _levelPackList.LoadLevelPack(_levelPacks, _playerProgress.progressData);

        _tempatKoin.text = $"{_playerProgress.progressData.koin}";
        AudioManager.instance.PlayBGM(0);
    }
}
