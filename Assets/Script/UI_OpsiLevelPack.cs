using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_OpsiLevelPack : MonoBehaviour
{
    public static event System.Action<UI_OpsiLevelPack,LevelPackKuis, bool> EventSaatKlik;
    [SerializeField] Button _tombol = null;
    [SerializeField] TextMeshProUGUI _packName = null;
    [SerializeField] LevelPackKuis _levelPack = null;
    [SerializeField] TextMeshProUGUI _labelTerkunci = null;
    [SerializeField] TextMeshProUGUI _labelHarga = null;
    [SerializeField] bool _terkunci = false;

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
        EventSaatKlik?.Invoke(this,_levelPack,_terkunci);
    }

    public void KunciLevelPack()
    {
        _terkunci = true;
        _labelTerkunci.gameObject.SetActive(true);
        _labelHarga.transform.parent.gameObject.SetActive(true);
        _labelHarga.text = $"{_levelPack.Harga}";
    }
    public void BukaLevelPack()
    {
        _terkunci = false;
        _labelTerkunci.gameObject.SetActive(false);
        _labelHarga.transform.parent.gameObject.SetActive(false);
    }
}
