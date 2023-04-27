using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreatePanelController : UIBase
{
    /// <summary>
    /// 当前选择的角色
    /// </summary>
    private GameObject selectedChar;

    public GameObject[] charArray;
    public GameObject[] charSelectedArray;


    private void Start()
    {
        AddButtonListen(UIType.CSP_btn_Return, OnButtonReturnClick);
        AddButtonListen(UIType.CSP_btn_Confirm, OnButtonConfirmClick);
    }
    private void Update()
    {
        CharSelect();
    }

    /// <summary>
    /// 选择角色
    /// </summary>
    public void OnCharacterClick(GameObject charGO)
    {
        if (charGO == selectedChar)
        {
            return;
        }
        charGO.transform.localScale = new Vector3(500, 500, 500);
        if (selectedChar != null)
        {
            selectedChar.transform.localScale = new Vector3(400, 400, 400);
        }
        selectedChar = charGO;
    }


    /// <summary>
    /// 使用射线检测获取物体
    /// </summary>
    public void CharSelect()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            bool res = Physics.Raycast(ray, out hit);
            if (res == true)
            {
                OnCharacterClick(hit.transform.gameObject);
            }
        }
    }

    /// <summary>
    /// 点击返回按钮
    /// </summary>
    public void OnButtonReturnClick()
    {
        UIManager.Instance.SetActive(UIType.CSP, false);
        UIManager.Instance.SetActive(UIType.CP, true);
    }

    /// <summary>
    /// 点击确认按钮
    /// </summary>
    public void OnButtonConfirmClick()
    {
        //判断姓名输入是否正确
        //判断是否选择角色
        //TODO

        int index = -1;
        for (int i = 0; i < charArray.Length; i++)
        {
            if (selectedChar == charArray[i])
            {
                index = i;
                break;
            }

        }
        if (index == -1)
        {
            return;
        }
        GameObject tmpPosObj = UIManager.Instance.GetWidget(UIType.CP, UIType.CP_CharPos);
        //删除原来的选择的角色
        Destroy(tmpPosObj.GetComponentInChildren<Animator>().gameObject);
        //实例化选择的角色
        GameObject tmpObj = Instantiate(charSelectedArray[index], Vector3.zero, Quaternion.identity);
        tmpObj.transform.SetParent(UIManager.Instance.GetWidget(UIType.CP, UIType.CP_CharPos).transform);
        tmpObj.transform.localPosition = Vector3.zero;
        tmpObj.transform.localRotation = Quaternion.identity;
        tmpObj.transform.localScale = Vector3.one;

        //更新角色名字和等级
        GetText(UIType.CP, UIType.CP_txt_CharName).text = GetInputField(UIType.CSP_inp_CharName).text;
        GetText(UIType.CP, UIType.CP_txt_CharLevel).text = "lv.1";

        OnButtonReturnClick();
    }
}
