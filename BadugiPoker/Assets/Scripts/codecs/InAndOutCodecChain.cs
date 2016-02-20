namespace Assets.Scripts.codecs.impl
{
    /**
	 * A utility interface which has methods to set and get the codec chains.
	 * @author Abraham Menacherry
	 */
    public interface InAndOutCodecChain
    {
        CodecChain getInCodecs();
        void setInCodecs(CodecChain inCodecs);
        CodecChain getOutCodecs();
		void setOutCodecs(CodecChain outCodecs);
	}
}