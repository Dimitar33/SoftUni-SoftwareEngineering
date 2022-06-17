using System.Diagnostics;

namespace Task_5._Windows_Event_Log
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string eventLog = "Application";
            string eventSorce = "Logging demo";
            string eventMessage = "Hello";

            if (!EventLog.SourceExists(eventSorce))
            {
                EventLog.CreateEventSource(eventSorce, eventLog);
            }

            EventLog.WriteEntry(eventSorce, eventMessage);
        }
    }
}