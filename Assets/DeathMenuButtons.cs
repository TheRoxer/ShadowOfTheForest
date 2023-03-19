using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenuButtons : MonoBehaviour
{
    public void GameRestart()
    {
        SceneManager.LoadScene(1);
    }

    public void GameQuit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }


}
