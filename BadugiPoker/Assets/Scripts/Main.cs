using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Assets.Scripts.clientevent;
using System.IO;
using ProtoBuf.Meta;
using ProtoBuf;
using com.inkstd.badugi.model;

public class Main : MonoBehaviour {
	private Text Tips;

	private string tipsstr;

	// Use this for initialization
	void Start () {
        
		//SocketManager.getIns ().Start ();
		SocketManager.getIns ().addEventListener(Events.START_EVENT, onConnect);
		SocketManager.getIns ().ConnectToServer ();
		if (!Tips) {
			Tips = GameObject.Find ("Logo/Tips").GetComponent<Text> ();
		    
		}
		//Tips.text="Hello World!!!!";
	}
	
	// Update is called once per frame
	void Update () {
		if (tipsstr != null) {
		
			Tips.text = tipsstr;
		}
	
	}
    
    
    public void onConnect(NadEvent evt)
	{
		tipsstr = "已经连接到游戏服务器";
		Debug.Log("Connect game server,event string :"+evt.getType());
	}
}
