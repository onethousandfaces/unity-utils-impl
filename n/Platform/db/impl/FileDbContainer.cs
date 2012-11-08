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
using System.IO;

namespace n.Platform.Db.Impl
{
  /** Saves items as files in a data folder */
  public class FileDbContainer : IDbContainer 
  {
    private string Path (string key) {
      return @"/tmp/" + key + ".txt";
    }

    public void Set (string key, string value) {
      #if UNITY_WEBPLAYER
      #else
        System.IO.File.WriteAllText(Path(key), value);
      #endif
    }
    
    public string Get (string key) {
      #if UNITY_WEBPLAYER
        return "";
      #else
        var rtn = Exists(key) ? File.ReadAllText(Path(key)) : "";
        return rtn;
      #endif
    }
    
    public bool Exists(string key) {
      #if UNITY_WEBPLAYER
        return false;
      #else
        return File.Exists(Path(key));
      #endif
    }
  }
}

