using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.codecs.impl
{
    /**
         * The logging in process requires both writing to remote jetserver as well as reading from it. 
         * This set of in and out codecs will take care of transforming the events to be written and read 
         * from remote server.
         * @author Abraham Menacherry
         */
    public class LoginInOutCodecs : InAndOutCodecChain
    {

        private CodecChain inCodecs;
		private CodecChain outCodecs;
		
		public LoginInOutCodecs()
       {
        this.inCodecs = new DefaultCodecChain();
        this.outCodecs = new DefaultCodecChain();
        outCodecs.add(new MessageBufferEventEncoder());
        outCodecs.add(new LengthFieldPrepender());
        inCodecs.add(new LengthFieldBasedFrameDecoder());
        inCodecs.add(new MessagBufferEventDecoder());
        }

     public CodecChain getInCodecs()
		{
			return inCodecs;
		}

      public void setInCodecs(CodecChain inCodecs)
		{

            this.inCodecs = inCodecs;

        }

        public CodecChain getOutCodecs()
		{
			return outCodecs;
		}
		
		public void setOutCodecs(CodecChain outCodecs)
		{

            this.outCodecs = outCodecs;

        }
		
	}

}
