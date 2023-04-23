using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Timer : MonoBehaviour
{
    public static event System.Action EventWaktuHabis;

    //[SerializeField] Ui_PesanLevel _tempatPesan = null;
    [SerializeField] Slider _timeBar = null;
    [SerializeField] float _waktuJawab = 30f;
    float _sisawaktu = 0f;
    private bool _waktuBerjalan = true;

    public bool WaktuBerlajan
    {
        get => _waktuBerjalan;
        set => _waktuBerjalan = value;
    }


    void Start()
    {
        UlangWaktu();
    }

    void Update()
    {
        if (!_waktuBerjalan)
            return;

        _sisawaktu -= Time.deltaTime;
        _timeBar.value = _sisawaktu / _waktuJawab;
        if (_sisawaktu <= 0f)
        {
            //_tempatPesan.Pesan = "Waktu Sudah Habis!!!!";
            //_tempatPesan.gameObject.SetActive(true);
            //Debug.Log("Waktu habis");
            EventWaktuHabis?.Invoke();
            _waktuBerjalan = false;
            return;
        }
    }
    public void UlangWaktu()
    {
        _sisawaktu = _waktuJawab;
    }
}
