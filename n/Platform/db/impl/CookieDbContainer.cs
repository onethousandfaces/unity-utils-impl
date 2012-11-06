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

namespace n.Platform.Db.Impl
{
  /** Saves items as cookies in the browser */
  public class CookieDbContainer : IDbContainer {
  
    public void Set (string key, string value) {
    }
    
    public string Get (string key) {
      return default(string);
    }
    
    public bool Exists(string key) {
      return default(bool);
    }
  }
}

