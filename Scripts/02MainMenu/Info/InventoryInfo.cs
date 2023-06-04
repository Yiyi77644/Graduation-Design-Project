using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Equip,
    Drug,
}

public enum EquipmentType
{
    Hemlet,//头盔
    Clothes,//衣服
    Weapon,//武器
    Shoes,//鞋子
    Nacklace,//项链
    Bracelet,//手镯
    Ring,//戒指
    Wing,//翅膀

}

public class Item
{
    #region 字段
    private int _id;                         //id
    private string _itmeName;                //图集名称 _itmeName
    private string _icon;                    //图标 icon
    private ItemType _itemType;              //类型 itemType
    private EquipmentType _equipmentType;    //装备类型 表示装备穿在哪里
    private int _level = 1;                  //等级 level
    private int _count = 1;                  //个数 count
    private int _price = 0;                  //价格 price
    private int _starLevel = 1;              //星级 starLevel
    private int _quality = 1;                //品质 quality
    private int _damage = 0;                 //伤害 damage
    private int _hp = 0;                     //生命 hp
    private int _combatPower = 0;            //战斗力 combatPower
    private InfoType _infoType;              //作用类型 作用在哪个属性上 infoType
    private int _applyValue;                 //作用值 对属性产生的影响 applyValue
    private string _description;             //描述 description

    #endregion 字段

    #region 属性
    /// <summary>
    /// id
    /// </summary>
    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }
    /// <summary>
    /// 图集名称 _itmeName
    /// </summary>
    public string ItmeName
    {
        get { return _itmeName; }
        set { _itmeName = value; }
    }
    /// <summary>
    /// 图标 icon
    /// </summary>
    public string Icon
    {
        get { return _icon; }
        set { _icon = value; }
    }
    /// <summary>
    /// 类型 itemType
    /// </summary>
    public ItemType ItemType
    {
        get { return _itemType; }
        set { _itemType = value; }
    }
    /// <summary>
    /// 装备类型 表示装备穿在哪里
    /// </summary>
    public EquipmentType EquipmentType
    {
        get { return _equipmentType; }
        set { _equipmentType = value; }
    }
    /// <summary>
    /// 等级 level
    /// </summary>
    public int Level
    {
        get { return _level; }
        set { _level = value; }
    }
    /// <summary>
    /// 个数 count
    /// </summary>
    public int Count
    {
        get { return _count; }
        set { _count = value; }
    }
    /// <summary>
    /// 价格 price
    /// </summary>
    public int Price
    {
        get { return _price; }
        set { _price = value; }
    }
    /// <summary>
    /// 星级 starLevel
    /// </summary>
    public int StarLevel
    {
        get { return _starLevel; }
        set { _starLevel = value; }
    }
    /// <summary>
    /// 品质 quality
    /// </summary>
    public int Quality
    {
        get { return _quality; }
        set { _quality = value; }
    }
    /// <summary>
    /// 伤害 damage
    /// </summary>
    public int Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }
    /// <summary>
    /// 生命 hp
    /// </summary>
    public int Hp
    {
        get { return _hp; }
        set { _hp = value; }
    }
    /// <summary>
    /// 战斗力 combatPower
    /// </summary>
    public int CombatPower
    {
        get { return _combatPower; }
        set { _combatPower = value; }
    }
    /// <summary>
    /// 作用类型 作用在哪个属性上 infoType
    /// </summary>
    public InfoType InfoType
    {
        get { return _infoType; }
        set { _infoType = value; }
    }
    /// <summary>
    /// 作用值 对属性产生的影响 applyValue
    /// </summary>
    public int ApplyValue
    {
        get { return _applyValue; }
        set { _applyValue = value; }
    }
    /// <summary>
    /// 描述 description
    /// </summary>
    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }



    #endregion 属性
}
