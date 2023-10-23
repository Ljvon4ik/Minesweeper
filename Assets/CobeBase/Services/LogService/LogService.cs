using UnityEngine;

namespace CobeBase.Services.LogService
{
    public class LogService : ILogService
    {
        public void Log(string message)
        {
            Debug.Log(message);
        }
    }
}
