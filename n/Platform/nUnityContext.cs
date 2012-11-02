using System;

namespace n.Platform
{
  /** Generic platform specific handle to hold context information */
	public class nUnityContext : nContext
	{
    /** Return a platform specific context object */
    public T Get<T>() {
      return default(T);
    }
	}
}

