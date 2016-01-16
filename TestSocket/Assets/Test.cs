using Assets.clientevent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    public class Test
    {

        public void addEventListener()
        {
            SocketManager.getIns().addEventListener(Events.LOG_IN_EVENT, TestPrint);  
        }

        public void TestPrint(NadEvent evt)
        {
            Debug.Log("Test Events Send....,event string :"+evt.getType());
        }
    }
}
