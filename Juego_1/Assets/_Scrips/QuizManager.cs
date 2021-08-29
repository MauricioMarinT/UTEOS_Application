using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class QuizManager : MonoBehaviour
{
 public List<QuestionsAndAnswers> QnA;
 public GameObject[] options;
 public int currentQuestion;
 public Text QuestionTxt;
 public GameManager gameManager;
 

 public void Start()
 {
  generateQuestion();
  gameManager = GameObject.FindObjectOfType<GameManager>();
 }
 
 public void correct(int perro)
 {
  if (QnA.Count > 0)
  {
   QnA.RemoveAt(currentQuestion);
   generateQuestion();
   Time.timeScale = 1.0f;
   gameManager.PanelHide(1);
   gameManager.UpdateScore(0,perro);
  }
  else
  {
   generateQuestion();
   Time.timeScale = 1.0f;
   gameManager.PanelHide(1);
   gameManager.UpdateScore(0,perro);
  }
 }

 void SetAnswer()
 {
  for (int i = 0; i < options.Length; i++)
  {
   options[i].GetComponent<AnswerScript>().isCorrect = false;
   options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];
   if (QnA[currentQuestion].CorrectAnswer==i+1)
   {
    options[i].GetComponent<AnswerScript>().isCorrect = true;
   }
  }
 }
 
 public void generateQuestion()
 {
  if (QnA.Count>0)
  {
   currentQuestion = Random.Range(0, QnA.Count);
   QuestionTxt.text = QnA[currentQuestion].Question;
   SetAnswer();
  }
  else
  {
   Debug.Log("se acabaron las questions");
   gameManager.GameOver();
  }
 }
 
}
