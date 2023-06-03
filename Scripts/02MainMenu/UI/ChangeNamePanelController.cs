using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeNamePanelController : UIBase
{
    private void Start()
    {
        AddButtonListen(UIType.CNP_btn_ChangeConfirm, OnButtonChangeNameConfirmClick);
        AddButtonListen(UIType.CNP_btn_ChangeCancel, OnButtonChangeNameCancelClick);
    }

    /// <summary>
    /// 点击改名界面“确认”按钮时
    /// </summary>
    public void OnButtonChangeNameConfirmClick()
    {
        //首先联网校验名字是否重复
        //TODO
        //验证成功，将值赋给PlayerInfo
        PlayerInfo.Instance.ChangeName(GetInputField(UIType.CNP_inp_ChangeName).text);
        UIManager.Instance.SetActive(UIType.CNP, false);
    }
    /// <summary>
    /// 点击改名界面“取消”按钮时
    /// </summary>
    public void OnButtonChangeNameCancelClick()
    {
        UIManager.Instance.SetActive(UIType.CNP, false);
    }
}
