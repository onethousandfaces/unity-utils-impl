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
  /** 
   * A 2D layer which is drawn to in unity 
   * <p>
   * Adding and removing props does nothing; calling Manifest() changes
   * whether the props are drawn to the scene or not. Tangibly this either
   * destroys or creates game objects for the prop.
   */
  public class nLayer
  {
    /** Visiblity */
    private bool _visible = false;

    /** Z index */
    private int _depth = 0;

    /** Prop groupings */
    IDictionary<int, IList<nProp>> _props = new Dictionary<int, IList<nProp>>();

    /** Clear all items on this layer */
    public void Clear() {
    }

    /** 
     * Add a prop to the layer 
     * <p>
     * Many props can be added under a single type; or a single one can.
     * For example, you can add a hundred 'star' props by adding them with
     * the same id, and one player prop. 
     */
    public void Add(int type, nProp p) {
    }

    /** Remove a prop for the layer */
    public void Remove(nProp p) {
    }

    /** Remove all props of a type from the layer */
    public void RemoveAll(int type) {
    }

    /** Get props from a layer */
    public IEnumerable<nProp> Get(int type) {
      return null;
    }

    /** Short cut for getting a single prop */
    public nProp GetSingle(int type) {
      return null;
    }

    /** All props of all types in this layer */
    public IEnumerable<nProp> All ()
    {
      return null;
    }

    /** Set the z-index for this layer */
    public int Depth {
      get {
        return _depth;
      }
      set {
        _depth = value;
        foreach (var p in All()) {
          p.Depth = value;
        }
      }
    }

    /** If this scene is visible or not */
    public bool Visible { 
      get { return _visible; } 
      set {
        _visible = value;
        if (_visible) {
        }
        else {
        }
      }
    }
  }
}

