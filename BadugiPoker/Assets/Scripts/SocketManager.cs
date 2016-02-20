using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System;
using Assets.Scripts.uitls;
using Assets.Scripts.codecs.impl;
using Assets.Scripts.clientevent;
using System.Collections.Generic;
using Assets.Scripts;
using System.Linq;
using Assets.Scripts.communication;

public class SocketManager : MonoBehaviour {

    public string ipaddress = "127.0.0.1";
    public int port = 20001;

    private static SocketManager ins;
	private static GameObject container;
	private static Dictionary<String,Action<NadEvent>> netEvents=new Dictionary<string, Action<NadEvent>>();

    private Socket clientSocket;
    private Thread t;
    private byte[] data = new byte[1024];

    // Use this for initialization
    void Start () {
        // if (ins == null) ins = this;
       
        //ConnectToServer();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	/// <summary>
	/// 连接到游戏服务器
	/// </summary>
    public void ConnectToServer()
    {
        clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //服务器IP地址
        IPAddress ip = IPAddress.Parse(ipaddress);
        //服务器端口
        IPEndPoint ipEndpoint = new IPEndPoint(ip, port);

       // clientSocket.Connect(new IPEndPoint(IPAddress.Parse(ipaddress), port));
        //这是一个异步的建立连接，当连接建立成功时调用connectCallback方法
        IAsyncResult result = clientSocket.BeginConnect(ipEndpoint, new AsyncCallback(connectCallback), clientSocket);
        //这里做一个超时的监测，当连接超过5秒还没成功表示超时
        bool success = result.AsyncWaitHandle.WaitOne(5000, true);
        if (!success)
        {
            //超时
            //Closed();
            Debug.Log("connect Time Out");
        }
        else
        {
            //与socket建立连接成功，开启线程接受服务端数据。
            //worldpackage = new List<JFPackage.WorldPackage>();
            //Thread thread = new Thread(new ThreadStart(ReceiveSorket));
            t = new Thread(RecevieMessage);
            t.IsBackground = true;
            t.Start();
        }

       
    }
    void connectCallback(IAsyncResult asyncConnect)
    {
        if(clientSocket.Connected==true)
        {
            Debug.Log("connectSuccess");
            Debug.Log("Send Login info.....");
            LoginHelper loginHelper = new LoginHelper("user@service", "1000129", "user", ipaddress, port);
            LoginInOutCodecs loginCodecs = new LoginInOutCodecs();
            byte[] loginBytes = loginCodecs.getOutCodecs().transform(loginHelper.getLoginEvent()) as byte[];
            clientSocket.Send(loginBytes);
        }
      

    }
    
    void RecevieMessage()
    {
        while (true)
        {
            //在接收数据之前，判断socket连接是否断开
            if (clientSocket.Poll(10,SelectMode.SelectRead))
            {
                break;
            }
               
            //int length = clientSocket.Receive(data);
            //data 缓冲区默认为1024，一次性发送数据不应超过1024
            int length = clientSocket.Receive(data, data.Length, SocketFlags.None);
            //length 返回从系统缓冲实际读取的字节
            int readCount = 0;
            bool readEnd = false;
            if (length > 0)
            {

                do
                {
                    //本次实际读取字（可能包含多条命令）
                    byte[] msgbytes = data.Skip(readCount).Take(length).ToArray();
                    string msg = Encoding.UTF8.GetString(data, 0, length);
                    Debug.Log("Recevied Data length:" + length);
                    LoginInOutCodecs loginCodecs = new LoginInOutCodecs();


                    NadEvent nEvent = loginCodecs.getInCodecs().transform(msgbytes) as NadEvent;
                    if (null != nEvent)
                    {
                        /*
                            本次消息包含多条命令行
                            每条命令行包头为3个字节，
                            如果本次读取的（包头+包体），不大于等于socket消息长度，
                            说明还有消息存在，继续读取，
                        */
                        readCount += (3 + (nEvent.getSource() as MessageBuffer).getBuffer().Length);

                        if (length <= readCount)
                        {
                            readEnd = true;
                        }
                        else
                        {
                            //下条未读取消息的长度
                            length = length - readCount;
                        }
                        //本次消息派发（线程池启动派发）
                        ThreadPool.QueueUserWorkItem(dispatchEvent, nEvent);
                        
                    }
                    else
                    {
                        break;
                    }
                } while (!readEnd);
               
            }
            Debug.Log("Read network data...");
        // Decoding is not over, mostly because the whole frame  
        // was not received by the LengthFieldBasedFrameDecoder.
       }
    }
    private void dispatchEvent(object state)
    {
        dispatchEvent(state as NadEvent);
    }

    private void dispatchEvent(NadEvent events)
    {
        string cmd = Events.convertEventTypeToString(events.getType());
        foreach (KeyValuePair<string, Action<NadEvent>> item in netEvents)
        {
            if (item.Key.Equals(cmd))
            {
                Action<NadEvent> action=item.Value;
                action.Invoke(events);
                break;
            }
        }
    }



    //关闭Socket
    public void Closed()
    {

        if (clientSocket != null && clientSocket.Connected)
        {
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
        }
        clientSocket = null;
        //停止线程
        t.Abort();
    }
    public static SocketManager getIns()
    {
        if(ins==null)
        {
			ins = (SocketManager)GameObject.FindObjectOfType(typeof(SocketManager));  

			if (!ins) {  
				container = new GameObject();  
				container.name = "socketMgr";  
				ins= container.AddComponent(typeof(SocketManager)) as SocketManager; 

			}

            //ins = new SocketManager();
        }
        return ins;
    }
    public void addEventListener(string evt,Action<NadEvent> func)
    {
        Action<NadEvent> value=initEvents;
        foreach (KeyValuePair<string, Action<NadEvent>> item in netEvents)
        {
            if(item.Key.Equals(evt))
            {
                value += item.Value;
            }
        }
        value += func;
        netEvents.Add(evt, value);
    }
	public void removeEventListener(string evt)
	{
		netEvents.Remove (evt);
	}
    private void initEvents(NadEvent evt)
    {

        Debug.Log("init event handler");
    }

}
