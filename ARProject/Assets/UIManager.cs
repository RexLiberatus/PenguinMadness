﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public float time = 10f;
    GameObject textTimer;
    GameObject textScoreUp;
    [SerializeField]GameObject finalScoringWindows;

    private void Awake()
    {
        textTimer = GameObject.Find("TextTimer");
        textScoreUp = GameObject.Find("ScoreUp");
    }
    // Start is called before the first frame update
    void Start()
    {
        WindowsTimer();
    }

    // Update is called once per frame
    void Update()
    {
        Scoring();
    }



    void WindowsTimer()
    {
        StartCoroutine(Timer());
    }

    void Scoring()
    {
        textScoreUp.GetComponent<Text>().text = "Score : ";
    }

    IEnumerator Timer()
    {
        if (time <= 15)
        {
            textTimer.GetComponent<Text>().color = Color.red;
        }
        while (time>0)
        {
            time--;
            yield return new WaitForSeconds(1f);
            textTimer.GetComponent<Text>().text = string.Format ("{0:0}:{1:00}", Mathf.Floor(time/60), time % 60);
        }
        if (time == 0)
        {
            finalScoringWindows.SetActive(true);
            Time.timeScale = 0;
            Debug.Log("Fin du timer");
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
