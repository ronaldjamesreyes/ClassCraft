using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataConroller : MonoBehaviour
{
    public RoundData[] allRoundData;
    public RectTransform panelStart;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        panelStart.transform.gameObject.SetActive(true);
        //  SceneManager.LoadScene("MenuScreen");
    }

    public RoundData GetCurrentRoundData()
    {
        return allRoundData[0];
    }

    void Update()
    {
        
    }
}
