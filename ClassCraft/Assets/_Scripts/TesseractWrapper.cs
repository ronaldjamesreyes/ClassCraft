using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class TesseractWrapper {

    private const float MinimumConfidence = 60;

#if UNITY_EDITOR
    private const string TesseractDllName = "tesseract";
    private const string LeptonicaDllName = "tesseract";
#elif UNITY_ANDROID
    private const string TesseractDllName = "libtesseract.so";
    private const string LeptonicaDllName = "liblept.so";
#else
    private const string TesseractDllName = "tesseract";
    private const string LeptonicaDllName = "tesseract";
#endif    
    [DllImport(TesseractDllName)]
    private static extern IntPtr TessVersion();

    [DllImport(TesseractDllName)]
    private static extern IntPtr TessBaseAPICreate();

    [DllImport(TesseractDllName)]
    private static extern int TessBaseAPIInit3(IntPtr handle, string dataPath, string language);

    [DllImport(TesseractDllName)]
    private static extern void TessBaseAPISetImage(IntPtr handle, IntPtr imagedata, int width, int height, int bytes_per_pixel, int bytes_per_line);

    [DllImport(TesseractDllName)]
    private static extern void TessBaseAPISetImage2(IntPtr handle, IntPtr pix);

    [DllImport(TesseractDllName)]
    private static extern int TessBaseAPIRecognize(IntPtr handle, IntPtr monitor);

    [DllImport(TesseractDllName)]
    private static extern IntPtr TessBaseAPIGetUTF8Text(IntPtr handle);

    [DllImport(TesseractDllName)]
    private static extern void TessDeleteText(IntPtr text);

    [DllImport(TesseractDllName)]
    private static extern void TessBaseAPIClear(IntPtr handle);

    [DllImport(TesseractDllName)]
    private static extern IntPtr TessBaseAPIGetWords(IntPtr handle, IntPtr pixa);

    [DllImport(TesseractDllName)]
    private static extern IntPtr TessBaseAPIAllWordConfidences(IntPtr handle);

    private IntPtr tessHandle;

    public string Version() {
        IntPtr strPtr = TessVersion();
        string tessVersion = Marshal.PtrToStringAnsi(strPtr);
        return tessVersion;
    }
    

    public TesseractWrapper() {
        tessHandle = IntPtr.Zero;
    }
    
    public bool Init(string lang, string dataPath) {
        try {
            tessHandle = TessBaseAPICreate();

            int init = TessBaseAPIInit3(tessHandle, dataPath, lang);
            if (init != 0) {
                Debug.Log("Tess Init Failed");
                return false;
            }
            return true;
        }
        catch (Exception e) {
            Debug.Log(e);
            return false;
        }
    }

    public string Recognize(Texture2D texture) {
        if (tessHandle.Equals(IntPtr.Zero))
            return null;
        
        int width = texture.width;
        int height = texture.height;
        Color32[] colors = texture.GetPixels32();
        int count = width * height;
        int bytesPerPixel = 4;
        byte[] dataBytes = new byte[count * bytesPerPixel];
        int bytePtr = 0;
        for (int y = height - 1; y >= 0; y--) {
            for (int x = 0; x < width; x++) {
                int colorIdx = y * width + x;
                dataBytes[bytePtr++] = colors[colorIdx].r;
                dataBytes[bytePtr++] = colors[colorIdx].g;
                dataBytes[bytePtr++] = colors[colorIdx].b;
                dataBytes[bytePtr++] = colors[colorIdx].a;
            }
        }

        IntPtr imagePtr = Marshal.AllocHGlobal(count * bytesPerPixel);
        Marshal.Copy(dataBytes, 0, imagePtr, count * bytesPerPixel);TessBaseAPISetImage(tessHandle, imagePtr, width, height, bytesPerPixel, width * bytesPerPixel);

        if (TessBaseAPIRecognize(tessHandle, IntPtr.Zero) != 0) {
            Marshal.FreeHGlobal(imagePtr);
            return null;
        }

        IntPtr str_ptr = TessBaseAPIGetUTF8Text(tessHandle);
        Marshal.FreeHGlobal(imagePtr);
        if (str_ptr.Equals(IntPtr.Zero))
            return null;
    #if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
        string recognizedText = Marshal.PtrToStringAnsi (str_ptr);
    #else
        string recognizedText = Marshal.PtrToStringAuto(str_ptr);
    #endif

        TessBaseAPIClear(tessHandle);
        TessDeleteText(str_ptr);

        return recognizedText;
    }
}