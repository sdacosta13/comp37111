using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : Particle
{
    float lastUpdated = Time.time;
    public Trail(float _ttl, Vector3 _pos, Vector3 _vel) : base(_ttl, _pos, _vel)
    {
        sphere.GetComponent<MeshRenderer>().material.shader = Shader.Find("UI/Unlit/Transparent");
    }
    public override void Update()
    {
        if (ttl >= 0)
        {
            Color prev = sphere.GetComponent<MeshRenderer>().material.color;
            sphere.GetComponent<MeshRenderer>().material.color = new Color(prev.r, prev.g, prev.b, ((float) ttl / (float) Constants.TrailLength));
            float deltaTime = Time.time - lastUpdated;
            ttl -= deltaTime;
            float time = Time.time - timeStart;
            PerformPhysicsCalc(time);
            lastUpdated = Time.time;
        }
        else
        {
            sphere.GetComponent<Renderer>().enabled = false;
        }
    }
}
