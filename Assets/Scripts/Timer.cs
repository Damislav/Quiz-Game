using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 30f;
    [SerializeField] float timeToShowCorrectAnswer = 10f;


    public bool loadNextQuestion;
    public float fillFraction;

    public bool isAnsweringQuestion;
    float timerValue;

    private void Update()
    {
        UpdateTimer();
    }
    public void CancelTimer()
    {
        timerValue = 0;
    }
    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;


        if (isAnsweringQuestion)
        {
            // answering question
            if (timerValue > 0)
            {
                //fill circle
                fillFraction = timerValue / timeToCompleteQuestion; //5/10=0.5f
            }
            else
            {
                isAnsweringQuestion = false;
                timerValue = timeToShowCorrectAnswer;

            }

        }
        else
        //not answering question
        {
            if (timerValue > 0)
            {
                //fill circle
                fillFraction = timerValue / timeToShowCorrectAnswer; //5/10=0.5f
            }
            else
            {
                isAnsweringQuestion = true;
                timerValue = timeToCompleteQuestion;
                loadNextQuestion = true;
            }
        }

        Debug.Log(isAnsweringQuestion + ": " + timerValue + ": " + fillFraction);
    }
}
