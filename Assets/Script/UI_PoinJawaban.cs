using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_PoinJawaban : MonoBehaviour
{
    public static event System.Action<string, bool> EventJawabSoal; 

    //[SerializeField] Ui_PesanLevel _tempatPesan = null;
    [SerializeField] TextMeshProUGUI _textJawaban = null;
    [SerializeField] bool _adalahBenar = false;

    public void PilihJawaban()
    {
        Debug.Log($"{_textJawaban.text} adalah {_adalahBenar}");
        //_tempatPesan.Pesan = $"{_textJawaban.text} adalah {_adalahBenar}";
        EventJawabSoal?.Invoke(_textJawaban.text, _adalahBenar);

    }
    public void SetJawaban(string teksJawaban , bool adalahBenar)
    {
        _textJawaban.text = teksJawaban;
        _adalahBenar = adalahBenar;
    }
}
