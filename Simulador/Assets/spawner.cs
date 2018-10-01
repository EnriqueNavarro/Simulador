using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {
    public GameObject[] posibleSpawns;
	// Use this for initialization
	void Start () {
        Instantiate(posibleSpawns[Random.Range(0, posibleSpawns.Length)], transform.position, Quaternion.identity);
        Destroy(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
