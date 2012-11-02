//
//  Copyright 2012  douglasl
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
using System;

namespace n.Platform.Db
{
  public class CookieRepo : nDb
  {
    public int Count<T> () where T : n.App.nDbRecord
    {
      throw new NotImplementedException ();
    }

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

