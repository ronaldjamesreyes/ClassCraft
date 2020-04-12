using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    public Text answerText;
    private GameController gameController;
    private AnswerData answerData;
    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }
    public void Setup(AnswerData data)
    {
        answerData = data;
        answerText.text = answerData.answerText;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void HandleClicked()
    {
        gameController.AnswerButtonClicked(answerData.isCorrect);
    }
}
