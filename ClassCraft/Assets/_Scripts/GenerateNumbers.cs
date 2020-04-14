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
    private string _text = "";
    public int numRange;
	public TextMeshPro scoreDisplayText;
	private int playerScore;
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

        _text = num1 + " + " + num2 + " = ?";
        // TextBox1.GetComponent<Text>().text = "" + FirstNumber;
        // TextBox2.GetComponent<Text>().text = "" + SecondNumber;
	}

    public void LateUpdate() {
        scoreDisplayText.text = _text;
    }
	
    public void answerButtonClicked() {
        if (answer == answer) {
            //playerScore += currentRoundData.pointsAddedForCorrectanswer;
            //scoreDisplayText.text = "Score: " + playerScore.ToString();
        }
        else {
			//text dispaly incorect???
            //Loop to the start of the scene
        }
    }
}
