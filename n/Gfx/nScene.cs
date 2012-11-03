//
//  Copyright 2012  doug
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

namespace n.Gfx
{
  /** A set of layers */
  public class nScene
  {
    /** Set of cameras attached to this scene */
    private IList<nCamera> _cameras = new List<nCamera>();

    /** Set of layers attached to this scene */
    private IDictionary<int, nLayer> _layers = new Dictionary<int, nLayer>();

    /** Create a named layer */
    public nLayer Add(int id, int depth) {
      if (_layers.ContainsKey(id))
        _layers[id].Clear();
      _layers[id] = new nLayer();
      return _layers[id];
    }

    /** Get access to a named layer */
    public nLayer Get(int id) {
      return _layers [id];
    }

    /** Add a camera for the scene */
    public void Camera(nCamera c) {
      _cameras.Add(c);
    }

    /** If this scene is visible or not */
  }
}

