using UnityEngine;
using UnityEngine.UI;

public class TesseractDemoScript : MonoBehaviour 
{
    [SerializeField] private Text display;
    private TesseractDriver _tesseractDriver;
    public Texture2D imageToRecognize;

    private void Start() {
        _tesseractDriver = new TesseractDriver();
        display.text = _tesseractDriver.CheckTessVersion();
        _tesseractDriver.Setup();
        display.text += "\n" + _tesseractDriver.Recognize(imageToRecognize);
    }
}