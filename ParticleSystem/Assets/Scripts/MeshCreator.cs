using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MeshCreator : MonoBehaviour
{
    // Generates a very low poly sphere mesh
    public static GameObject GenerateLowPolySphere()
    {
        Mesh mesh = new Mesh();
        mesh.vertices = new Vector3[]
        {
            new Vector3(1,1,1),
            new Vector3(1,-1,1),
            new Vector3(-1,-1,1),
            new Vector3(-1,1,1),
            new Vector3(0,0,1.75f),
            new Vector3(0,1.75f, 0),
            new Vector3(0,-1.75f,0),
            new Vector3(1.75f,0,0),
            new Vector3(-1.75f,0,0),
            new Vector3(1,1,-1),
            new Vector3(1,-1,-1),
            new Vector3(-1,-1,-1),
            new Vector3(-1,1,-1),
            new Vector3(0,0,-1.75f)
        };
        mesh.triangles = new int[]
        {
            0,1,4,
            4, 1, 2,
            3,4,2,
            3,0,4,

            5,0,3,
            12,5,3,
            5,12,9,
            5,9,0,

            0,9,7,
            9,10,7,
            7,10,1,
            7,1,0,
            
            3,8,12,
            8,12,11,
            2,8,11,
            2,8,3,

            12,13,9,
            13,9,10,
            13,10,11,
            12,13,11,

            6,11,10,
            10,1,6,
            1,2,6,
            2,6,11
        };
        
        GameObject lowPolySphere = new GameObject();
        lowPolySphere.AddComponent<MeshRenderer>();
        lowPolySphere.AddComponent<MeshFilter>();
        lowPolySphere.GetComponent<MeshFilter>().mesh = mesh;
        lowPolySphere.GetComponent<MeshRenderer>().material = new Material(Shader.Find("Diffuse"));
        return lowPolySphere;
    }
    public void Start()
    {
        GameObject sphere = GenerateLowPolySphere();
        
        AssetDatabase.CreateAsset(sphere.GetComponent<MeshFilter>().mesh, "Assets/LowPolySphere.asset"); ;
    }
}
