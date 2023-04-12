using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ui_PesanLevel : MonoBehaviour
{
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
    }
}
