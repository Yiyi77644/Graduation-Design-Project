using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region 单例
    private static UIManager _instance;
    public static UIManager Instance
    {
        get { return _instance; }
    }
    #endregion 单例

    private void Awake()
    {
        _instance = this;
    }

    /// <summary>
    /// 用于存放所有的panel
    /// </summary>
    public Dictionary<string, GameObject> allPanel = new Dictionary<string, GameObject>();
    /// <summary>
    /// panel名，子控件名，子控件本身
    /// </summary>
    public Dictionary<string, Dictionary<string, GameObject>> allChildren = new Dictionary<string, Dictionary<string, GameObject>>();

    /// <summary>
    /// panel下的子控件将自己注册到UIManager
    /// </summary>
    /// <param name="panelName">子控件属于哪个panel</param>
    /// <param name="widgetName">子控件名字</param>
    /// <param name="widget">子控件本身</param>
    public void RegisteGameObject(string panelName, string widgetName, GameObject widget)
    {
        //如果字典中没有此Panel
        if (!allChildren.ContainsKey(panelName))
        {
            //allChildren[panelName] = new Dictionary<string, GameObject>();
            allChildren.Add(panelName, new Dictionary<string, GameObject>());
        }
        //如果字典中没有此子控件
        if (!allChildren.ContainsKey(widgetName))
        {
            allChildren[panelName].Add(widgetName, widget);
        }
        else
        {
            Debug.LogError("已存在" + widgetName);
        }
    }

    /// <summary>
    /// 获取已注册到该字典的子控件
    /// </summary>
    /// <param name="panelName">子控件所在的panel的名字</param>
    /// <param name="widgetName">子控件本身的名字</param>
    /// <returns></returns>
    public GameObject GetWidget(string panelName, string widgetName)
    {
        if (allChildren.ContainsKey(panelName))
        {
            return allChildren[panelName][widgetName];
        }
        return null;
    }
    /// <summary>
    /// 获取已注册到字典的panel
    /// </summary>
    /// <param name="panelName"></param>
    /// <returns></returns>
    public GameObject GetPanel(string panelName)
    {
        if (allChildren.ContainsKey(panelName))
        {
            return allPanel[panelName];
        }
        return null;
    }

    /// <summary>
    /// 设置页面激活方法
    /// </summary>
    /// <param name="controllerName">页面名字</param>
    /// <param name="active">是否激活</param>
    public void SetActive(string controllerName, bool active)
    {
        transform.Find(controllerName).gameObject.SetActive(active);
    }

}
