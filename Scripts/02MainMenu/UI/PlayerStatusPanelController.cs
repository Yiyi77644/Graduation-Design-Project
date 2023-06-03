using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusPanelController : UIBase
{
    protected override void Awake()
    {
        base.Awake();
        PlayerInfo.Instance.OnPlayerInfoChanged += this.OnPlayerInfoChanged;
    }
    private void Start()
    {
        AddButtonListen(UIType.PSP_btn_Close, OnButtonCloseClick);
        AddButtonListen(UIType.PSP_btn_ChangeName, OnButtonChangeNameClick);

        /*      NGUI监听按钮点击事件的方法：
        EventDelegate ed = new EventDelegate(this,"按钮点击事件的方法");
        btn.onClick.Add(ed);     */
    }
    private void Update()
    {
        //调用此UpdateEnergyAndHonedShow方法原因：使显示的时间每一秒都在变化。读秒而不是读分。
        UpdateEnergyAndHonedShow();
    }

    private void OnPlayerInfoChanged(InfoType type)
    {
        UpdateShowInfo();
    }
    /// <summary>
    /// 更新整个面板的信息显示
    /// </summary>
    private void UpdateShowInfo()
    {
        #region Top和Middle部分的信息显示
        PlayerInfo info = PlayerInfo.Instance;

        AddImageListen(UIType.PSP_img_Head, Resources.Load<Sprite>(ResourcesPath.UI_img_AllHead_Path + info.HeadPortrait));
        AddTextListen(UIType.PSP_txt_PlayerLevel, info.Level.ToString());
        AddTextListen(UIType.PSP_txt_PlayerName, info.PlayerName);
        AddTextListen(UIType.PSP_txt_PlayerCombatPower, info.Power.ToString());

        int tmpRequireExp = GetRequireExpByLevel(info.Level);
        AddTextListen(UIType.PSP_txt_PlayerExp, info.Exp + "/" + tmpRequireExp);
        AddSliderListen(UIType.PSP_sli_PlayerExp, (float)info.Exp / tmpRequireExp);


        AddTextListen(UIType.PSP_txt_DiamondCount, info.DiamondCount + "");
        AddTextListen(UIType.PSP_txt_CoinCount, info.CoinCount + "");
        #endregion Top和Middle部分的信息显示

        UpdateEnergyAndHonedShow();
    }

    /// <summary>
    /// 计算当前等级升级所需要的经验值
    /// </summary>
    /// <param name="level">当前等级</param>
    /// <returns>返回当前等级升级需要的经验值</returns>
    public int GetRequireExpByLevel(int level)
    {
        //经验升级规则（与教程中不同）：当前等级最高经验值=当前等级*1000
        return level * 1000;
    }

    /// <summary>
    /// 更新体力和历练的显示，并且显示倒计时
    /// </summary>
    private void UpdateEnergyAndHonedShow()
    {
        PlayerInfo info = PlayerInfo.Instance;
        #region 体力及体力恢复时间的显示
        AddTextListen(UIType.PSP_txt_EnergyCount, info.Energy + "/100");
        if (info.Energy >= 100)
        {
            //部分体力 恢复时间
            AddTextListen(UIType.PSP_txt_EnergyPartlyRestoreTime, "00:00:00");
            //全部体力 恢复时间
            AddTextListen(UIType.PSP_txt_EnergyAllRestoreTime, "00:00:00");
        }
        else
        {
            //部分体力 恢复时间
            int remainTime = 60 - (int)info.energyTimer;
            //部分体力 只需要更改最后一个“00”即可。因为目前设定的是一分钟恢复一个体力
            string str = remainTime <= 9 ? "0" + remainTime : remainTime.ToString();
            AddTextListen(UIType.PSP_txt_EnergyPartlyRestoreTime, "00:00:" + str);

            //全部体力 恢复时间
            //需要补充的体力：100-info.Energy
            //恢复全部体力需要的总分钟数（总体力为100，其中需要恢复的那个体力的时间倒计时显示在最后一个“00”中）：
            int minutes = 99 - info.Energy;
            //恢复全部体力需要的小时数
            int hours = minutes / 60;
            //显示的文本框中，分钟的显示：
            minutes = minutes % 60;
            //将时间显示在文本框中
            string hoursStr = hours <= 9 ? "0" + hours : hours.ToString();
            string minutesStr = minutes <= 9 ? "0" + minutes : minutes.ToString();
            AddTextListen(UIType.PSP_txt_EnergyAllRestoreTime, hoursStr + ":" + minutesStr + ":" + str);

        }
        #endregion 体力及体力恢复时间的显示
        #region 历练及历练恢复时间的显示
        AddTextListen(UIType.PSP_txt_HonedCount, info.Honed + "/50");
        if (info.Honed >= 50)
        {
            //部分历练 恢复时间
            AddTextListen(UIType.PSP_txt_HonedPartlyRestoreTime, "00:00:00");
            //全部历练 恢复时间
            AddTextListen(UIType.PSP_txt_HonedAllRestoreTime, "00:00:00");
        }
        else
        {
            //部分历练 恢复时间
            int remainTime = 60 - (int)info.honedTimer;
            //部分历练 只需要更改最后一个“00”即可。因为目前设定的是一分钟恢复一个历练
            string str = remainTime <= 9 ? "0" + remainTime : remainTime.ToString();
            AddTextListen(UIType.PSP_txt_HonedPartlyRestoreTime, "00:00:" + str);

            //全部历练 恢复时间
            //需要补充的历练：50-info.Honed
            int minutes = 49 - info.Honed;
            int hours = minutes / 60;
            minutes = minutes % 60;
            string hoursStr = hours <= 9 ? "0" + hours : hours.ToString();
            string minutesStr = minutes <= 9 ? "0" + minutes : minutes.ToString();
            AddTextListen(UIType.PSP_txt_HonedAllRestoreTime, hoursStr + ":" + minutesStr + ":" + str);

        }
        #endregion 历练及历练恢复时间的显示
    }

    /// <summary>
    /// 点击关闭按钮时
    /// </summary>
    public void OnButtonCloseClick()
    {
        //transform.root.Find(UIType.PSP).gameObject.SetActive(false);
        //SetActive(UIType.PSP, false);
        UIManager.Instance.SetActive(UIType.PSP, false);
    }
    /// <summary>
    /// 点击“改名”按钮时
    /// </summary>
    public void OnButtonChangeNameClick()
    {
        UIManager.Instance.SetActive(UIType.CNP, true);
    }

    private void OnDestroy()
    {
        PlayerInfo.Instance.OnPlayerInfoChanged -= this.OnPlayerInfoChanged;
    }
}
