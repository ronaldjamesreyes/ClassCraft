using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Tesseract : MonoBehaviour {
    [SerializeField] private Texture2D imageToRecognize;
    [SerializeField] private TextMeshPro displayText;
    private TesseractDriver _tesseractDriver;
    private string _text = "";
    private Texture2D _texture;

    private void Start() {
        Recognize();
    }

    public void Recognize() {
        _tesseractDriver = new TesseractDriver();
        Texture2D texture = new Texture2D(imageToRecognize.width, imageToRecognize.height, TextureFormat.ARGB32, false);
        texture.SetPixels32(imageToRecognize.GetPixels32());
        texture.Apply();

        _texture = texture;
        _text = "";
        // _text = _text + "Tesseract is working";
        _tesseractDriver.Setup(OnSetupCompleteRecognize);
    }

    public void Reset() {
        AssetDatabase.ImportAsset("Assets/Textures/Answer.png");
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