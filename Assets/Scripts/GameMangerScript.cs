using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMangerScript : MonoBehaviour
{
  public static GameMangerScript instance;
    [SerializeField] private GameObject gameOver;



    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        Time.timeScale = 1f;
    }


    public void gameover()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
