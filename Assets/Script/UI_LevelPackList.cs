using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_LevelPackList : MonoBehaviour
{
    [SerializeField] Animator _animator = null;
    [SerializeField] InisialDataGameplay _inisialDataGameplay = null;
    [SerializeField] UI_LevelKuisList _levelList = null;
    [SerializeField] UI_OpsiLevelPack _tombolLevelPack = null;
    [SerializeField] RectTransform _content = null;
 
    void Start()
    {
        //LoadLevelPack();

        if(_inisialDataGameplay.SaatKalah)
        {
            UI_OpsiLevelPack_EventSaatKlik(null,_inisialDataGameplay._levelPackKuis,false);
        }

        UI_OpsiLevelPack.EventSaatKlik += UI_OpsiLevelPack_EventSaatKlik;
    }
    private void OnDestroy()
    {
        UI_OpsiLevelPack.EventSaatKlik -= UI_OpsiLevelPack_EventSaatKlik;
    }

    private void UI_OpsiLevelPack_EventSaatKlik(UI_OpsiLevelPack tombolLevelPack,LevelPackKuis levelPack, bool terkunci)
    {
        if (terkunci)
            return;
        //_levelList.gameObject.SetActive(true);
        _levelList.UnLoadLevelPack(levelPack);

        //gameObject.SetActive(false);

        _inisialDataGameplay._levelPackKuis= levelPack;
        _animator.SetTrigger("KeLevels");    
    }

    void Update()
    {
        
    }
    public void LoadLevelPack(LevelPackKuis[] levelPacks, PlayerProgres.MainData playerData)
    {
        foreach (var lp in levelPacks)
        {
            var t = Instantiate(_tombolLevelPack);

            t.SetLevelPack(lp);

            t.transform.SetParent(_content);
            t.transform.localScale = Vector3.one;

            if(!playerData.progressLevel.ContainsKey(lp.name))
            {
                t.KunciLevelPack();
            }
        }
    }
}
