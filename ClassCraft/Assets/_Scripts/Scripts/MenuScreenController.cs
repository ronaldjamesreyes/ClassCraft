using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreenController : MonoBehaviour
{
    public RectTransform panelMainMenu;
    public RectTransform panelQuestion;
    public void StartGame()
    {
        //   SceneManager.LoadScene("Game");
        panelMainMenu.transform.gameObject.SetActive(false);
        panelQuestion.transform.gameObject.SetActive(true);
    }
}
