using Assets.uitls;
using System.Collections.Generic;

namespace Assets.codecs.impl
{
    public class LengthFieldPrepender : Transform
    {
        public  LengthFieldPrepender()
        {

        }

        public object transform(object input)
		{
			byte[] message = input as byte[];
			List<byte> buffer = new List<byte>();
            ushort len = System.UInt16.Parse(message.Length.ToString());
            byte[] lenbytes = System.BitConverter.GetBytes(BytesHelper.ReverseBytes(len));
            buffer.AddRange(lenbytes);
			buffer.AddRange(message);
			return buffer.ToArray();
		}
}
}