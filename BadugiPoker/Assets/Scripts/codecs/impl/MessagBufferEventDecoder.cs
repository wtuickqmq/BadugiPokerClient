using Assets.Scripts.clientevent;
using Assets.Scripts.communication;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;


namespace Assets.Scripts.codecs.impl
{
    public class MessagBufferEventDecoder : Transform
    {


        public  MessagBufferEventDecoder()
        {

        }

        /* INTERFACE io.nadron.codecs.Transform */

        public object transform(object input) 
		{
            byte[] message = input as byte[];
           
            
            //List<byte> headbytes = message.GetRange(0,1);

            int eventType = message[0]; //System.BitConverter.ToInt32(headbytes.ToArray(), 0); ;
			if (eventType == Events.NETWORK_MESSAGE) 
			{
				eventType = Events.SESSION_MESSAGE;
			}
            MessageBuffer buffer = new MessageBuffer(message.Skip(1).ToList<byte>());
            NadEvent events = Events.convertEvent(eventType, buffer);
			return events;
    }


}
}