using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] InisialDataGameplay _inisialDataGameplay = null;
    [SerializeField] PlayerProgres _playerProgress = null;
    [SerializeField] UI_Pertanyaan _pertanyaan = null;
    [SerializeField] LevelPackKuis _soalSoal = null;
    [SerializeField] UI_PoinJawaban[] _pilihanJawaban = new UI_PoinJawaban[0];
    [SerializeField] GameSceneManager _gameSceneManager = null;
    [SerializeField] string _namaScenePilihMenu = string.Empty;
    [SerializeField] PemanggilSuara _pemanggilSuara = null;
    [SerializeField] AudioClip _suaraMenang = null;
    [SerializeField] AudioClip _suaraKalah = null;
    private int _indexSoal = -1;
    

    private void Start()
    {


        _soalSoal = _inisialDataGameplay._levelPackKuis;
        _indexSoal = _inisialDataGameplay._soalIndexKe;

        NextLevel();
        AudioManager.instance.PlayBGM(1);
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
        _pemanggilSuara.PanggilSuara(AdalahBenar ? _suaraMenang : _suaraKalah);

        if (!AdalahBenar)
            return;

        string namaLevelPack = _inisialDataGameplay._levelPackKuis.name;
        int levelTerakhir = _playerProgress.progressData.progressLevel[namaLevelPack];

        
        if(_indexSoal + 2 > levelTerakhir)
        {
            _playerProgress.progressData.koin += 20;
            _playerProgress.progressData.progressLevel[namaLevelPack] = _indexSoal + 2;
            _playerProgress.SimpanProgress();
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
