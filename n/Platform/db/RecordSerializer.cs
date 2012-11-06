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
using System.Collections.Generic;

namespace n.Platform.Db
{
  public class RecordSerializer
  {
    /** Turns an array of objects into a string */
    public string Serialize<T>(IEnumerable<T> items) {
      return default(string);
    }
    
    /** Turns a string into an array of objects */
    public IList<T> Deserialize<T>() {
      return default(List<T>);
    }
  }
}

