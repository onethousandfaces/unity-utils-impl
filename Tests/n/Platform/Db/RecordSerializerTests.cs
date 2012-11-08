using UnityEngine;
using System.Collections;
using n.Test;
using System.Linq;
using System;
using System.Collections.Generic;
using n.Platform.Db;
using n.App;

namespace Tests.n.Platform.Db
{
  public class RecordSerializerTests : nTestBase 
  {
    private IList<MyDbRecordType> data() {
      var rtn = new List<MyDbRecordType>() {
        new MyDbRecordType() {
          Id = 1,
          Ref = null,
          Value1 = 1,
          Value2 = 1,
          Value3 = true,
          Value4 = 1,
          Value5 = "1",
          Value6 = "first",
          Value7 = DateTime.Now
        },
        new MyDbRecordType() {
          Id = 2,
          Ref = null,
          Value1 = 1,
          Value2 = 1,
          Value3 = true,
          Value4 = 1,
          Value5 = "1",
          Value6 = "second",
          Value7 = DateTime.Now
        },
        new MyDbRecordType() {
          Id = 3,
          Ref = null,
          Value1 = 1,
          Value2 = 1,
          Value3 = true,
          Value4 = 1,
          Value5 = "1",
          Value6 = "third",
          Value7 = DateTime.Now
        }
      };
      return rtn;
    }

    private RecordSerializer setup () {
      return new RecordSerializer();
    }
    
    [nTest]
    public void test_can_serialize() {
      var instance = setup();
      instance.ShouldNotBe(null);

      var d = data();
      d.ShouldNotBe(null);

      var sd = (IList<nDbRecord>) d;
      var block = instance.Serialize(typeof(MyDbRecordType), sd);
      block.ShouldNotBe(null);
    }

    
    [nTest]
    public void test_can_deserialize() {
      var instance = setup();
      instance.ShouldNotBe(null);
      
      var d = data();
      d.ShouldNotBe(null);

      var sd = (IList<nDbRecord>) d;
      var block = instance.Serialize(typeof(MyDbRecordType), sd);
      var objects = instance.Deserialize(typeof(MyDbRecordType), block);
      var records = (IEnumerable<MyDbRecordType>) objects;
      records.Count().ShouldBe(3);

      var first = (from s in records where s.Id == 1 select s).FirstOrDefault();
      var second = (from s in records where s.Id == 1 select s).FirstOrDefault();
      var third = (from s in records where s.Id == 1 select s).FirstOrDefault();

      first.ShouldNotBe(null);
      first.Value6.ShouldBe("first");

      second.ShouldNotBe(null);
      second.Value6.ShouldBe("second");
      
      third.ShouldNotBe(null);
      third.Value6.ShouldBe("third");
    }
  }
}
