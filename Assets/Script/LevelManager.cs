using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] InisialDataGameplay _inisialDataGameplay = null;
    [SerializeField] PlayerProgres _playerProgress = null;
    [SerializeField] UI_Pertanyaan _pertanyaan = null;
    [SerializeField] UI_PoinJawaban[] _pilihanJawaban = new UI_PoinJawaban[0];
    [SerializeField] GameSceneManager _gameSceneManager = null;
    [SerializeField] string _namaScenePilihMenu = string.Empty;
    

    private void Start()
    {
        //if (!_playerProgress.MuatProgress())
        //{
        //    _playerProgress.SimpanProgress();
        //}



        NextLevel();
        UI_PoinJawaban.EventJawabSoal += UI_PoinJawaban_EventJawabSoal;
    }
    private void OnDestroy()
    {
        UI_PoinJawaban.EventJawabSoal -= UI_PoinJawaban_EventJawabSoal;
    }


    private void OnApplicationQuit()
    {
        _inisialDataGameplay.SaatKalah = false;
        _inisialDataGameplay._soalIndexKe = -1;
    }
    private void UI_PoinJawaban_EventJawabSoal(string Jawaban, bool AdalahBenar)
    {
        if(AdalahBenar)
        {
            _playerProgress.progressData.koin += 20;
        }
    }
    public void NextLevel()
    {
        _inisialDataGameplay._soalIndexKe++;

        if (_inisialDataGameplay._soalIndexKe >= _inisialDataGameplay._levelPackKuis.BanyakLevel)
        {
            //_indexSoal = 0;
            _gameSceneManager.BukaScene(_namaScenePilihMenu);
            return;
        }
            

        LevelSoalKuis soal = _inisialDataGameplay._levelPackKuis.AmbilLevelKe(_inisialDataGameplay._soalIndexKe);

        _pertanyaan.SetPertanyaan($"Soal {_inisialDataGameplay._soalIndexKe + 1}",  soal.pertanyaan, soal.petunjukJawaban);

        for (int i = 0; i < _pilihanJawaban.Length; i++)
        {
            UI_PoinJawaban poin = _pilihanJawaban[i];
            LevelSoalKuis.OpsiJawaban opsi = soal.opsiJawaban[i];
            poin.SetJawaban(opsi.jawabanTeks, opsi.adalahBenar);
        }
    }
}
