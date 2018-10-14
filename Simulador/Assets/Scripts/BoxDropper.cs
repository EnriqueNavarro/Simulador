using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDropper : MonoBehaviour {
    [SerializeField] private GameObject WaypointSystem;
    [SerializeField] private GameObject node;
    [SerializeField] private int i;
    [SerializeField] private float distance;
    private Vector3 lastPos;
	// Use this for initialization
	void Start () {
        i = 0;
        lastPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(lastPos,transform.position)>=distance) {
            lastPos = transform.position;
            GameObject aux = Instantiate(node, transform.position, Quaternion.identity);
            aux.transform.SetParent(WaypointSystem.transform);
            if(i<10) {
                aux.name = "Waypoint 00" + i;
            } else {
                if(i<100) {
                    aux.name = "Waypoint 0" + i;
                } else {
                    aux.name = "Waypoint " + i;
                }
            }
            i++;
        }
	}
}
