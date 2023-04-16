using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] PlayerProgres _playerProgress = null;
    [SerializeField] LevelPackKuis _soalSoal = null;
    [SerializeField] UI_Pertanyaan _pertanyaan = null;
    [SerializeField] UI_PoinJawaban[] _pilihanJawaban = new UI_PoinJawaban[0];
    private int _indexSoal = -1;

    private void Start()
    {
        if (!_playerProgress.MuatProgress())
        {
            _playerProgress.SimpanProgress();
        }



        NextLevel();
    }

    public void NextLevel()
    {
        _indexSoal++;

        if (_indexSoal >= _soalSoal.BanyakLevel)
            _indexSoal = 0;

        LevelSoalKuis soal = _soalSoal.AmbilLevelKe(_indexSoal);

        _pertanyaan.SetPertanyaan($"Soal {_indexSoal + 1}",  soal.pertanyaan, soal.petunjukJawaban);

        for (int i = 0; i < _pilihanJawaban.Length; i++)
        {
            UI_PoinJawaban poin = _pilihanJawaban[i];
            LevelSoalKuis.OpsiJawaban opsi = soal.opsiJawaban[i];
            poin.SetJawaban(opsi.jawabanTeks, opsi.adalahBenar);
        }
    }
}
