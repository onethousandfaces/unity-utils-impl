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
using System.Xml.Serialization;
using System.Xml;
using System.Text;
using System.IO;
using n.App;
using System.Reflection;

namespace n.Platform.Db
{
  public class RecordSerializer
  {
    public string Serialize(Type t, IList<nDbRecord> records) 
    {
      MethodInfo method = typeof(RecordSerializer).GetMethod("SerializeXml");
      MethodInfo item = method.MakeGenericMethod (new Type[] { t });
      var xml = (string) item.Invoke (this, new object[] { records });
      var block = Encrypt(xml, t.FullName);
      return block;
    }

    public IList<nDbRecord> Deserialize(Type t, string records) 
    {
      var xml = Crypto.DecryptStringAES(records, t.FullName);
      MethodInfo method = typeof(RecordSerializer).GetMethod("DeserializeXml");
      MethodInfo item = method.MakeGenericMethod (new Type[] { t });
      var rtn = (IList<nDbRecord>) item.Invoke (this, new object[] { xml });
      return rtn;
    }

    private string Encrypt (string raw, string key)
    {
      var rtn = Crypto.EncryptStringAES(raw, "RecordSerializer__" + key);
      return rtn;
    }

    private string Decrypt (string raw, string key)
    {
      var rtn = Crypto.DecryptStringAES(raw, "RecordSerializer__" + key);
      return rtn;
    }

    private string SerializeXml<T>(T value) {
      if(value == null) {
        return null;
      }
      
      XmlSerializer serializer = new XmlSerializer(typeof(T));
      
      XmlWriterSettings settings = new XmlWriterSettings();
      settings.Encoding = new UnicodeEncoding(false, false); // no BOM in a .NET string
      settings.Indent = false;
      settings.OmitXmlDeclaration = false;
      
      using(StringWriter textWriter = new StringWriter()) {
        using(XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings)) {
          serializer.Serialize(xmlWriter, value);
        }
        return textWriter.ToString();
      }
    }
    
    private T DeserializeXml<T>(string xml) {
      if(string.IsNullOrEmpty(xml)) {
        return default(T);
      }
      
      XmlSerializer serializer = new XmlSerializer(typeof(T));
      
      XmlReaderSettings settings = new XmlReaderSettings();

      using(StringReader textReader = new StringReader(xml)) {
        using(XmlReader xmlReader = XmlReader.Create(textReader, settings)) {
          return (T) serializer.Deserialize(xmlReader);
        }
      }
    }
  }
}

