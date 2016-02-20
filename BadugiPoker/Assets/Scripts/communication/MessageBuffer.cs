using Assets.Scripts.uitls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Assets.Scripts.communication
{
    public class MessageBuffer
    {
        private List<byte> buffer;
		
		public MessageBuffer(List<byte> byteArray)
        {
            if (null == byteArray)
            {
                buffer = new List<byte>();
            }
            else {
                buffer = byteArray;
            }
        }

        /**
		 * Writes multiple Strings to the underlying ByteArray. Each string is written as <length><bytes of string> 
		 * to the array since JetServer protocol expects it in this way.
		 * @param	... args
		 */
        public void writeMultiStrings(string[] args) {
			for (int i = 0; i<args.Length; i++) {
                writeString(args[i]);
            }
       }

/**
 * Each string is written as <length><bytes of string> to the array since Nadron Server protocol expects it in this way
 * @param	theString
 */
        public void writeString(string theString) {
	
            byte[] bText = System.Text.Encoding.GetEncoding("utf-8").GetBytes(theString.Trim());
            writeBytes(bText);
		}
		
		/**
		 * Reads the length and then the actual string of that length from the underlying buffer.
		 * @return
		 */
		public string readString() {
			byte[] utfBytes = readBytes();
            string str = null;
			if (utfBytes != null) {
				str = System.Text.Encoding.Default.GetString(utfBytes);
			}
			return str;
		}
		
		/**
		 * Writes bytes to the underlying buffer, with the length of the bytes prepended.
		 * @param	bytes
		 */
		public void writeBytes(byte[] bytes) {

        
         
            ushort len = System.UInt16.Parse(bytes.Length.ToString());
            byte[] lenbytes = System.BitConverter.GetBytes(BytesHelper.ReverseBytes(len));

            buffer.AddRange(lenbytes);
            buffer.AddRange(bytes);
            
		}
		
		public byte[] readBytes() {
            List<byte> headbytes = buffer.GetRange(0, 4);
            
            int len = System.BitConverter.ToInt32(headbytes.ToArray(), 0);
			List<byte> bytes = new List<byte>();
			if (len > 0) {
                buffer.RemoveRange(0, 4);
                bytes= buffer.GetRange(0,len);
			}
			return bytes.ToArray();
		}
		
		public byte[] getBuffer() {
			return buffer.ToArray();
		}
    }
}
