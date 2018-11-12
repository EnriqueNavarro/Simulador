using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fondo : MonoBehaviour {

    public Dropdown m_Dropdown;
    public Material Skybox1;
    public Material Skybox2;
    public Material Skybox3;
    // Use this for initialization
    public  void  Dropdown_IndexChange(int index){
        if (index==0){
            RenderSettings.skybox = Skybox1;
        }
        if (index == 1)
        {
            RenderSettings.skybox = Skybox2;
        }
        if (index == 2)
        {
            RenderSettings.skybox = Skybox3;
        }

    }
   
    void Start () {
        RenderSettings.skybox = Skybox1;
	}
	
	// Update is called once per frame
	void Update () {

		
	}
}
