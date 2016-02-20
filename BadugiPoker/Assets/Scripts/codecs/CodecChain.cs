namespace Assets.Scripts.codecs.impl
{

    /**
	 * This interface represents a chain of transformers. 
	 * It will store them in a chain i.e. an Array. Can be 
	 * considered like a composite transform which wraps other 
	 * transforms inside it.
	 * @author Abraham Menacherry
	 */
    public interface CodecChain : Transform
    {
        void add(Transform next);
        void remove(Transform next);
    }

}