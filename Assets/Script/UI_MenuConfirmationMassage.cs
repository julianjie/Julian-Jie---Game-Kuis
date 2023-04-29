using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_MenuConfirmationMassage : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _tempatKoin = null;
    [SerializeField] PlayerProgres _playerProgres = null;
    [SerializeField] GameObject _pesanCukupKoin = null;
    [SerializeField] GameObject _pesanTakCukupKoin = null;
    UI_OpsiLevelPack _tombolLevelPack = null;
    LevelPackKuis _levelPack = null;
    void Start()
    {
        if(gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
        UI_OpsiLevelPack.EventSaatKlik += UI_OpsiLevelPack_EventSaatKlik;
    }
    private void OnDestroy()
    {
        UI_OpsiLevelPack.EventSaatKlik -= UI_OpsiLevelPack_EventSaatKlik;
    }

    private void UI_OpsiLevelPack_EventSaatKlik(UI_OpsiLevelPack tombolLevelPack,LevelPackKuis levelPack, bool terkunci)
    {
        if (!terkunci) return;

        gameObject.SetActive(true);
        if (_playerProgres.progressData.koin < levelPack.Harga)
        {
            _pesanCukupKoin.SetActive(false);
            _pesanTakCukupKoin.SetActive(true);
            return;
        }

        _pesanTakCukupKoin.SetActive(false);
        _pesanCukupKoin.SetActive(true);

        _tombolLevelPack = tombolLevelPack;
        _levelPack = levelPack;
    }

    public void BukaLevel()
    {
        _playerProgres.progressData.koin -= _levelPack.Harga;
        _playerProgres.progressData.progressLevel[_levelPack.name] = 1;

        _tempatKoin.text = $"{_playerProgres.progressData.koin}";

        _playerProgres.SimpanProgress();

        _tombolLevelPack.BukaLevelPack();

    }
}
