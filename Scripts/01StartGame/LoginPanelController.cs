using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Login面板的数据
/// </summary>
public class LoginPanelModel
{
    private string _userName;
    public string UserName
    {
        get { return _userName; }
        set { _userName = value; }
    }

    private string _password;
    public string Password
    {
        get { return _password; }
        set { _password = value; }
    }
}


public class LoginPanelController : UIBase
{
    LoginPanelModel loginPanelModel;

    protected override void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
        loginPanelModel = new LoginPanelModel();


        Bind();
    }

    /// <summary>
    /// 绑定事件
    /// </summary>
    private void Bind()
    {
        AddButtonListen(UIType.LP_btn_Login, OnButtonLoginClick);
        AddButtonListen(UIType.LP_btn_Register, OnButtonRegisterClick);
        AddButtonListen(UIType.LP_btn_Close, OnButtonCloseLoginClick);

    }

    #region 逻辑
    /// <summary>
    /// 登录按钮被点击
    /// </summary>
    private void OnButtonLoginClick()
    {
        //得到用户名和用户密码，存储起来，等待验证
        loginPanelModel.UserName = GetInputField(UIType.LP_inp_Account).text;
        loginPanelModel.Password = GetInputField(UIType.LP_inp_Password).text;
        //返回开始界面
        UIManager.Instance.SetActive(UIType.SMP, true);
        gameObject.SetActive(false);
        GetText(UIType.SMP, UIType.SMP_txt_User).text = loginPanelModel.UserName;
    }

    /// <summary>
    /// 注册按钮被点击
    /// </summary>
    private void OnButtonRegisterClick()
    {
        //隐藏当前面板，显示注册面板
        UIManager.Instance.SetActive(UIType.RP, true);
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 关闭按钮被点击
    /// </summary>
    private void OnButtonCloseLoginClick()
    {
        UIManager.Instance.SetActive(UIType.SMP, true);
        gameObject.SetActive(false);
    }
    #endregion
}
//验证用户名和密码：TODO
//验证成果：返回开始界面
//验证失败：提示信息TODO