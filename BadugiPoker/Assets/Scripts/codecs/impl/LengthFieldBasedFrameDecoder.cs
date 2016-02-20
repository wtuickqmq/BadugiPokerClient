using Assets.Scripts.uitls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assets.Scripts.codecs.impl
{
    public class LengthFieldBasedFrameDecoder : Transform
    {
        private int lengthFieldLength;
		private bool lengthRead;
		private ushort length;
		private List<byte> message;
		private int currentReadLength;
		
		public LengthFieldBasedFrameDecoder(int lengthFieldLength = 2)
        {
            lengthRead = false;
            length = 0;
            this.lengthFieldLength = lengthFieldLength;
            message = new List<byte>();
        }

        public object transform(object input) 
		{
          
            byte[] bytes = input as byte[];
            if(bytes.Length>=lengthFieldLength)
            {
                byte[] headbytes = new byte[2];
                headbytes[0] = bytes[0];
                headbytes[1] = bytes[1];
                length = BitConverter.ToUInt16(headbytes, 0);
                length = BytesHelper.ReverseBytes(length);
                if (bytes.Length>=length+lengthFieldLength)
                {

                    byte[] result = bytes.Skip(lengthFieldLength).Take(length).ToArray();
                    return result;
                }
                return null;

            }
            return null;
        }
    }
}