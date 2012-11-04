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
using System.Collections.Generic;
using System.Linq;

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

    private float _rotation = 0;

    private IDictionary<nPropClick, nCamera> _clicks = new Dictionary<nPropClick, nCamera>();

    public nProp (Texture texture, Vector2 size)
    {
      _quad = new nQuad(size);
      _quad.Texture = texture;
    }

    public nProp(nQuad parent) {
      _quad = parent;
    }

    /** Position */
    public Vector2 Position {
      get { 
        var p = _instance.transform.position;
        return new Vector2 (p [0], p [1]);
      }
      set { 
        var p = _instance.transform.position;
        _instance.transform.position = new Vector3(value[0], value[1], p[2]);
      }
    }

    /** Set the size of this prop in world units */
    public void Resize(Vector2 size) {
    }

    /** Scale */
    public Vector2 Scale {
      get { 
        var s = _instance.transform.localScale;
        return new Vector2(s[0], s[1]);
      }
      set {
        _instance.transform.localScale = new Vector3(value[0], value[1], 1);
      }
    }

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
      get {
        return _rotation;
      }
      set {
        _instance.transform.Rotate(
          new Vector3(0, 0, 1), value);
        _rotation = value;
      }
    }

    /** If this prop is manifest on the game scene */
    public bool Visible { 
      get {
        return _instance != null;
      }
      set {
        if (value) {
          if (_instance == null) {
            _instance = _quad.Manifest();
            _instance.AddComponent(typeof(nPropInput));
            _instance.GetComponent<nPropInput>().Clicks = _clicks;
            _instance.GetComponent<nPropInput>().Parent = this;
          }
        }
        else if (_instance != null) {
          GameObject.Destroy(_instance);
        }
      }
    }

    /** Listen for a click on this object; delegate must be unique */
    public void Listen(nCamera cam, nPropClick click) {
      _clicks[click] = cam;
    }
  }

  /** Prop click event type */
  public delegate void nPropClick(nProp prop);

  /** Handle events for the prop */
  public class nPropInput : MonoBehaviour {

    public IDictionary<nPropClick, nCamera> Clicks { get; set; }

    public nProp Parent { get; set; }

    public void Update ()
    {
      var mouse = Input.mousePosition;
      var click = Input.GetMouseButtonDown (0);
      if (click && Clicks.Keys.Any()) {

        /* collect cameras so we dont multi cast */
        var camList = new List<nCamera>();
        var camHits = new Dictionary<nCamera, RaycastHit>();
        foreach(var c in Clicks.Keys) {
          var cam = Clicks[c];
          if (!camList.Contains(cam)) 
            camList.Add (cam);
        }

        /* cast for each camera */
        foreach(var cc in camList) {
          var ray = cc.ScreenPointToRay(mouse);
          RaycastHit hit;
          Physics.Raycast(ray, out hit);
          camHits[cc] = hit;
        }

        /* Look for match and execute delegates */
        foreach(var c in Clicks.Keys) {
          var cam = Clicks[c];
          var hit = camHits[cam];
          if (hit.collider != null) {
            if (hit.collider.gameObject == this.gameObject) {
              c(this.Parent);
            }
          }
        }
      }
    }
  }
}

