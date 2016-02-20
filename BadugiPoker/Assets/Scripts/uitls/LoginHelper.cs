using Assets.Scripts.clientevent;
using Assets.Scripts.communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.uitls
{
    public class LoginHelper
    {
        private string username;
		private string password;
		private object connectionKey;
		private string remoteHost;
		private int remotePort;
		
		public  LoginHelper( string username, string password,object connectionKey,
                       string remoteHost,int remotePort = 18090)
        {
            this.username = username;
            this.password = password;
            this.connectionKey = connectionKey;
            this.remoteHost = remoteHost;
            this.remotePort = remotePort;
        }

        public NadEvent getLoginEvent()
		{
            MessageBuffer loginBuffer = new MessageBuffer(new List<byte>());
            string[] args= { username, password, connectionKey.ToString()};
			loginBuffer.writeMultiStrings(args);
			return Events.convertEvent(Events.LOG_IN, loginBuffer);
        }

        public string getRemoteHost()
		{
			return remoteHost;
		}

        public int  getRemotePort()
		{
			return remotePort;
		}
    }
}
