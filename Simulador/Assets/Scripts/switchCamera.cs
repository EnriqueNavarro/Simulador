using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchCamera : MonoBehaviour
{

    public Camera cam1;
    public Camera cam2;
    public Camera cam3;

    private float timer = 0;
    void Start()
    {
        cam1.enabled = true;
        cam2.enabled = false;
        cam3.enabled = false;

    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 10 && timer < 20)
        {
            cam1.enabled = false;
            cam2.enabled = true;
            cam3.enabled = false;

        }
        else
        {
            if (timer > 20 && timer < 30)
            {
                cam1.enabled = false;
                cam2.enabled = false;
                cam3.enabled = true;
            }
            if (timer > 30) { 

                timer = 0;
            }
        }
        
    }
}