using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler: MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        GameObject s1 = GameObject.Find("GravitySlider");
        GameObject t1 = GameObject.Find("GravityText");
        t1.GetComponent<Text>().text = "Gravity Multiplier: " + (Mathf.Floor(s1.GetComponent<Slider>().value)).ToString();
        t1.GetComponent<Text>().SetAllDirty();
        Constants.GRAVITY_MULTIPLIER = s1.GetComponent<Slider>().value;
        GameObject s2 = GameObject.Find("FireworkTTLSlider");
        GameObject t2 = GameObject.Find("FireworkTTLText");
        t2.GetComponent<Text>().text = "Firework TTL: " + (Mathf.Floor(s2.GetComponent<Slider>().value)).ToString();
        t2.GetComponent<Text>().SetAllDirty();
        Constants.particleTTL = s2.GetComponent<Slider>().value;
    }
}
