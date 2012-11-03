using System;
using UnityEngine;

namespace n.Platform
{
	public class nUnityLogWriter : nLogWriter
	{
    public void Trace (string message)
    {
      Debug.Log(message);
    }

    public void Error (string message, Exception e)
    {
      var msg = String.Format("{0}:\n{1}\n\n:{2}", message, e.ToString(), e.StackTrace.ToString());
      Debug.LogError(msg);
    }
	}
}

