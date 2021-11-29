using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemComp : MonoBehaviour
{
    Particle p;
    float lastUpdate;
    // Start is called before the first frame update
    void Start()
    {
        p = new Particle(new Vector3(0,0,0), new Vector3(0,0,0), 1);
        lastUpdate = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        float time = Time.time - lastUpdate;
        p.Update(time);
        lastUpdate = Time.time;
    }
}
