using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.clientevent.impl
{
    /**
   * ...
   * @author Abraham Menacherry
   */
    public class DefaultEvent : NadEvent
    {

        private int nEventType;
        private object source;
        private double timestamp;



        public int getType()
        {
            return nEventType;
        }

        public void setType(int type)
        {

            this.nEventType = type;

        }

        public object getSource()
        {
            return source;
        }

        public void setSource(object eventSource)
        {

            this.source = eventSource;

        }

        public double getTimestamp()
        {
            return timestamp;
        }

        public void setTimestamp(double eventTimestamp)
        {

            this.timestamp = eventTimestamp;

        }
    }

}
