using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ServerPanelController : UIBase
{
    /// <summary>
    /// 是否初始化服务器列表。服务器列表只在游戏开始时初始化一次。
    /// </summary>
    private bool haveInitServerList = false;

    public static ServerProperty sp;

    protected override void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
        InitServerList();
        AddButtonListen(UIType.SP_btn_ServerSelected, ServerPanelClose);
        //On();
        
    }

    /// <summary>
    /// 初始化服务器列表
    /// </summary>
    public void InitServerList()
    {
        if (haveInitServerList)
        {
            return;
        }

        //连接服务器，取得游戏服务器列表信息
        //TODO
        //根据上面的信息，添加服务器列表
        for (int i = 0; i < 7; i++)
        {
            string _ip = "127.0.0.1:7878";
            //string _name = i + 1 + "区 马达加斯加";
            int _count = Random.Range(0, 100);
            GameObject go;
            GameObject tmpGO;
            if (_count > 50)
            {
                //火爆
                //将服务器按钮设置为滚动视图的子对象
                go = Resources.Load<GameObject>(ResourcesPath.UI_btn_ServerRed_Path);
                tmpGO = Instantiate(go, transform.Find("sv_ServerList/Viewport/Content_Server_N1"));
                //tmpGO.name = tmpGO.name.Replace("(Clone)", "").Trim();
                tmpGO.name = "btn_Server_" + i + 1 + "_N1";
                tmpGO.GetComponentInChildren<Text>().text = i + 1 + "区 马达加斯加";
            }
            else
            {
                //流畅
                go = Resources.Load<GameObject>(ResourcesPath.UI_btn_ServerGreen_Path);
                tmpGO = Instantiate(go, transform.Find("sv_ServerList/Viewport/Content_Server_N1"));
                //tmpGO.name = tmpGO.name.Replace("(Clone)", "").Trim();
                tmpGO.name = "btn_Server_" + i + 1 + "_N1";
                tmpGO.GetComponentInChildren<Text>().text = i + 1 + "区 马达加斯加";
            }
            if (!tmpGO.GetComponent<UIBehaviors>())
            {
                tmpGO.AddComponent<UIBehaviors>();
            }
            ServerProperty sp = go.GetComponent<ServerProperty>();
            sp._ip = _ip;
            sp._name = tmpGO.GetComponentInChildren<Text>().text;
            sp._count = _count;

        }
        haveInitServerList = true;
    }


    //public void OnServerSelect(GameObject serverGo)
    //{
    //    sp = serverGo.GetComponent<ServerProperty>();
    //    //获取最上边的按钮，并将其背景和文字修改为所点击的按钮的背景和文字
    //    GameObject tmpObj = GetWidget(UIType.SP_btn_ServerSelected);
    //    tmpObj.GetComponent<Image>().sprite = serverGo.GetComponent<Image>().sprite;
    //    tmpObj.GetComponentInChildren<Text>().text = serverGo.GetComponentInChildren<Text>().text;
    //    tmpObj.GetComponentInChildren<Text>().color = serverGo.GetComponentInChildren<Text>().color;
    //}

    ////获取点击的按钮，该按钮，必须是被点击的
    ////将按钮传递到方法中
    //public void On()
    //{
    //    GameObject o = EventSystem.current.currentSelectedGameObject;
    //    o.GetComponent<Button>().onClick.AddListener(() => { OnServerSelect(o); });
    //}


    /// <summary>
    /// 关闭Server面板
    /// </summary>
    public void ServerPanelClose()
    {
        UIManager.Instance.SetActive(UIType.SMP, true);
        gameObject.SetActive(false);

        //更改相应面板上对应的内容
        GetText(UIType.SMP, UIType.SMP_txt_Server).text = GetWidget(UIType.SP_btn_ServerSelected).GetComponentInChildren<Text>().text;
        //GetText(UIType.SMP, UIType.SMP_txt_Server).color = GetWidget(UIType.SP_btn_ServerSelected).GetComponentInChildren<Text>().color;

    }
}
