using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ui_PesanLevel : MonoBehaviour
{
    [SerializeField] Animator _animator = null;
    [SerializeField] GameObject _opsiMenang = null;
    [SerializeField] GameObject _opsiKalah= null;
    [SerializeField] TextMeshProUGUI _tempatPesan = null;


    public string Pesan
    {
        get => _tempatPesan.text;
        set => _tempatPesan.text= value;
    }
    private void Awake()
    {
        if(gameObject.activeSelf) 
            gameObject.SetActive(false);

        UI_Timer.EventWaktuHabis += UI_Timer_EventWaktuHabis;
        UI_PoinJawaban.EventJawabSoal += UI_PoinJawaban_EventJawabSoal;
    }

    private void OnDestroy()
    {
        UI_Timer.EventWaktuHabis -= UI_Timer_EventWaktuHabis;
        UI_PoinJawaban.EventJawabSoal -= UI_PoinJawaban_EventJawabSoal;
    }
    private void UI_PoinJawaban_EventJawabSoal(string JawabanTeks, bool adalahBenar)
    {
        Pesan = $"Jawaban Anda {adalahBenar} (jawab : {JawabanTeks}";
        gameObject.SetActive(true);

        if(adalahBenar)
        {
            _opsiMenang.SetActive(true);
            _opsiKalah.SetActive(false);

        }
        else
        {
            _opsiMenang.SetActive(false);
            _opsiKalah.SetActive(true);
        }
        _animator.SetBool("Menang", adalahBenar);
    }
    private void UI_Timer_EventWaktuHabis()
    {
        Pesan = "Waktu Sudah Habis!!!";
        gameObject.SetActive(true);

        _opsiMenang.SetActive(false);
        _opsiKalah.SetActive(true);
    }
}
