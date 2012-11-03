using System;
using n.Platform.Db;

namespace n.Platform
{
  public class nUnityBinding
	{
    public static void Bind(nResolver resolver) {
      resolver.Bind<nContext, nUnityContext>();
      resolver.Bind<nDispatcher, nUnityDispatcher>();
      resolver.Bind<nLogWriter, nUnityLogWriter>();
      #if UNITY_WEBPLAYER
        resolver.Bind<nDb, CookieRepo>();
      #else
        resolver.Bind<nDb, SqliteRepo>();
      #endif
    }
	}
}

