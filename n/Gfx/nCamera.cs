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
using UnityEngine;

namespace n.Gfx
{
  /** 
   * A 2D layer which is drawn to in unity 
   * <p>
   * You'll notice this only provides a limited subset of the functionality
   * of the unity camera; that's deliberate.
   */
  public class nCamera
  {
    /** Camera instance */
    private UnityEngine.Camera _cam;

    /** 
     * Creates a new orthographic camera
     * <p>
     * Notice that you must 'enable' this camera by setting
     * 'Active' to true, and 'Audio' to true if you want it to
     * be the primary audio listener.
     * <p>
     * The camera is placed at (0, 0, -1) looking down the Z-axis.
     * <p>
     * There MUST be a camera on the scene already to be able create 
     * this type of camera, and it inherits all the properties of the
     * main camera; although some of them are reset.
     */
    public nCamera(double height) {
      var original = GameObject.FindWithTag("MainCamera");
      _cam = (Camera) UnityEngine.Camera.Instantiate(
        original.camera,
        new Vector3(0, 0, -1),
        Quaternion.FromToRotation(
          new Vector3(0, 0, 0),
          new Vector3(0, 0, 1)
        )
      );
      _cam.orthographicSize = (float) height / 2;
      _cam.orthographic = true;
      _cam.backgroundColor = Color.black;
      _cam.depth = 0;
      _cam.enabled = false;
      _cam.GetComponent<AudioListener>().enabled = false;
      original.camera.enabled = false;
    }

    /** Move the camera to a different 2D location */
    public void Move(double x, double y) {
      _cam.transform.position = new Vector3((float) x, (float) y, -1.0f);
    }

    /** Background color for to the camera */
    public Color Background { 
      get { return _cam.backgroundColor; }
      set { _cam.backgroundColor = value; }
    }

    /** Convert mouse coordinates to camera coordinates */
    public Ray ScreenPointToRay(Vector3 point) {
      var ray = _cam.ScreenPointToRay(point);
      return ray;
    }

    /** Camera render order */
    public int Depth {
      get { return (int) Math.Floor(_cam.depth); }
      set { _cam.depth = value; }
    }

    /** Enable to audio listener for this camera */
    public bool Audio {
      get {
        return _cam.GetComponent<AudioListener>().enabled;
      }
      set {
        _cam.GetComponent<AudioListener>().enabled = value;
      }
    }

    /** Enable this camera */
    public bool Active {
      get { return _cam.enabled; }
      set { _cam.enabled = value; }
    }
  }
}

