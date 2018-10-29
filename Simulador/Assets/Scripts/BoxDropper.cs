using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BoxDropper : MonoBehaviour {
    [SerializeField] private GameObject WaypointSystem;
    [SerializeField] private GameObject node;
    [SerializeField] private int i;
    [SerializeField] private float distance;
    private List<GameObject> boxes;
    public string sceneToLoad;
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
                    if (i < 1000) {
                        aux.name = "Waypoint " + i ;
                    } else {
                        if (i%1000 < 10)
                        {
                            aux.name = (int)(1000/i)+"Waypoint 00" + (i % 1000);
                        }
                        else
                        {
                            if (i % 1000 < 100)
                            {
                                aux.name = (int)(1000 / i) + "Waypoint 0" + (i % 1000);
                            }
                            else
                            {
                                if (i % 1000 < 1000)
                                {
                                    aux.name = (int)(1000 / i) + "Waypoint " + (i % 1000);
                                }
                                else
                                {

                                }
                            }
                        }
                    }
                }
            }
            i++;
        }
        //Debug.Log(Input.GetKeyDown(0));
        if(Input.GetKeyDown("q")) {
            Debug.Log("Saving");
            Transform[] transforms = GetComponentsInChildren<Transform>();
            Communicate.boxes = GetComponentsInChildren<GameObject>();
            Communicate.transforms = transforms;
            SceneManager.LoadScene(sceneToLoad);
        }
	}
}
