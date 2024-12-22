using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
public class Quiz : MonoBehaviour
{
  [Header("Questions")]
    [SerializeField]TextMeshProUGUI questionText;
    [SerializeField]QuestionSO question;

  [Header("Answers")]
    [SerializeField]GameObject[] answerButtons;
    int corAnswerIndex;

  [Header("Button Colors")]
    [SerializeField]Sprite defaultAnsSprite;
    [SerializeField]Sprite correctAnsSprite;

  [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;

    void Start(){
      GetNextQuestion();
        }


void DisplayQuestion(){
        questionText.text=question.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
        TextMeshProUGUI buttonText=answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text=question.GetAnswer(i);            
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
  SetButtonState(true);
  SetDefaultButtonSprites();
  DisplayQuestion();
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
    Image buttonImage;
    if(index==question.GetCorrectAnswerIndex()){
           questionText.text="Correct!";
         buttonImage = answerButtons[index].GetComponent<Image>();
        buttonImage.sprite=correctAnsSprite;   
        }
        else{
            corAnswerIndex=question.GetCorrectAnswerIndex();
            string correctAnswer=question.GetAnswer(corAnswerIndex);
            questionText.text="Sorry, correct answer was:\n "+ correctAnswer;
             buttonImage = answerButtons[corAnswerIndex].GetComponent<Image>();
            buttonImage.sprite=correctAnsSprite; 
        }
        SetButtonState(false);
  }
}
