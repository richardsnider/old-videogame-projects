using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public static class Log
    {
        public static Game Game { get; set; }
        public static StreamWriter StreamWriter { get; set; }
        public static ICollection<LogEntry> Logs { get; set; }

        public static void Initialize(Game game)
        {
            Game = game;
            StreamWriter = File.AppendText(Application.persistentDataPath + "/" + game.Id + ".log");
        }

        public static void Print(DateTime? startDate = null, DateTime? endDate = null, ICollection<string> searchTerms = null, ICollection<LogMessageType> types = null)
        {
            IQueryable<LogEntry> resultLogs = Logs.AsQueryable();

            if (startDate != null)
                resultLogs = resultLogs.Where(x => x.TimeStamp > startDate.Value);

            if (endDate != null)
                resultLogs = resultLogs.Where(x => x.TimeStamp < endDate.Value);

            if (searchTerms != null)
                resultLogs = resultLogs.Where(x => searchTerms.Any(y => x.Message.Contains(y)));

            if (types != null)
                resultLogs = resultLogs.Where(x => types.Contains(x.Type));

            var text = string.Join("/n", resultLogs.Select(x => x.ToString()).ToArray());
            Debug.Log(text);
        }

        public static void Add(string message, LogMessageType type)
        {
                Logs.Add(new LogEntry(message, type));
        }
    }

    public class LogEntry
    {
        public string Message { get; set; }
        public DateTime TimeStamp { get; private set; }
        public LogMessageType Type { get; set; }

        public LogEntry(string message, LogMessageType type)
        {
            Message = message;
            Type = type;
            TimeStamp = DateTime.UtcNow;
        }

        public override string ToString()
        {
            return Type + " (" + TimeStamp + "): " + Message;
        }
    }

    public enum LogMessageType
    {
        GuiError,
        InternalError
    }
}
