using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class cargarEscena : MonoBehaviour {

	// Use this for initialization
	public void loadMenu(){
		SceneManager.LoadScene("Menu_Coche2.0");
	}

    public void loadMapSelector() {
        SceneManager.LoadScene("mapSelection");
    }

    public void loadTec()
    {
        SceneManager.LoadScene("Tec");
    }
    public void loadTecAut()
    {
        SceneManager.LoadScene("Tec2");
    }
    public void loadCoche()
    {
        SceneManager.LoadScene("SeleccCoche");
    }

public void loadDay() {
        DontDestroy.time = true;
        SceneManager.LoadScene("Tec");
    }

    public void loadNight()
    {
        DontDestroy.time = false;
        SceneManager.LoadScene("Tec");
    }
}
