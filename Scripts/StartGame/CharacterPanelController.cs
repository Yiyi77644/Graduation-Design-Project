using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class CharacterPanelController : UIBase
{

    private void Start()
    {
        AddButtonListen(UIType.CP_btn_CharSelect, OnButtonChangeCharClick);
    }

    /// <summary>
    /// 点击更换角色按钮
    /// </summary>
    public void OnButtonChangeCharClick()
    {
        UIManager.Instance.SetActive(UIType.CP, false);
        UIManager.Instance.SetActive(UIType.CSP, true);
        
    }
}
