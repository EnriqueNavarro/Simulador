using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class cargarEscena : MonoBehaviour {

	// Use this for initialization
	public void loadMenu(){
		SceneManager.LoadScene("new_Menu");
	}

    public void loadMapSelector() {
        SceneManager.LoadScene("mapSelection");
    }

    public void loadTec()
    {
        SceneManager.LoadScene("Tec");
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
