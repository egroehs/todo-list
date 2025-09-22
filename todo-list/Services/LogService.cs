using System;
using System.Collections.Generic;
using todo_list.Models;

namespace todo_list.Services
{
    public static class LogService
    {
        private static List<LogModel> _logs = new List<LogModel> ();

        public static void AdicionarLog(LogModel log)
        {
            _logs.Add(log);
        }

        public static IEnumerable<LogModel> ListarLogs()
        {
            return _logs.OrderByDescending(l => l.DataHora);
        }
    }
}

