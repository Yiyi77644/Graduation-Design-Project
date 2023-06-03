using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum InfoType
{
    PlayerName, 
    HeadPortrait,
    Level, 
    Power,
    Exp, 
    DiamondCount, 
    CoinCount, 
    Energy, 
    Honed,
    All,
}
public class PlayerInfo : MonoBehaviour
{
    #region 单例
    private static PlayerInfo _instance;
    public static PlayerInfo Instance
    {
        get { return _instance; }
    }
    #endregion 单例

    #region 字段
    //姓名，头像，等级，战斗力，经验数，钻石数，金币数，体力数，历练数
    private string _playerName;
    private string _headPortrait;
    private int _level = 1;
    private int _power = 1;
    private int _exp = 0;
    private int _diamondCount = 0;
    private int _coinCount = 0;
    private int _energy = 100;
    private int _honed = 50;    //历练
    #endregion 字段
    #region 属性
    /// <summary>
    /// 姓名  
    /// </summary>
    public string PlayerName
    {
        get { return _playerName; }
        set { _playerName = value; }
    }
    /// <summary>
    /// 头像
    /// </summary>
    public string HeadPortrait
    {
        get { return _headPortrait; }
        set { _headPortrait = value; }
    }
    /// <summary>
    /// 等级
    /// </summary>
    public int Level
    {
        get { return _level; }
        set { _level = value; }
    }
    /// <summary>
    /// 战斗力 
    /// </summary>
    public int Power
    {
        get { return _power; }
        set { _power = value; }
    }
    /// <summary>
    /// 经验数
    /// </summary>
    public int Exp
    {
        get { return _exp; }
        set { _exp = value; }
    }
    /// <summary>
    /// 钻石数 
    /// </summary>
    public int DiamondCount
    {
        get { return _diamondCount; }
        set { _diamondCount = value; }
    }
    /// <summary>
    /// 金币数  
    /// </summary>
    public int CoinCount
    {
        get { return _coinCount; }
        set { _coinCount = value; }
    }
    /// <summary>
    /// 体力数 
    /// </summary>
    public int Energy
    {
        get { return _energy; }
        set { _energy = value; }
    }
    /// <summary>
    /// 历练数
    /// </summary>
    public int Honed
    {
        get { return _honed; }
        set { _honed = value; }
    }
    #endregion 属性

    /// <summary>
    /// 体力计时器
    /// </summary>
    public float energyTimer = 0;
    /// <summary>
    /// 历练计时器
    /// </summary>
    public float honedTimer = 0;

    /// <summary>
    /// 玩家信息更改的委托事件
    /// </summary>
    /// <param name="info">传递一个InfoType类型的参数。InfoType是枚举类型。</param>
    public delegate void OnPlayerInfoChangedEvent(InfoType type);
    public event OnPlayerInfoChangedEvent OnPlayerInfoChanged;

    #region Unity事件
    private void Awake()
    {
        //Debug.Log("Awake has been called");
        _instance = this;
    }
    private void Start()
    {
        //Debug.Log("Init has been called");
        Init();
    }
    private void Update()
    {
        //实现体力的自动增长
        if (Energy < 100)
        {
            energyTimer += Time.deltaTime;
            if (energyTimer > 60)
            {
                Energy += 1;
                energyTimer -= 60;
                OnPlayerInfoChanged(InfoType.Energy);
            }
        }
        else
        {
            energyTimer = 0;
        }
        //实现历练的自动增长
        if (Honed  < 50)
        {
            honedTimer += Time.deltaTime;
            if (honedTimer > 60)
            {
                Honed += 1;
                honedTimer -= 60;
                OnPlayerInfoChanged(InfoType.Honed);
            }
        }
        else
        {
            honedTimer = 0;
        }


    }
    #endregion Unity事件


    private void Init()
    {
        CoinCount = 2333;
        DiamondCount = 3929;
        Energy = 78;
        Exp = 3400;
        HeadPortrait = "头像底板女性";
        Level = 12;
        PlayerName = "伊丽莎白3";
        Power = 3838;
        Honed = 30;
        OnPlayerInfoChanged(InfoType.All);
    }

    /// <summary>
    /// 修改角色名
    /// </summary>
    /// <param name="newName">传递一个角色名字</param>
    public void ChangeName(string newName)
    {
        this.PlayerName = newName;
        OnPlayerInfoChanged(InfoType.PlayerName);
    }

}
