using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_LevelKuisList : MonoBehaviour
{
    [SerializeField] InisialDataGameplay _inisialDataGameplay = null;
    [SerializeField] UI_LevelKuisList _levelList = null;
    [SerializeField] UI_OpsiLevelKuis _tombolLevel = null;
    [SerializeField] RectTransform _content = null;
    [Space, SerializeField] LevelPackKuis _levelPack = null;
    [SerializeField] GameSceneManager _gameSceneManager = null;
    [SerializeField] string _gameplayScene = null;
    void Start()
    {
        //if(_levelPack != null)
        //{
        //    UnLoadLevelPack(_levelPack);  
        //}
        UI_OpsiLevelKuis.EventSaatKlik += UI_OpsiLevelKuis_EventSaatKlik;
    }
    private void OnDestroy()
    {
        UI_OpsiLevelKuis.EventSaatKlik -= UI_OpsiLevelKuis_EventSaatKlik;
    }
    private void UI_OpsiLevelKuis_EventSaatKlik(int index)
    {
        _inisialDataGameplay._levelPackKuis = _levelPack;
        _inisialDataGameplay._soalIndexKe  = index - 1 ;
        _gameSceneManager.BukaScene(_gameplayScene);
    }

    void Update()
    {

    }
    public void UnLoadLevelPack(LevelPackKuis levelPack)
    {
        HapusIsiKonten();

        _levelPack= levelPack;
        for (int i = 0; i < _levelPack.BanyakLevel; i++)
        {
            var t = Instantiate(_tombolLevel);
            t.SetLevelKuis(levelPack.AmbilLevelKe(i), i);

            t.transform.SetParent(_content);
            t.transform.localScale = Vector3.one;
        }
    }
    void HapusIsiKonten()
    {
        var cc = _content.childCount;
        for (int i = 0; i < cc; i++)
        {
            Destroy(_content.GetChild(i).gameObject);
        }
    }
}
