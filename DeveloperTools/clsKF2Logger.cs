using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperTools
{
    /// <summary>
    /// Event driven logger class for read/writes
    /// </summary>
    public class clsKF2Logger
    {
        /// <summary>
        /// delegate used by client classes
        /// </summary>
        public delegate void UpdateHandler();

        static event UpdateHandler UpdateLogEvent;

        /// <summary>
        /// Structure used to contain the event details
        /// </summary>
        public struct stEventObject
        {
            /// <summary>
            /// Shows the direction of the data
            /// </summary>
            public string Direction;

            /// <summary>
            /// description of the data
            /// </summary>
            public string Data;
        }

        static List<stEventObject> m_Events = new List<stEventObject>();
        static string m_Log;

        /// <summary>
        /// This will get called each time an event is added
        /// </summary>
        /// <param name="target"></param>
        static public void AddEventHandler(UpdateHandler target)
        {
            UpdateLogEvent += target;
        }

        /// <summary>
        /// This should be called to correctly remove your event
        /// </summary>
        /// <param name="target"></param>
        static public void RemoveEventHandler(UpdateHandler target)
        {
            UpdateLogEvent -= target;
        }

        /// <summary>
        /// Called by the communications module to add a new event and trigger the handlers
        /// </summary>
        /// <param name="sEventString"></param>
        static public void AddEvent(stEventObject sEventString)
        {
            m_Events.Add(sEventString);
            if (UpdateLogEvent != null)
            {
                UpdateLogEvent();
            }
        }

        /// <summary>
        /// Clears all previous events from the internal store
        /// </summary>
        static public void Clear()
        {
            m_Events.Clear();
            m_Log = "";
            UpdateLogEvent();
        }

        /// <summary>
        /// Added a text item to the trace log
        /// </summary>
        /// <param name="sText"></param>
        static public void AddLog(string sText)
        {
            m_Log += sText + "\r\n";
        }

        /// <summary>
        /// Gets all events logged 
        /// </summary>
        /// <returns></returns>
        static public List<stEventObject> GetEvents()
        {
            return m_Events;
        }

        /// <summary>
        /// Gets the trace log
        /// </summary>
        /// <returns></returns>
        static public string GetLog()
        {
            return m_Log;
        }
    }
}
