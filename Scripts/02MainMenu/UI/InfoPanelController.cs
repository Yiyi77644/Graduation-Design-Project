using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//视频中讲解的是PlayerBar部分代码
public class InfoPanelController : UIBase
{
    //获取img_PlayerBar中需要更改内容的控件

    protected override void Awake()
    {
        base.Awake();

        PlayerInfo.Instance.OnPlayerInfoChanged += this.OnPlayerInfoChanged;

    }

    private void Start()
    {
        UIManager.Instance.SetActive(UIType.PSP, false);
        AddButtonListen(UIType.InfoP_btn_Head, OnButtonHeadClick);
    }
    /// <summary>
    /// 注册事件，玩家信息发生改变，触发该方法
    /// </summary>
    /// <param name="type"></param>
    public void OnPlayerInfoChanged(InfoType type)
    {
        //HeadBar中的信息发生变化时
        if (type == InfoType.All || type == InfoType.PlayerName || type == InfoType.HeadPortrait
            || type == InfoType.Level || type == InfoType.Energy || type == InfoType.Honed)
        {
            
            UpdateShowHeadBarInfo();

        }
        //TopBar中的信息发生变化时
        if (type == InfoType.All || type == InfoType.CoinCount || type == InfoType.DiamondCount)
        {
            UpdateShowTopMoneyBarInfo();
        }
    }

    /// <summary>
    /// 更新头像栏显示信息
    /// </summary>
    private void UpdateShowHeadBarInfo()
    {
        PlayerInfo info = PlayerInfo.Instance;

        AddImageListen(UIType.InfoP_img_Head, Resources.Load<Sprite>(ResourcesPath.UI_img_AllHead_Path + info.HeadPortrait));
        AddTextListen(UIType.InfoP_txt_PlayerLevel, info.Level.ToString());
        AddTextListen(UIType.InfoP_txt_PlayerName, info.PlayerName);

        AddSliderListen(UIType.InfoP_sli_EnergyBar, info.Energy / 100f);
        AddTextListen(UIType.InfoP_txt_PlayerEnergy, info.Energy + "/100");

        AddSliderListen(UIType.InfoP_sli_Honedbar, info.Honed / 50f);
        AddTextListen(UIType.InfoP_txt_PlayerHoned, info.Honed + "/50");
    }
    /// <summary>
    /// 更新顶部货币栏显示信息
    /// </summary>
    private void UpdateShowTopMoneyBarInfo()
    {
        PlayerInfo info = PlayerInfo.Instance;

        AddTextListen(UIType.InfoP_txt_CoinCount, info.CoinCount.ToString());
        AddTextListen(UIType.InfoP_txt_DiamondCount, info.DiamondCount.ToString());
    }

    public void OnButtonHeadClick()
    {
        //transform.root.Find(UIType .PSP ).gameObject.SetActive(true);
        UIManager.Instance.SetActive(UIType.PSP, true);
    }

    /// <summary>
    /// 注销事件
    /// </summary>
    private void OnDestroy()
    {
        PlayerInfo.Instance.OnPlayerInfoChanged -= this.OnPlayerInfoChanged;
    }
}
