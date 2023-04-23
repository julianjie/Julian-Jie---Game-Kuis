using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "Inisial Data Gameplay",
    menuName = "Game kuis/Inisial Data Gameplay")]
public class InisialDataGameplay : ScriptableObject
{
    public LevelPackKuis _levelPackKuis = null;
    public int _soalIndexKe = 0;

    [SerializeField] private bool _saatKalah = false;

    public bool SaatKalah
    {
        get => _saatKalah;
        set => _saatKalah = value;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
