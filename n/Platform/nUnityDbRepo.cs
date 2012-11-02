using System;
using System.Collections.Generic;
using System.Linq;
using n.App;

namespace n.Platform
{
	/** 
	 * This class should be implemented by a platform specific binding that
	 * can perform the various required crud operations on records.
   * <p>
   * Do not extend this class to create a repository; inject it as a 
   * dependency or use it directly instead of a custom repository.
	 */
	public abstract class nDbRepo
	{
		protected nDb _db;

		public nDbRepo (nDb connectionFactory)
		{
			_db = connectionFactory;
		}

		/** Save this record, performing an insert if required */
		public bool Save(nDbRecord instance)
		{
			instance.Validate();
			var success = instance.Valid;
			if (success) success = SaveInstance(instance);
			return success;
		}

		/** Delete this record, if it exists */
		public bool Delete (nDbRecord instance)
		{
			var success = DeleteInstance(instance);
			return success;
		}

		/** Return a set of type instances */
		public abstract IEnumerable<T> Query<T>(string query, object bindings);

		/** Invoke a query with no return value (eg. CREATE TABLE) */
		public abstract void Query(string query, object bindings);

		/** Return a set of type instances */
		public abstract IEnumerable<T> All<T>(string table, int limit, int offset);

		/** Return a single type instance */
		public abstract T Get<T>(string table, string key, int id);

		/** Return the count of instances */
		public abstract int Count(string table);

		/** Should be implemented to save instances of the given type */
		public abstract bool SaveInstance(nDbRecord instance);

		/** Should be implemented to delete instances of the given type */
		public abstract bool DeleteInstance(nDbRecord instance);
	}
}

