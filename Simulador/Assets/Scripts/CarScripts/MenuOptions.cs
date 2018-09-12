using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{
    public void Start ()
    {
        DontDestroyOnLoad(gameObject);
    }

	public void MainMenu()
	{
		SceneManager.LoadScene ("Menu_Simulador");
	}

	public void SelectTrack()
	{
		SceneManager.LoadScene ("mapSelection");
	}

	public void SelectCar()
	{
		SceneManager.LoadScene ("carSelection");
	}

	public void StartRun()
	{
		SceneManager.LoadScene(PlayerPrefs.GetString("track"));
	}

}
