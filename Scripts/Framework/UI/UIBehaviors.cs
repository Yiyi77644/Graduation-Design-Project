using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UIBehaviors : MonoBehaviour
{
    private void Awake()
    {
        UIBase tmpBase = transform.GetComponentInParent<UIBase>();
        UIManager.Instance.RegisteGameObject(tmpBase.name, transform.name, gameObject);
       
    }

    #region 逻辑
    /// <summary>
    /// 子控件如果有Button组件，则监听Button。
    /// </summary>
    /// <param name="action">button的事件</param>
    public void AddButtonListen(UnityAction action)
    {
        Button tmpButton = GetComponent<Button>();
        if (tmpButton)
        {
            tmpButton.onClick.AddListener(action);
        }
    }
    /// <summary>
    /// 子控件如果有InputField组件，则监听InputField。
    /// </summary>
    /// <param name="action">inputField的事件</param>
    public void AddInputFieldListen(UnityAction<string> action)
    {
        InputField tmpInputField = GetComponent<InputField>();
        if (tmpInputField)
        {
            tmpInputField.onValueChanged.AddListener(action);
        }
    }
    /// <summary>
    /// 子控件如果有Text组件，则监听Text。
    /// </summary>
    /// <param name="content">向Text输入的内容</param>
    public void AddChangeTextContextListen(string content)
    {
        Text tmpText = GetComponent<Text>();
        if (tmpText != null)
        {
            tmpText.text = content;
        }
    }

    #endregion 逻辑
}
