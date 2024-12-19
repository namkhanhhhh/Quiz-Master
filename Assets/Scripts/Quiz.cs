using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Quiz : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI questionText;
    [SerializeField]QuestionSO question;
    [SerializeField]GameObject[] answerButtons;


    void Start(){
        questionText.text=question.GetQuestion();

        TextMeshProUGUI buttonText=answerButtons[0].GetComponentInChildren<TextMeshProUGUI>();
    }

}
