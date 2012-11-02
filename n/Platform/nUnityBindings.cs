using System;

namespace n.Platform
{
  public class nUnityBindings
	{
    public static void Bind(nResolver resolver) {
      resolver.Bind<nContext, nUnityContext>();
      resolver.Bind<nDb, nUnityDb>();
      resolver.Bind<nDispatcher, nUnityDispatcher>();
      resolver.Bind<nLogWriter, nUnityLogWriter>();
    }
	}
}

