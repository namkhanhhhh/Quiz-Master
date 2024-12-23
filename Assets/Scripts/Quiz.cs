using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
public class Quiz : MonoBehaviour
{
  [Header("Questions")]
    [SerializeField]TextMeshProUGUI questionText;
    [SerializeField] List<QuestionSO> questions=new List<QuestionSO>();
    QuestionSO currentQuestion;

  [Header("Answers")]
    [SerializeField]GameObject[] answerButtons;
    int corAnswerIndex;
    bool hasAnsweredEarly;

  [Header("Button Colors")]
    [SerializeField]Sprite defaultAnsSprite;
    [SerializeField]Sprite correctAnsSprite;

  [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;

    void Start(){
      timer= FindAnyObjectByType<Timer>();
        }



        void Update(){
         timerImage.fillAmount=timer.fillFraction;
         if(timer.loadNextQuestion){
          hasAnsweredEarly=false;
                      GetNextQuestion();
          timer.loadNextQuestion=false;
         }
         else if(!hasAnsweredEarly && !timer.isAnsweringQuestion){
          DisplayAnswer(10);
          SetButtonState(false);
         }
        }


void DisplayQuestion(){
        questionText.text=currentQuestion.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
        TextMeshProUGUI buttonText=answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text=currentQuestion.GetAnswer(i);            
        }
}

 void SetButtonState(bool state){
  for (int i = 0; i < answerButtons.Length; i++)
  {
    Button button=answerButtons[i].GetComponent<Button>();
    button.interactable=state;
  }
 }

 void GetNextQuestion(){
  if(questions.Count>0){
  SetButtonState(true);
  SetDefaultButtonSprites();
  GetRandQuestion();
  DisplayQuestion();
  }
 }

     void GetRandQuestion()
    {
        int index=UnityEngine.Random.Range(0,questions.Count);
        currentQuestion=questions[index];
        if(questions.Contains(currentQuestion)){
        questions.Remove(currentQuestion);
        }
    }

    void SetDefaultButtonSprites()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
          Image buttonImage=answerButtons[i].GetComponent<Image>();
          buttonImage.sprite=defaultAnsSprite;
        }
    }

    public void OnAnswerSelected(int index){
      hasAnsweredEarly=true;
    Image buttonImage;
    if(index==currentQuestion.GetCorrectAnswerIndex()){
           questionText.text="Correct!";
         buttonImage = answerButtons[index].GetComponent<Image>();
        buttonImage.sprite=correctAnsSprite;   
        }
        else{
            corAnswerIndex=currentQuestion.GetCorrectAnswerIndex();
            string correctAnswer=currentQuestion.GetAnswer(corAnswerIndex);
            questionText.text="Sorry, correct answer was:\n "+ correctAnswer;
             buttonImage = answerButtons[corAnswerIndex].GetComponent<Image>();
            buttonImage.sprite=correctAnsSprite; 
        }
        SetButtonState(false);
        timer.CancelTimer();
  }

  void DisplayAnswer(int index){
    Image buttonImage;
    if(index==currentQuestion.GetCorrectAnswerIndex()){
           questionText.text="Correct!";
         buttonImage = answerButtons[index].GetComponent<Image>();
        buttonImage.sprite=correctAnsSprite;   
        }
        else{
            corAnswerIndex=currentQuestion.GetCorrectAnswerIndex();
            string correctAnswer=currentQuestion.GetAnswer(corAnswerIndex);
            questionText.text="Sorry, correct answer was:\n "+ correctAnswer;
             buttonImage = answerButtons[corAnswerIndex].GetComponent<Image>();
            buttonImage.sprite=correctAnsSprite; 
        }
  }
}
