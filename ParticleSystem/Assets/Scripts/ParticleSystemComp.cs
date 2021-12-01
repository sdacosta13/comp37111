using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ParticleSystemComp : MonoBehaviour
{
    Particle p;
    // Start is called before the first frame update
    float startTime;
    float timeElapsed;
    Particle[] ps = new Particle[Constants.MAX_FIREWORKS];
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        for(int fireworkIndex = 0; fireworkIndex < Constants.MAX_FIREWORKS; fireworkIndex++)
        {
            if(ps[fireworkIndex] == null)
            {
                if (Random.Range(0, 99) > Constants.FireworkChance * 100)
                {
                    ps[fireworkIndex] = new Particle(Constants.particleTTL);
                }
            }
            else
            {
                if (ps[fireworkIndex].replaceable)
                {
                    if (Random.Range(0, 999) > Constants.FireworkChance * 1000)
                    {
                        ps[fireworkIndex] = new Particle(Constants.particleTTL);
                    }
                }
            }
        }
        for(int i = 0; i < ps.Length; i++)
        {
            if(ps[i] != null)
            ps[i].Update();
        }
    }
}
