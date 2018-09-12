using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarStorage : MonoBehaviour {

	void Start () {
		DontDestroyOnLoad(gameObject);
	}

	public void carUno()
	{
		PlayerPrefs.SetString("car", ListaMapa.cUno);
	}
	
	public void carDos()
	{
		PlayerPrefs.SetString("car", ListaMapa.cDos);
	}
}