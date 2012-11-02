using System;

namespace n.Platform
{
	/** The platform bindings should implement this to provide data connectivity */
	public class nUnityDb : nDb
	{
    public bool Setup<T> () where T : n.App.nDbRecord
    {
      throw new NotImplementedException ();
    }
    public bool Insert (n.App.nDbRecord record)
    {
      throw new NotImplementedException ();
    }
    public bool Update (n.App.nDbRecord record)
    {
      throw new NotImplementedException ();
    }
    public bool Delete (n.App.nDbRecord record)
    {
      throw new NotImplementedException ();
    }
    public T Get<T> (long id) where T : n.App.nDbRecord
    {
      throw new NotImplementedException ();
    }
    public System.Collections.Generic.IEnumerable<T> All<T> (long offset, long limit) where T : n.App.nDbRecord
    {
      throw new NotImplementedException ();
    }
    public void Clear<T> () where T : n.App.nDbRecord
    {
      throw new NotImplementedException ();
    }
	}
}

