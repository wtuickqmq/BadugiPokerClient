using Assets.clientevent.impl;
using Assets.uitls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.clientevent
{
    public class Events:DefaultEvent
    {
        // protocl version
        public static int JET_PROTOCOL = 0x01;
        // Lifecycle events.
        public static int CONNECT = 0x02;
        public static string CONNECT_EVENT = "JET-CONNECT";
        public static int CONNECT_FAILED = 0x06;
        public static string CONNECT_FAILED_EVENT = "JET-CONNECT-FAILED";
        public static int LOG_IN = 0x08;
        public static string LOG_IN_EVENT = "JET-LOG-IN";
        public static int LOG_OUT = 0x0a;
        public static string LOG_OUT_EVENT = "JET-LOG-OUT";
        public static int LOG_IN_SUCCESS = 0x0b;
        public static string LOG_IN_SUCCESS_EVENT = "JET-LOG-IN-SUCCESS";
        public static int LOG_IN_FAILURE = 0x0c;
        public static string LOG_IN_FAILURE_EVENT = "JET-LOG-IN-FAILURE";
        public static int LOG_OUT_SUCCESS = 0x0e;
        public static string LOG_OUT_SUCCESS_EVENT = "JET-LOG-OUT-SUCCESS";
        public static int LOG_OUT_FAILURE = 0x0f;
        public static string LOG_OUT_FAILURE_EVENT = "JET-LOG-OUT-FAILURE";

        // Metadata events
        public static int GAME_LIST = 0x10;
        public static string GAME_LIST_EVENT = "JET-GAME-LIST";
        public static int ROOM_LIST = 0x12;
        public static string ROOM_LIST_EVENT = "JET-ROOM-LIST";
        public static int GAME_ROOM_JOIN = 0x14;
        public static string GAME_ROOM_JOIN_EVENT = "JET-GAME-ROOM-JOIN";
        public static int GAME_ROOM_LEAVE = 0x16;
        public static string GAME_ROOM_LEAVE_EVENT = "JET-GAME-ROOM-LEAVE";
        public static int GAME_ROOM_JOIN_SUCCESS = 0x18;
        public static string GAME_ROOM_JOIN_SUCCESS_EVENT = "JET-GAME-ROOM-JOIN-SUCCESS";
        public static int GAME_ROOM_JOIN_FAILURE = 0x19;
        public static string GAME_ROOM_JOIN_FAILURE_EVENT = "JET-GAME-ROOM-JOIN-FAILURE";

        /**
		 * Event sent from server to client to start message sending from client to server.
		 */
        public static int START = 0x1a;
        public static string START_EVENT = "JET-START";
        /**
		 * Event sent from server to client to stop messages from being sent to server.
		 */
        public static int STOP = 0x1b;
        public static string STOP_EVENT = "JET-STOP";
        /**
		 * Incoming data from another machine/JVM to this JVM (server or client)
		 */
        public static int SESSION_MESSAGE = 0x1c;
        public static string SESSION_MESSAGE_EVENT = "JET-SESSION-MESSAGE";

        /**
		 * Outgoing data from the client to jetserver.
		 */
        public static int NETWORK_MESSAGE = 0x1d;
        public static string NETWORK_MESSAGE_EVENT = "JET-NETWORK-MESSAGE";
        public static int CHANGE_ATTRIBUTE = 0x20;
        public static string CHANGE_ATTRIBUTE_EVENT = "JET-CHANGE-ATTRIBUTE";

        /**
		 * If a remote connection is disconnected or closed then raise this event.
		 */
        public static int DISCONNECT = 0x22;
        public static string DISCONNECT_EVENT = "JET-DISCONNECT";
        public static int EXCEPTION = 0x24;
        public static string EXCEPTION_EVENT = "JET-EXCEPTION";

        public static Dictionary<int, string> EVENT_LOOKUP_MAP = new Dictionary<int, string>
         {
                {CONNECT,CONNECT_EVENT },
                {CONNECT_FAILED,CONNECT_FAILED_EVENT },
                {LOG_IN,LOG_IN_EVENT },
                {LOG_OUT,LOG_OUT_EVENT},
                {LOG_IN_SUCCESS,LOG_IN_SUCCESS_EVENT},
                {LOG_IN_FAILURE,LOG_IN_FAILURE_EVENT},
                {LOG_OUT_SUCCESS,LOG_OUT_SUCCESS_EVENT},
                {LOG_OUT_FAILURE,LOG_OUT_FAILURE_EVENT},
                {GAME_LIST,GAME_LIST_EVENT},
                {ROOM_LIST,ROOM_LIST_EVENT},
                {GAME_ROOM_JOIN,GAME_ROOM_JOIN_EVENT},
                {GAME_ROOM_LEAVE,GAME_ROOM_LEAVE_EVENT},
                {GAME_ROOM_JOIN_SUCCESS,GAME_ROOM_JOIN_SUCCESS_EVENT},
                {GAME_ROOM_JOIN_FAILURE,GAME_ROOM_JOIN_FAILURE_EVENT},
                {START,START_EVENT},
                {STOP,STOP_EVENT},
                {SESSION_MESSAGE,SESSION_MESSAGE_EVENT},
                {NETWORK_MESSAGE,NETWORK_MESSAGE_EVENT},
                {CHANGE_ATTRIBUTE,CHANGE_ATTRIBUTE_EVENT},
                {DISCONNECT,DISCONNECT_EVENT},
                {EXCEPTION,EXCEPTION_EVENT}
         };

        public static string convertEventTypeToString(int eventType)
        {
            return EVENT_LOOKUP_MAP[eventType];
        }
        /**
         * Creates a NadEvent instance using the integer event type and the source.
         * @param	eventType
         * @param	source
         * @return
         */
        public static NadEvent convertEvent(int eventType, object source)
        {
            string dispatchEventType = convertEventTypeToString(eventType);
            DefaultEvent nEvent = new DefaultEvent();
            nEvent.setSource(source);
            nEvent.setType(eventType);
            nEvent.setTimestamp(DateUtils.GetTimeStamp());
            return nEvent;
        }



    }


}

