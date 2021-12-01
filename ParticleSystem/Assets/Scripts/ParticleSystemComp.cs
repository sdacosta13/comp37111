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
    float fireworkTimer;

    void Start()
    {
        fireworkTimer = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time > fireworkTimer + Constants.FireworkRate)
        {
            fireworkTimer = Time.time;
            for (int fireworkIndex = 0; fireworkIndex < Constants.MAX_FIREWORKS; fireworkIndex++)
            {
                if(ps[fireworkIndex] == null)
                {
                    ps[fireworkIndex] = new Particle(Constants.particleTTL);
                    break;
                }
                else
                {
                    if (ps[fireworkIndex].replaceable)
                    {
                        for(int i = 0; i < ps[fireworkIndex].trails.Count; i++)
                        {
                            Destroy(ps[fireworkIndex].trails[i].sphere);
                        }
                        Destroy(ps[fireworkIndex].sphere);
                        ps[fireworkIndex] = null;
                        Resources.UnloadUnusedAssets(); // Used to cleanup references to dead partices
                    }                                   // Removal causes memory leak
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
