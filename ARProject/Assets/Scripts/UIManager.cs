using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class UIManager : MonoBehaviour
{

    public float time = 10f;

    GameObject textTimer;
    GameObject textScoreUp;
    [SerializeField] GameObject textScoreWindows;
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
        WindowsFinalScoring();
    }

    private void WindowsFinalScoring()
    {
        textScoreWindows.GetComponent<Text>().text = "X " + ScoreManager.score.ToString();
    }

    void WindowsTimer()
    {
        StartCoroutine(Timer());
    }

    void Scoring()
    {
        textScoreUp.GetComponent<Text>().text = "Score : " + ScoreManager.score.ToString();
    }

    IEnumerator Timer()
    {
        Text ScoreDisplay = textTimer.GetComponent<Text>();

        while (time > 16)
        {
            time--;
            ScoreDisplay.text = string.Format("{0:0}:{1:00}", Mathf.Floor(time / 60), time % 60);
            yield return new WaitForSeconds(1f);
        }

        while (time>0)
        {
            if (time <= 15)
            {
                textTimer.GetComponent<Text>().color = Color.red;
            }
            time--;
            ScoreDisplay.text = string.Format ("{0:0}:{1:00}", Mathf.Floor(time/60), time % 60);
            yield return new WaitForSeconds(1f);
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
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
