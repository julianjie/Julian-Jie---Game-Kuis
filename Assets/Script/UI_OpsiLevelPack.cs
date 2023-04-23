using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_OpsiLevelPack : MonoBehaviour
{
    public static event System.Action<LevelPackKuis> EventSaatKlik;
    [SerializeField] Button _tombol = null;
    [SerializeField] TextMeshProUGUI _packName = null;
    [SerializeField] LevelPackKuis _levelPack = null;
    void Start()
    {
        if(_levelPack != null)
        {
            SetLevelPack(_levelPack);
        }
        _tombol.onClick.AddListener(Klik);
    }

    private void OnDestroy()
    {
        _tombol.onClick.RemoveListener(Klik);
    }
    public void SetLevelPack(LevelPackKuis levelPack)
    {
        _packName.text = levelPack.name;
        _levelPack = levelPack;
    }
    private void Klik()
    {
        //Debug.Log("KLIK!!!");
        EventSaatKlik?.Invoke(_levelPack);
    }
}
