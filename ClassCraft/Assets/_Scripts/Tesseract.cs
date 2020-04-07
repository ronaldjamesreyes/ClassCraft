using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tesseract : MonoBehaviour {
    [SerializeField] private Texture2D imageToRecognize;
    [SerializeField] private TextMeshPro displayText;
    // [SerializeField] private RawImage outputImage;
    private TesseractDriver _tesseractDriver;
    private string _text = "";
    private Texture2D _texture;

    private void Start() {
        // set up to read text from image

        // start recognition calls
        _tesseractDriver = new TesseractDriver();
        Recognize();
    }

    private void Recognize() {
        Texture2D texture = new Texture2D(imageToRecognize.width, imageToRecognize.height, TextureFormat.ARGB32, false);
        texture.SetPixels32(imageToRecognize.GetPixels32());
        texture.Apply();

        _texture = texture;
        _text = "";
        // AddToTextDisplay(_tesseractDriver.CheckTessVersion());
        _tesseractDriver.Setup(OnSetupCompleteRecognize);
    }

    private void OnSetupCompleteRecognize() {
        AddToTextDisplay(_tesseractDriver.Recognize(_texture));
        AddToTextDisplay(_tesseractDriver.GetErrorMessage(), true);
    }

    private void AddToTextDisplay(string text, bool isError = false) {
        if (string.IsNullOrWhiteSpace(text)) return;

        _text += (string.IsNullOrWhiteSpace(displayText.text) ? "" : "\n") + text;

        if (isError) {
            Debug.LogError(text);
        }
        else {
            Debug.Log(text);
        }
    }

    private void LateUpdate() {
        displayText.text = _text;
    }
}