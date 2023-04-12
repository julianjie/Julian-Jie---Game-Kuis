using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Pertanyaan : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _tempatJudul = null;
    [SerializeField] TextMeshProUGUI _tempatTeks = null;
    [SerializeField] Image _tempatGambar = null;


    void Start()
    {
        Debug.Log(_tempatTeks.text);
    }
    
    public void SetPertanyaan(string judul, string teksPernyataan, Sprite gambarHint)
    {
        _tempatJudul.text = judul;
        _tempatTeks.text = teksPernyataan;
        _tempatGambar.sprite = gambarHint;
    }

}
