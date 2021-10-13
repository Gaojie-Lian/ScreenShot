using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class ScreenShot_Windows : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScreenShot()
    {
        Texture2D CaptureScreenShot()
        {
            //Create a new rectangle with the screen as a reference.
            Rect rect = new Rect(Screen.width * 0f, Screen.height * 0f, Screen.width * 1f, Screen.height * 1f);

            //Convert the rectangle to Texture 2D.
            Texture2D screenShot = new Texture2D((int)rect.width, (int)rect.height, TextureFormat.RGB24, false);

            //Generate PNG image
            screenShot.ReadPixels(rect, 0, 0);
            screenShot.Apply();

            byte[] bytes = screenShot.EncodeToPNG();

            //Select the save path (Windows version)
            var path = EditorUtility.SaveFilePanel(
                "Please select path to save as",
                "",
                "Screenshot",
                "png");

            //Makefile.
            if (path.Length != 0)
            {
                if (bytes != null)
                {
                    File.WriteAllBytes(path, bytes);
                }
                Debug.Log(string.Format("ScreenShot: {0}", path));
            }

            return screenShot;
        }
    }

}
