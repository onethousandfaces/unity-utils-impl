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
  /** A flat 2D textured quad */
  public class nQuad
  {
    public Vector2[] UV { get; set; }

    public Texture Texture { get; set; }

    private Vector3[] _vertices;

    private int[] _triangles;

    private Mesh _mesh;

    private string _name;

    /** GameObject instances created will be named Name__[RandomNumber] */
    public nQuad (string name) {
      _name = name;
      Init();
    }

    /** GameObject instances created will be named Quad__[RandomNumber] */
    public nQuad() {
      _name = "Quad";
      Init();
    }

    private void Init() {
      Texture = null;
      _mesh = new Mesh();
      _vertices = new Vector3[] {
        new Vector3( 1, 1,  0),
        new Vector3( 1, -1, 0),
        new Vector3(-1, 1, 0),
        new Vector3(-1, -1, 0),
      };
      UV = new Vector2[] {
        new Vector2(1, 1),
        new Vector2(1, 0),
        new Vector2(0, 1),
        new Vector2(0, 0),
      };
      _triangles = new int[] {
        0, 1, 2,
        2, 1, 3,
      };
      
      _mesh.vertices = _vertices;
      _mesh.uv = UV;
      _mesh.triangles = _triangles;
      _mesh.RecalculateNormals();
    }

    /** Generate a name for this quad */
    private string Name () {
      var random = UnityEngine.Random.Range(0, int.MaxValue);
      var name = String.Format("{0}__{1}", _name, random);
      return name;
    }

    /** Create a GameObject for this quad and add it to the scene */
    public GameObject Manifest ()
    {

      /* Create object and add to scene */
      var rtn = (GameObject)new GameObject (
        Name (),
        typeof(MeshRenderer), // Required to render
        typeof(MeshFilter)    // Required to have a mesh
      );
      rtn.GetComponent<MeshFilter> ().mesh = _mesh;
      
      /* Set texture */
      if (Texture != null) {
        rtn.renderer.material.mainTexture = Texture;

        /* Set shader for this sprite; unlit supporting transparency */
        var shader = Shader.Find ("Unlit/Transparent");
        rtn.renderer.material.shader = shader;
      }

      /* Set position */
      rtn.transform.position = new Vector3(0, 0, 0);

      return rtn;
    }
  }
}

