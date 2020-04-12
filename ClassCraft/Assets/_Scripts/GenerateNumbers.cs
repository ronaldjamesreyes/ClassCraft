using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GenerateNumbers : MonoBehaviour
{
    public GameObject TextBox1;
    public GameObject TextBox2;
    public int FirstNumber;
    public int SecondNumber;
    public int Answer;
	public Text scoreDisplayText;
	private int playerScore;
	//private RandomGenerator dataController;


    // Start is called before the first frame update
    public void RandomGenerate()
	{
		//dataController = FindObjectOfType<RandomGenerator>();
        //currentRoundData = dataController.GetCurrentRoundData();
		
		
        FirstNumber = Random.Range(1, 10);
        SecondNumber = Random.Range(1, 10);
        Answer = FirstNumber + SecondNumber;
        if (Answer <= 10)
        {
            TextBox1.GetComponent<Text>().text = "" + FirstNumber;
            TextBox2.GetComponent<Text>().text = "" + SecondNumber;
        }
        else
        {
            RandomGenerate();
        }		
	}
	
	    public void AnswerButtonClicked()
    {
        if (Answer == Answer)
        {
            //playerScore += currentRoundData.pointsAddedForCorrectAnswer;
            //scoreDisplayText.text = "Score: " + playerScore.ToString();
        }
        else 
        {
			//text dispaly incorect???
            //Loop to the start of the scene
        }
    }
}
