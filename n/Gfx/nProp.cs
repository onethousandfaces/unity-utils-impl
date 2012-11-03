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
using UnityEngine;

namespace n.Gfx
{
  /** 
   * An instance of a quad on the scene.
   * <p>
   * Notice that a Prop defines position, rotation and scale;
   * but the UV coordinates are per quad, not per prop. To allow
   * custom UV per instance (eg. animation) create the prop from
   * a resource, not a Quad.
   * <p>
   * To manifest the prop, add it to a layer. To remove it, remove
   * it from the layer. This will add it to the scene or remove it.
   */
  public class nProp
  {
    protected nQuad _quad;

    private GameObject _instance = null;

    public nProp (Texture texture)
    {
      _quad = new nQuad();
      _quad.Texture = texture;
    }

    public nProp(nQuad parent) {
      _quad = parent;
    }

    /** Position */

    /** Scale */

    /** Z-index */
    public int Depth {
      get { return (int) Math.Floor(_instance.transform.position[2]); }
      set { 
        _instance.transform.position = new Vector3(
          _instance.transform.position[0],
          _instance.transform.position[1],
          (float) value
        );
      }
    }

    /** Rotation */
    public float Rotation {
      get; set;
    }

    /** If this prop is manifest on the game scene */
    public bool Manifest { 
      get {
        return _instance != null;
      }
      set {
        if (value) {
          if (_instance == null) {
            _instance = _quad.Manifest();
          }
        }
        else if (_instance != null) {
          GameObject.Destroy(_instance);
        }
      }
    }
  }
}

