using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.clientevent
{
    /**
        * ...
        * @author Abraham Menacherry
        */
    public interface NadEvent
    {
        int getType();
        void setType(int type);
        object getSource();
        void setSource(object source);
        double getTimestamp();
        void setTimestamp(double timestamp);
    }
}
   