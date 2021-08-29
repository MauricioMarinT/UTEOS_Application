using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizmanager;

    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Respuesta Correcta");
            quizmanager.correct(1);
        }
        else
        {
            Debug.Log("incorrectus");
            quizmanager.correct(0);
        }

    }
}