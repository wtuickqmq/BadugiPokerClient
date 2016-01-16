using System;
using System.Collections;

namespace Assets.codecs.impl
{
     class DefaultCodecChain : CodecChain
    {
        private ArrayList chain;
		
		public DefaultCodecChain()
        {
            chain = new ArrayList();
        }

        public void add(Transform next)
		{
			chain.Add(next);
		}

        public void remove(Transform next)
		{
			chain.RemoveAt(chain.IndexOf(next));
		}

/**
 * Can be considered to be a composite method, which will call transform on all the 
 * component transformers in the array and then return the final decoded or encoded object.
 * 
 * @param	input An object that needs to be transformed to another.
 * @return The transformed object. If any transformer within the chain cannot transform the 
 * 			object passed in to it, the it will return null and the method will also return null.
 */
        public object transform(object input)
		{
           
            foreach(Transform item in chain){
                object output = item.transform(input);
                if (null == output)
                {
                    return null;
                }
                else {
                    input = output;
                }
            }
			return input;
		}
		
		public ArrayList getChain()
		{
			return chain;
		}
    }
}