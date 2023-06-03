using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerProperty : MonoBehaviour
{
    public string _ip = "127.0.0.1:7878";
    public string _name
    {
        get { return _name; }
        set
        {
            transform.Find("Text").GetComponent<Text>().text = value;
        }
    }

    public int _count = 100;

    private void Start()
    {

        this.GetComponent<Button>().onClick.AddListener(() => { OnServerSelect(this .gameObject); });
    }

    public void OnServerSelect(GameObject serverGo)
    {
        //获取最上边的按钮，并将其背景和文字修改为所点击的按钮的背景和文字
        GameObject tmpObj = GameObject.Find(UIType.SP_btn_ServerSelected).gameObject;
        tmpObj.GetComponent<Image>().sprite = serverGo.GetComponent<Image>().sprite;
        tmpObj.GetComponentInChildren<Text>().text = serverGo.GetComponentInChildren<Text>().text;
        tmpObj.GetComponentInChildren<Text>().color = serverGo.GetComponentInChildren<Text>().color;

    }

    public void OnPress(bool isPress)
    {
        if (isPress == false)
        {
            //选择了当前服务器
            transform.root.Find(UIType .SP).SendMessage("OnServerSelect", this.gameObject);
        }
    }

}
