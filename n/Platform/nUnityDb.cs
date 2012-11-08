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
using n.App;
using System.Collections.Generic;
using System.Linq;

namespace n.Platform.Db
{
  public class nUnityDb : nDb
  {
    private IDbContainer _dbc;
    
    private RecordSerializer _rs;
  
    public nUnityDb (IDbContainer container)
    {
      _dbc = container;
      _rs = new RecordSerializer();
    }

    private string Key (Type t)
    {
      return "nUnityDbRecordSet."+t.FullName;
    }

    private IList<nDbRecord> Load (Type t)
    {
      var key = Key (t);
      if (_dbc.Exists (key)) {
        var block = _dbc.Get(key);
        var records = _rs.Deserialize(t, block);
        return records;
      }
      else
        return default(List<nDbRecord>);
    }

    private void Save(Type t, IList<nDbRecord> all) 
    {
      var key = Key(t);
      var block = _rs.Serialize(t, all);
      _dbc.Set(key, block);
    }

    public int Count<T> () where T : n.App.nDbRecord
    {
      var all = Load(typeof(T));
      return all.Count();
    }

    public bool Setup<T> () where T : n.App.nDbRecord
    {
      return true;
    }

    public bool Insert (n.App.nDbRecord record)
    {
      var all = Load(record.GetType());
      all.Add(record);
      Save(record.GetType(), all);
      return true;
    }

    public bool Update (n.App.nDbRecord record)
    {
      var all = Load(record.GetType());
      if (!all.Contains(record))
        all.Add(record);
      Save(record.GetType(), all);
      return true;
    }

    public bool Delete (n.App.nDbRecord record)
    {
      var all = Load (record.GetType ());
      if (all.Contains (record)) {
        all.Remove (record);
        Save(record.GetType(), all);
      }
      return true;
    }

    public T Get<T> (long id) where T : n.App.nDbRecord
    {
      var all = Load(typeof(T));
      var rtn = from a in all where a.Id == id select a;
      return (T) rtn.FirstOrDefault();
    }

    public IEnumerable<T> All<T> (long offset, long limit) where T : n.App.nDbRecord
    {
      var all = Load(typeof(T));
      var rtn = (from a in all select a).Skip((int) offset).Take((int) limit);
      return (IEnumerable<T>) rtn.ToList ();
    }

    public void Clear<T> () where T : n.App.nDbRecord
    {
      var all = default(List<nDbRecord>);
      Save(typeof(T), all);
    }
  }
}

