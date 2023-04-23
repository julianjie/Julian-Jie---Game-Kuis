using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_LevelPackList : MonoBehaviour
{
    [SerializeField] InisialDataGameplay _inisialDataGameplay = null;
    [SerializeField] UI_LevelKuisList _levelList = null;
    [SerializeField] UI_OpsiLevelPack _tombolLevelPack = null;
    [SerializeField] RectTransform _content = null;
    [Space, SerializeField] LevelPackKuis[] _levelPacks = new LevelPackKuis[0]; 
    void Start()
    {
        LoadLevelPack();

        if(_inisialDataGameplay.SaatKalah)
        {
            UI_OpsiLevelPack_EventSaatKlik(_inisialDataGameplay._levelPackKuis);
        }

        UI_OpsiLevelPack.EventSaatKlik += UI_OpsiLevelPack_EventSaatKlik;
    }
    private void OnDestroy()
    {
        UI_OpsiLevelPack.EventSaatKlik -= UI_OpsiLevelPack_EventSaatKlik;
    }

    private void UI_OpsiLevelPack_EventSaatKlik(LevelPackKuis levelPack)
    {
        _levelList.gameObject.SetActive(true);
        _levelList.UnLoadLevelPack(levelPack);

        gameObject.SetActive(false);
    }

    void Update()
    {
        
    }
    private void LoadLevelPack()
    {
        foreach (var lp in _levelPacks)
        {
            var t = Instantiate(_tombolLevelPack);
            t.SetLevelPack(lp);

            t.transform.SetParent(_content);
            t.transform.localScale = Vector3.one;
        }
    }
}
