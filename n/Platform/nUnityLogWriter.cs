using System;

namespace n.Platform
{
	public class nUnityLogWriter : nLogWriter
	{
    public void Trace (string message)
    {
      throw new NotImplementedException ();
    }
    public void Error (string message, Exception e)
    {
      throw new NotImplementedException ();
    }
	}
}

