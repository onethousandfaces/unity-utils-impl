using System;

namespace n.Platform
{
	/** The platform bindings should implement this to provide data connectivity */
	public interface nDb
	{
		T Connection<T>();	
	}
}

