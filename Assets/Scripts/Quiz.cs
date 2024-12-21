using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Quiz : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI questionText;
    [SerializeField]QuestionSO question;
    [SerializeField]GameObject[] answerButtons;
    int corAnswerIndex;
    [SerializeField]Sprite defaultAnsSprite;
    [SerializeField]Sprite correctAnsSprite;

    void Start(){
        questionText.text=question.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
        TextMeshProUGUI buttonText=answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text=question.GetAnswer(i);            
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
  }
}
