using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle
{
    Vector3 vel;
    int ttl;
    bool alive = true;
    GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    public Particle(Vector3 _pos, Vector3 _vel, int _ttl)
    {
        vel = _vel;
        ttl = _ttl;
        sphere.transform.position = _pos;
        sphere.GetComponent<Renderer>().material.color = new Color(Random.Range(0, 255), 
                                                                   Random.Range(0, 255),
                                                                   Random.Range(0, 255));
    }      
    public void Update(float time)
    {
        if(ttl > 0 && alive)
        {
            float angle_xy = Mathf.Atan2(this.vel.y, this.vel.x);
            float angle_zy = Mathf.Atan2(this.vel.y, this.vel.z);
            float x = this.vel.x * time * Mathf.Cos(angle_xy);
            float z = this.vel.z * time * Mathf.Cos(angle_zy);
            float angle_y = Mathf.Atan2(this.vel.y, Mathf.Sqrt(Mathf.Pow(this.vel.x, 2) + Mathf.Pow(this.vel.z, 2)));
            float y = this.vel.y * time * Mathf.Sin(angle_y) - (0.5f * (Constants.GRAVITY * Constants.GRAVITY_MULTIPLIER) * time * time);
            sphere.transform.position.Set(x, y, z);
        }
    }
}
