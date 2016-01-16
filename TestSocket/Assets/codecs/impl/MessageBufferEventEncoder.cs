using Assets.clientevent;
using Assets.communication;
using System.Collections.Generic;

namespace Assets.codecs.impl
{
    public class MessageBufferEventEncoder : Transform
    {
        public MessageBufferEventEncoder()
        {

        }

        public object transform(object input)
        {
            NadEvent evt = (NadEvent)input;
            List<byte> byteslist = new List<byte>();

            int opCode = evt.getType();

            byte[] opbytes = System.BitConverter.GetBytes(opCode);
            byteslist.Add(opbytes[0]);
            //byteslist.AddRange(opbytes);

            if (opCode == Events.LOG_IN)
            {
                byte[] prbytes = System.BitConverter.GetBytes(Events.JET_PROTOCOL);
                byteslist.Add(prbytes[0]);
               // byteslist.AddRange(prbytes);
            }


            MessageBuffer messageBuffer = evt.getSource() as MessageBuffer;
            byteslist.AddRange(messageBuffer.getBuffer());

            return byteslist.ToArray();
        }
    }
}