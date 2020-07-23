using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FlashingLight : MonoBehaviour
{
    public float flashing_time;

    private Light2D ambient_light;
   

    bool is_burns = false;


    void Start()
    {
        ambient_light = transform.GetChild(0).GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(is_burns)
        {
            ambient_light.intensity = 0.9f;
           
            StartCoroutine(lamp_is_lit());
        }

        else
        {
            ambient_light.intensity = 0;
            StartCoroutine(lamp_is_off());
        }
    }

    private IEnumerator<WaitForSeconds> lamp_is_lit()
    {
        //is_burns = true;
        yield return new WaitForSeconds(flashing_time);
        is_burns = false;
    }

    private IEnumerator<WaitForSeconds> lamp_is_off()
    {
        //is_burns = false;
        yield return new WaitForSeconds(flashing_time);
        is_burns = true;
    }
}
