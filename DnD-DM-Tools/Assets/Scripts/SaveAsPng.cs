using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAsPng : MonoBehaviour
{
    [SerializeField] private Camera previewCamera = null;
    [SerializeField] private RectTransform transformToCapture;

    private bool grabImage;
    private void OnPostRender()
    {
        if (grabImage)
        {
            grabImage = false;
            //TakeScreenShot();
            RenderTexture rt = previewCamera.targetTexture;
            Texture2D screenShot = new Texture2D(rt.width, rt.height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(Screen.width-rt.width, 0, rt.width, rt.height);
            screenShot.ReadPixels(rect, 0, 0);
            byte[] bytes = screenShot.EncodeToPNG();
            string filename = ScreenShotName(rt.width, rt.height);
            System.IO.File.WriteAllBytes(filename, bytes);
            Debug.Log(string.Format("Took screenshot to: {0}", filename));
            RenderTexture.ReleaseTemporary(rt);
            previewCamera.targetTexture = null;
        }
    }

    private void TakeScreenShot()
    {
        //previewCamera.rect = new Rect(1 - transformToCapture.rect.width / Screen.width, 1 - transformToCapture.rect.height / Screen.height, 1, 1);
        //int resWidth = Mathf.FloorToInt(transformToCapture.rect.width);
        //int resHeight = Mathf.FloorToInt(transformToCapture.rect.height);
        //previewCamera.targetTexture = RenderTexture.GetTemporary(resWidth, resHeight, 16);
        previewCamera.targetTexture = RenderTexture.GetTemporary(Screen.width, Screen.height, 16);
    }

    private static string ScreenShotName(int width, int height)
    {
        return string.Format("{0}/screenshots/screen_{1}x{2}_{3}.png",
                             Application.dataPath,
                             width, height,
                             System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
    }

    public void TakeHiResShot()
    {
        TakeScreenShot();
        grabImage = true;
    }
}
