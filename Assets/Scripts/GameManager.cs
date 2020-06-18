using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager thisManager = null;  
    [SerializeField] private Text Txt_Score = null;
    [SerializeField] private Text Txt_Message = null;
    private int Score = 0;
    private GameObject[] obstacles;
    public GameObject duck;

    void Start()
    {
        thisManager = this;
        Time.timeScale = 0;
    }

    void Update()
    {
        if (Time.timeScale == 0 && Input.GetKeyDown(KeyCode.Return))
            StartGame();
    }

    public void UpdateScore(int value)
    {
        Score += value;
        Txt_Score.text = "SCORE : " + Score;
    }

    private void StartGame()
    {
        Score = 0;
        Time.timeScale = 1;
        Txt_Message.text = "";
        Txt_Score.text = "SCORE : 0";
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");

        foreach(GameObject obstacle in obstacles)
        {
            Destroy(obstacle);
        }
        duck.transform.position = new Vector3(0, 0.2f, 0);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(1);
        //Time.timeScale = 0;
        //Txt_Message.text = "GAMEOVER! \nPRESS ENTER TO RESTART GAME.";
        //Txt_Message.color = Color.red;
        
    }
}
