using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapaStorage : MonoBehaviour {

	void Start () {
		DontDestroyOnLoad(gameObject);
	}

	public void mapaUno()
	{
		ListaMapa.uno = "JungleTrackAutonomus";
		PlayerPrefs.SetString("track",ListaMapa.uno);
	}
	
	public void mapaDos()
	{
		ListaMapa.dos = "JungleTrackTraining";
		PlayerPrefs.SetString("track",ListaMapa.dos);
	}
	
	public void mapaTres()
	{
		ListaMapa.tres = "LakeTrackAutonomus";
		PlayerPrefs.SetString("track",ListaMapa.tres);
	}
	
	public void mapaCuatro()
	{
		ListaMapa.cuatro = "LakeTrackAutonomus";
		PlayerPrefs.SetString("track",ListaMapa.cuatro);
	}
}
