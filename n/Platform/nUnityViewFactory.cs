using System;

namespace n.Platform
{
  /** Factory to create view instances for the platform implementation. */
	public interface nViewFactory
	{
    /** Blank view that does nothing except return success */
    nView View();
    
		/** View for navigating somewhere */
    nView View(Type target, nContext context);

    /** View that returns data */
    nView View(object model, nContext context);
    
    /** View that is just an error */
    nView Failed(string message);
    
    /** View that is an error and exception */
    nView Failed(string message, Exception e);
	}
}

