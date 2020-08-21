using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Material trapMat;
    public Material goalMat;
    public Toggle colorblindMode;
    public Button playMaze;
	public Button quitMaze;
    
    void Start ()
    {
		playMaze.onClick.AddListener(PlayMaze);
		quitMaze.onClick.AddListener(QuitMaze);
	}

    public void PlayMaze()
    {
        SceneManager.LoadScene("Maze", LoadSceneMode.Single);
    }

     public void QuitMaze()
    {
        Debug.Log("Quit Game");
    }
}
