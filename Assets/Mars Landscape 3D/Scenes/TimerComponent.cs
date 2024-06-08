using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerComponent : MonoBehaviour
{
    public float elapsedTime { get; private set; }

    [SerializeField] TMP_Text timerText;
    public string totalItems;
    private float startTime;

    void Start()
    {
        startTime = Time.time;
        timerText.text = "00:00";
    }

    void Update()
    {
        elapsedTime = Time.time - startTime;
        timerText.text = ConvertSecondsToTime(elapsedTime);

        if(elapsedTime > 30)
        {
            SceneManager.LoadScene("FinishScene");
        }
    }

    string ConvertSecondsToTime(float elapsedTime)
    {
        int minutes = ((int)(elapsedTime / 60));
        int seconds = ((int)(elapsedTime % 60));

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public float getElapsedTime()
    {
        return elapsedTime;
    }

}
