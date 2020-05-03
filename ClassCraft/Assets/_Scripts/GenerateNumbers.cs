using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class GenerateNumbers : MonoBehaviour
{
    // public GameObject TextBox2;
    // public GameObject TextBox2;
    private int num1;
    private int num2;
    private int answer;
 	private int playerScore;
    private string _text = "";
    public int numRange;
    public int inputAnswer;
	public TextMeshPro scoreDisplayText1;
    public TextMeshPro scoreDisplayText2;
    public TextMeshPro answerDisplay;
    // public GameObject tesseract;
	//private RandomGenerator dataController;

    public void Start() {
        RandomGenerate();
    }

    public void RandomGenerate() {
		//dataController = FindObjectOfType<RandomGenerator>();
        //currentRoundData = dataController.GetCurrentRoundData();
		
		num1 = Random.Range(1, numRange);
        num2 = Random.Range(1, numRange-num1);
        answer = num1 + num2;
        inputAnswer = answer;

        _text = num1 + " + " + num2 + " = ?";
        // TextBox1.GetComponent<Text>().text = "" + FirstNumber;
        // TextBox2.GetComponent<Text>().text = "" + SecondNumber;
	}

    public void LateUpdate() {
        scoreDisplayText1.text = _text;
    }
	
    public void answerButtonClicked() {
        if (inputAnswer == answer) {
            scoreDisplayText2.text = "Correct!";
            answerDisplay.text = "Awesome!";
        }
        else {
			scoreDisplayText2.text = "Incorrect...";
            answerDisplay.text = "Correct answer is \n" + answer;
        }
    }
}
