using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainWorldController : MonoBehaviour
{
    // Buttons
    public GameObject ScreenshotButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Screenshot() {
        // Read screen and store in a byte array.
        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        texture.Apply();
        byte[] screen_as_png = texture.EncodeToPNG();
        // Write to .png file.
        System.DateTime date_now = System.DateTime.Now;
        string date_now_as_string = date_now.Day + "_" + 
                                    date_now.Month + "_" +
                                    date_now.Year + "__" +
                                    date_now.Hour + "_" + 
                                    date_now.Minute + "_" +
                                    date_now.Second;
        System.IO.File.WriteAllBytes(Application.persistentDataPath + "/screenshot__" + date_now_as_string + ".png", screen_as_png);
    }
}
