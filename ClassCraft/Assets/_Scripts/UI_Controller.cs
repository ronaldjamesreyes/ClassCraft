using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Controller : MonoBehaviour
{
	public RectTransform Start;
    public RectTransform Lesson;
    public RectTransform Math;
    public RectTransform Exit;
	
	    public void butStartClicked()
    {
        Debug.Log("Button start clicked");
        Math.transform.gameObject.SetActive(true);
        Lesson.transform.gameObject.SetActive(true);
		Start.transform.gameObject.SetActive(false);
        Exit.transform.gameObject.SetActive(false);
    }

    public void butMathClicked(string MathWorld)
    {
        Debug.Log("Button Math clicked");
		SceneManager.LoadScene(MathWorld);
    }

    public void butLesson(string LessonWorld)
    {
        Debug.Log("Button select clicked");
		SceneManager.LoadScene(LessonWorld);
    }

    public void butExitClicked()
    {
        Debug.Log("Button exit clicked");
        Application.Quit();
    }
}