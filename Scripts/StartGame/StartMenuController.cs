using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuController : UIBase
{
    private void Start()
    {
        ////为初始用户名设置默认值
        //GetText(UIType.SMP_txt_User).text = GetInputField(UIType.LP, UIType.LP_inp_Account).text;


        BindEvent();
    }

    /// <summary>
    /// 绑定事件
    /// </summary>
    private void BindEvent()
    {
        AddButtonListen(UIType.SMP_btn_User, OnButtonUserNameClick);
        AddButtonListen(UIType.SMP_btn_Server, OnButtonServerClick);
        AddButtonListen(UIType.SMP_btn_EnterGame, OnButtonEnterGameClick);
    }

    #region 逻辑
    /// <summary>
    /// 用户名按钮被点击
    /// </summary>
    public void OnButtonUserNameClick()
    {
        //输入账号登录
        //显示登录面板，隐藏当前面板
        //TODO
        UIManager.Instance.SetActive(UIType.SMP, false);
        UIManager.Instance.SetActive(UIType.LP, true);
    }

    /// <summary>
    /// 服务器按钮被点击
    /// </summary>
    public void OnButtonServerClick()
    {

    }

    /// <summary>
    /// 进入游戏按钮被点击
    /// </summary>
    public void OnButtonEnterGameClick()
    {
        //1.连接服务器，验证用户名和服务器
        //TODO
        //2.进入角色选择界面
        //TODO
    }

    #endregion




}
