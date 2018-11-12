using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDont : MonoBehaviour {

    // Use this for initialization
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Light");


        if (objs.Length > 2)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
