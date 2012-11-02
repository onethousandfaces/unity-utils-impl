using System;

namespace n.Platform
{
	/** The domain specific implementation should use a View to navigate to a new activity */
	public interface nDispatcher
	{
		/** Launch the acitivity that view refers to, if any */
		void Dispatch(nView view);
	}
}

