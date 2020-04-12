using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RandomGenerator : MonoBehaviour
{
    public GameObject TextBox1;
    public GameObject TextBox2;
    public int FirstNumber;
    public int SecondNumber;
    public int Answer;
    public RectTransform RightAnswer;
    public RectTransform WrongAnswer;
    //GameControl gc;
    public int collect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Window"))
        {
            //gc = GameObject.FindGameObjectWithTag("GameCotrol").GetComponent<GameControl>();
            collect++;
        }
    }
    public void RandomGenerate()
    {
        FirstNumber = Random.Range(1, 10);
        SecondNumber = Random.Range(1, 10);
        TextBox1.GetComponent<Text>().text = "" + FirstNumber;
        TextBox2.GetComponent<Text>().text = "" + SecondNumber;
        RightAnswer.transform.gameObject.SetActive(false);


        Answer = FirstNumber + SecondNumber;
    }
    public void Answers()
    {
        if (collect == Answer)
        {
            RightAnswer.transform.gameObject.SetActive(true);
        }
        else
        {
            WrongAnswer.transform.gameObject.SetActive(true);
        }
    }
    public void TryAgain()
    {
        WrongAnswer.transform.gameObject.SetActive(false);
    }
}
