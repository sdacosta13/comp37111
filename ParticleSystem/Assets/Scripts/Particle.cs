using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Particle
{
    Vector3 vel;
    public float ttl;
    bool alive = true;
    public GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    public List<Trail> trails = new List<Trail>();
    Vector3 initialDisplacement;
    Vector3 initialVelocity;
    public float timeStart;
    public bool replaceable = false;
    float lastUpdate = Time.time;
    public Particle(float _ttl)
    {
        ttl = _ttl;
        SetRandomPos();
        SetRandomVel();
        GeneralParticleSetup();
    }
    public Particle(float _ttl, Vector3 _pos, Vector3 _vel)
    {
        ttl = _ttl;
        this.sphere.transform.position = _pos;
        initialDisplacement = _pos;
        initialVelocity = _vel;
        vel = _vel;
        GeneralParticleSetup();
    }
    public void GeneralParticleSetup()
    {
        timeStart = Time.time;
        sphere.GetComponent<Renderer>().material.SetColor("_Color", Particle.GetRandomColor());
        ttl += Random.Range(-Constants.TTLVariation, Constants.TTLVariation);
    }
    public void SetRandomPos()
    {
        int randX = Random.Range(-100, 100);
        int randZ = Random.Range(-100, 100);
        sphere.transform.position = new Vector3(randX, 0, randZ);
        initialDisplacement = new Vector3(randX, 0, randZ);
    }
    public void SetRandomVel()
    {
        float mag = Random.Range(100, 200) * Constants.MAGNITUDE;
        float angle1 = Random.Range(60, 90) * Mathf.PI / 180;
        float angle2 = Random.Range(0, 359) * Mathf.PI / 180;
        float x = mag * Mathf.Cos(angle1);
        float y = mag * Mathf.Sin(angle1);
        Vector3 temp = new Vector3(x, y, 0);
        vel = Quaternion.AngleAxis(angle2, Vector3.up) * temp;
        initialVelocity = vel;
        //Debug.Log(String.Format("{0} {1} {2}", vel.x, vel.y, vel.z));
    }
    public void GenerateExplosion()
    {
        //This section is adapted off a technique found at
        //https://stackoverflow.com/questions/9600801/evenly-distributing-n-points-on-a-sphere
        sphere.GetComponent<Renderer>().enabled = false;
        float gold = Mathf.PI * (3 - Mathf.Sqrt(5f));
        for (int i = 0; i < Constants.NUM_EXPLOSION; i++)
        {
            float y = 1f - (((float)i / (float)(Constants.NUM_EXPLOSION - 1f)) * 2f);
            float rad = (float)Math.Sqrt(1f - (y * y));
            float theta = gold * (float)i;
            float x = (float)Mathf.Cos(theta) * rad;
            float z = (float)Mathf.Sin(theta) * rad;
            Vector3 point = new Vector3(x, y, z) * Constants.EXPLOSION_SIZE;
            trails.Add(new Trail(Constants.TrailLength, sphere.transform.position, point));
            //Debug.Log(String.Format("{0} {1} {2}", point.x, point.y, point.z));
        }
    }
    public void PerformPhysicsCalc(float time)
    {
        float x = initialVelocity.x * time + initialDisplacement.x;
        float y = (initialVelocity.y * time + initialDisplacement.y) - (0.5f)*(Constants.GRAVITY * Constants.GRAVITY_MULTIPLIER)*(time)*(time);
        float z = initialVelocity.z * time + initialDisplacement.z;
        sphere.transform.position = new Vector3(x, y, z);
    }
    public virtual void Update()
    {
        float deltaTime = Time.time - lastUpdate;
        if(ttl >= 0 && alive)
        {
            
            ttl = ttl - deltaTime;
            float time = Time.time - timeStart;
            PerformPhysicsCalc(time);
            //Debug.Log(String.Format("{0} {1} {2}", x,y, z));   
        }
        else if(alive)
        {
            GenerateExplosion();
            sphere.GetComponent<Renderer>().enabled = false;
            alive = false;
        }
        else
        {
            bool trailsDead = true;
            sphere.GetComponent<Renderer>().enabled = false;
            for (int i = 0; i < trails.Count; i++)
            {
                trails[i].Update();
                if(trails[i].ttl >= 0)
                {
                    trailsDead = false;
                }
            }
            if (trailsDead)
            {
                replaceable = true;
            }

        }
        lastUpdate = Time.time;
    }
    public static Color GetRandomColor()
    {
        int r = Random.Range(0, 256);
        Color color;
        if(r < 50 && r >= 0)
        {
            color = new Color(255, 0, 0);
        }
        else if (r < 100 && r >= 50)
        {
            color = new Color(255, 102, 0);
        }
        else if (r < 150 && r >= 100)
        {
            color = new Color(255, 221, 0);
        }
        else if(r < 200 && r >= 150)
        {
            color = new Color(98, 255, 0);
        }
        else
        {
            color = new Color(8, 0, 255);
        }
        
        return color;
    }
}
