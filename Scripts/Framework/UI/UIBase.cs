using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UIBase : MonoBehaviour
{
    private void Awake()
    {
        //获取所有子控件。
        Transform[] allChildren = transform.GetComponentsInChildren<Transform>();
        for (int i = 0; i < allChildren.Length; i++)
        {
            //要用到的子控件身上挂载一个UIBehavior脚本。UIBase主动给子控件挂载一个UIBehaviour脚本
            if (allChildren[i].name.EndsWith("_N1"))
            {
                allChildren[i].gameObject.AddComponent<UIBehaviors>();
            }
        }
    }

    #region 获取控件和组件
    /// <summary>
    /// 从UIManager的字典里面获取需要的Panel
    /// </summary>
    /// <param name="panelName">panel的名字</param>
    /// <returns>返回该panel</returns>
    public GameObject GetPanel(string panelName)
    {
        return UIManager.Instance.GetPanel(panelName);
    }
    /// <summary>
    /// 从UIManager的字典里面拿取需要的子控件
    /// </summary>
    /// <param name="widgetName">子控件的名字</param>
    /// <returns>返回该子控件</returns>
    public GameObject GetWidget(string widgetName)
    {
        return UIManager.Instance.GetWidget(transform.name, widgetName);
    }

    /// <summary>
    /// 从拿到的子控件身上获取UIBehavior组件。
    /// </summary>
    /// <param name="widgetName">子控件名称</param>
    /// <returns>返回子控件身上的UIBehavior组件。如果没有，则返回空</returns>
    public UIBehaviors GetBehavior(string widgetName)
    {
        GameObject tmpObj = GetWidget(widgetName);
        if (tmpObj)
        {
            return tmpObj.GetComponent<UIBehaviors>();
        }
        return null;
    }

    /// <summary>
    /// 当要获取的子控件组件来自其他面板的子控件时
    /// </summary>
    /// <param name="panelName">面板名称</param>
    /// <param name="widgetName">子控件名称</param>
    /// <returns>返回子控件身上的UIBehavior组件。如果没有，则返回空</returns>
    public UIBehaviors GetBehavior(string panelName,string widgetName)
    {
        GameObject tmpObj = UIManager.Instance.GetWidget(panelName, widgetName);
        if (tmpObj)
        {
            return tmpObj.GetComponent<UIBehaviors>();
        }
        return null;
    }

    #endregion 获取控件和组件

    #region 对panel或者子控件本身的操作
    /// <summary>
    /// panel激活或者隐藏
    /// </summary>
    /// <param name="panelName">panel的名字</param>
    /// <param name="isActive">是否激活。激活传参为true，隐藏传参为false</param>
    public void SetActive(string panelName, bool isActive)
    {
        GetPanel(panelName).SetActive(isActive);
    }

    /// <summary>
    /// 获取子控件身上的InputField组件
    /// </summary>
    /// <param name="widgetName">子控件名称</param>
    /// <returns>返回子控件身上的InputField组件</returns>
    public InputField GetInputField(string widgetName)
    {
        UIBehaviors tmpBehavior = GetBehavior(widgetName);
        if (tmpBehavior)
        {
            return tmpBehavior.GetComponent<InputField>();
        }
        return null;
    }

    /// <summary>
    /// 获取子控件身上的InputField组件
    /// </summary>
    /// <param name="widgetName">子控件名称</param>
    /// <returns>返回子控件身上的InputField组件</returns>
    public InputField GetInputField(string panelName,string widgetName)
    {
        UIBehaviors tmpBehavior = GetBehavior(panelName,widgetName);
        if (tmpBehavior)
        {
            return tmpBehavior.GetComponent<InputField>();
        }
        return null;
    }

    /// <summary>
    /// 获取该面板下的子控件的组件
    /// </summary>
    /// <param name="widgetName">子控件名</param>
    /// <returns>返回该子控件的text组件</returns>
    public Text GetText(string widgetName)
    {
        UIBehaviors tmpBehavior = GetBehavior(widgetName);
        if (tmpBehavior)
        {
            return tmpBehavior.GetComponent<Text>();
        }
        return null;
    }
    /// <summary>
    /// 获取其他面板下的子控件的组件
    /// </summary>
    /// <param name="panelName">面板名</param>
    /// <param name="widgetName">子控件名</param>
    /// <returns>返回该子控件身上的text组件</returns>
    public Text GetText(string panelName,string widgetName)
    {
        UIBehaviors tmpBehavior = GetBehavior(panelName ,widgetName);
        if (tmpBehavior)
        {
            return tmpBehavior.GetComponent<Text>();
        }
        return null;
    }

    #endregion 对panel或者子控件本身的操作

    #region 对子控件身上的组件进行操作
    /// <summary>
    /// 监听按钮控件
    /// </summary>
    /// <param name="widgetName">子控件名称</param>
    /// <param name="action">子控件事件</param>
    public void AddButtonListen(string widgetName, UnityAction action)
    {
        UIBehaviors tmpBehavior = GetBehavior(widgetName);
        if (tmpBehavior)
        {
            //绑定事件
            tmpBehavior.AddButtonListen(action);
        }
    }
    /// <summary>
    /// 监听输入框控件输入的内容
    /// </summary>
    /// <param name="widgetName">子控件名称</param>
    /// <param name="action">对子控件的操作</param>
    public void AddInputFieldListen(string widgetName, UnityAction<string> action)
    {
        UIBehaviors tmpBehavior = GetBehavior(widgetName);
        if (tmpBehavior)
        {
            tmpBehavior.AddInputFieldListen(action);
        }
    }

    #endregion 对子控件身上的组件进行操作


}
