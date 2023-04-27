using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterPanelModel
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
    private string _rePassword;
    public string RePassword
    {
        get { return _rePassword; }
        set { _rePassword = value; }
    }
    private string _phoneNumber;
    public string PhoneNumber
    {
        get { return _phoneNumber; }
        set { _phoneNumber = value; }
    }
}

public class RegisterPanelController : UIBase
{
    RegisterPanelModel registerPanelModel;
    private void Start()
    {
        registerPanelModel = new RegisterPanelModel();

        Bind();
    }

    /// <summary>
    /// 绑定事件
    /// </summary>
    private void Bind()
    {
        AddButtonListen(UIType.RP_btn_Register, OnButtonRLClick);
        AddButtonListen(UIType.RP_btn_Cancel, OnButtonCancelClick);
        AddButtonListen(UIType.RP_btn_Close, OnButtonCloseLoginClick);

    }

    #region 逻辑
    /// <summary>
    /// 注册并登录按钮被点击
    /// </summary>
    private void OnButtonRLClick()
    {
        //本地校验，连接服务器进行验证


        //连接失败，给出提示


        //连接成功，保存用户名和密码，返回到开始面板
        //将输入的数据保存起来
        registerPanelModel.UserName = GetInputField(UIType.RP_inp_Account).text;
        registerPanelModel.Password = GetInputField(UIType.RP_inp_Password).text;
        UIManager.Instance.SetActive(UIType.SMP, true);
        gameObject.SetActive(false);
        //更改相应面板对应的显示内容
        GetText(UIType.SMP, UIType.SMP_txt_User).text = registerPanelModel.UserName;
        GetInputField(UIType.LP, UIType.LP_inp_Account).text = registerPanelModel.UserName;
        GetInputField(UIType.LP, UIType.LP_inp_Password).text = registerPanelModel.Password;
    }

    /// <summary>
    /// 取消按钮被点击
    /// </summary>
    private void OnButtonCancelClick()
    {
        UIManager.Instance.SetActive(UIType.SMP, true);
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
