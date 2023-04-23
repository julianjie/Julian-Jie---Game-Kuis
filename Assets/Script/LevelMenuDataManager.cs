using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelMenuDataManager : MonoBehaviour
{
    [SerializeField] PlayerProgres _playerProgress = null;
    [SerializeField] TextMeshProUGUI _tempatKoin = null;

    private void Start()
    {
        _tempatKoin.text = $"{_playerProgress.progressData.koin}";
    }
}
