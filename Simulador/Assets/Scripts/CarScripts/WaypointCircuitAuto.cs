using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class WaypointCircuitAuto : MonoBehaviour {
    public Transform[] waypointList;
    [SerializeField] private bool smoothRoute = true;
    private int numPoints;
    private Vector3[] points;
    private float[] distances=new float[0];
    public WaypointCircuitAuto Waypoints=null;
    public float editorVisualisationSubsteps = 100;
    public float Length { get; private set; }
    public bool ready;
    public bool loaded;
    //public GameObject children;

    private void Start()
    {
        Transform[] circuit;
        if (loaded) {
            circuit = Communicate.transforms;
            for(int i=0;i< Communicate.boxes.Length;i++) {
                Instantiate(Communicate.boxes[i], Communicate.boxes[i].transform.position, Quaternion.identity);
            }
        } else {
            circuit = GetComponentsInChildren<Transform>();
        }
        //Array.Sort(circuit, new TransformNameComparer()); 
        distances = new float[waypointList.Length + 1];
        waypointList = circuit;
        Waypoints = new WaypointCircuitAuto(waypointList);
        CachePositionsAndDistances();
        numPoints = waypointList.Length;

    }
    //this being here will save GC allocs
    private int p0n;
    private int p1n;
    private int p2n;
    private int p3n;

    private float i;
    private Vector3 P0;
    private Vector3 P1;
    private Vector3 P2;
    private Vector3 P3;

    public WaypointCircuitAuto(Transform[] waypointList)
    {
        this.waypointList = waypointList;
    }

    // Use this for initialization



    public RoutePoint GetRoutePoint(float dist)
    {
        // position and direction
        Vector3 p1 = GetRoutePosition(dist);
        Vector3 p2 = GetRoutePosition(dist + 0.1f);
        Vector3 delta = p2 - p1;
        return new RoutePoint(p1, delta.normalized);
    }


    public Vector3 GetRoutePosition(float dist)
    {
        int point = 0;
        CachePositionsAndDistances();
        if (Length == 0 )
        {
            
            Length = distances[distances.Length - 1];
        }

        dist = Mathf.Repeat(dist, Length);

        while (distances[point] < dist)
        {
            ++point;
        }

        numPoints = waypointList.Length;
        // get nearest two points, ensuring points wrap-around start & end of circuit
        p1n = ((point - 1) + numPoints) % numPoints;
        p2n = point;

        // found point numbers, now find interpolation value between the two middle points

        i = Mathf.InverseLerp(distances[p1n], distances[p2n], dist);

        if (smoothRoute)
        {
            // smooth catmull-rom calculation between the two relevant points


            // get indices for the surrounding 2 points, because
            // four points are required by the catmull-rom function
            p0n = ((point - 2) + numPoints) % numPoints;
            p3n = (point + 1) % numPoints;

            // 2nd point may have been the 'last' point - a dupe of the first,
            // (to give a value of max track distance instead of zero)
            // but now it must be wrapped back to zero if that was the case.
            p2n = p2n % numPoints;

            P0 = points[p0n];
            P1 = points[p1n];
            P2 = points[p2n];
            P3 = points[p3n];

            return CatmullRom(P0, P1, P2, P3, i);
        }
        else
        {
            // simple linear lerp between the two points:

            p1n = ((point - 1) + numPoints) % numPoints;
            p2n = point;

            return Vector3.Lerp(points[p1n], points[p2n], i);
        }
    }


    private Vector3 CatmullRom(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float i)
    {
        // comments are no use here... it's the catmull-rom equation.
        // Un-magic this, lord vector!
        return 0.5f *
               ((2 * p1) + (-p0 + p2) * i + (2 * p0 - 5 * p1 + 4 * p2 - p3) * i * i +
                (-p0 + 3 * p1 - 3 * p2 + p3) * i * i * i);
    }


    private void CachePositionsAndDistances()
    {
        // transfer the position of each point and distances between points to arrays for
        // speed of lookup at runtime
        points = new Vector3[waypointList.Length + 1];
        distances = new float[waypointList.Length + 1];
        
        float accumulateDistance = 0;
        for (int i = 0; i < points.Length; ++i)
        {
            var t1 = waypointList[(i) % waypointList.Length];
            var t2 = waypointList[(i + 1) % waypointList.Length];
            if (t1 != null && t2 != null)
            {
                Vector3 p1 = t1.position;
                Vector3 p2 = t2.position;
                points[i] = waypointList[i % waypointList.Length].position;
                distances[i] = accumulateDistance;
                accumulateDistance += (p1 - p2).magnitude;
            }
        }
        ready = true;

    }
    /*public class TransformNameComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            //return ((Transform)x).name.CompareTo(((Transform)y).name);
        }
    }*/
    public void AddChildren()
    {
        Transform[] circuit = this.GetComponentsInChildren<Transform>();
        /*var children = new Transform[circuit.transform.childCount];
        int n = 0;
        foreach (Transform child in circuit.transform)
        {
            children[n++] = child;
        }
        Array.Sort(children, new TransformNameComparer());
        circuit.waypointList.items = new Transform[children.Length];
        for (n = 0; n < children.Length; ++n)
        {
            circuit.waypointList.items[n] = children[n];
        }*/
        //Array.Sort(circuit, new TransformNameComparer());
        waypointList = circuit;
        Waypoints = new WaypointCircuitAuto(waypointList);


    }
    
    public class WaypointList
    {
        public WaypointCircuitAuto circuit;
        public Transform[] items = new Transform[0];
    }

    public struct RoutePoint
    {
        public Vector3 position;
        public Vector3 direction;


        public RoutePoint(Vector3 position, Vector3 direction)
        {
            this.position = position;
            this.direction = direction;
        }
    }    
}

