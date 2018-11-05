using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour {

    public static bool time;
    private string scene;
    private bool set;
    public Material sky1, sky2;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
        set = false;
    }

    private void Update()
    {
        scene = SceneManager.GetActiveScene().name;

        if (set == false) {
            if (scene.Equals("Tec") && time == true)
            {
                RenderSettings.skybox = sky1;
                set = true;
            }

            if (scene.Equals("Tec") && time == false) {
                RenderSettings.skybox = sky2;
                set = true;
            }
        }
    }

    public void setQuality( int q) {

        QualitySettings.SetQualityLevel(q);
    }
}
