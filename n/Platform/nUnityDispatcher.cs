using System;
using UnityEngine;

namespace n.Platform
{
	/** The domain specific implementation should use a View to navigate to a new activity */
	public class nUnityDispatcher : nDispatcher
	{
    public void Dispatch (nView view)
    {
      var id = view.Action.Id;
      Application.LoadLevel(id);
    }
	}
}

