using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(
    fileName = "Level Pack Baru",
    menuName = "Game kuis/Level Pack Kuis")]
public class LevelPackKuis : ScriptableObject
{
    [SerializeField] LevelSoalKuis[] _isiLevel = new LevelSoalKuis[0];

    [SerializeField] int _harga = 0;

    public int BanyakLevel => _isiLevel.Length;

    public int Harga => _harga;
    public LevelSoalKuis AmbilLevelKe(int index)
    {
        return _isiLevel[index];
    }
}
