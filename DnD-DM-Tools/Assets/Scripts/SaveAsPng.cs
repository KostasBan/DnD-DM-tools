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
            RenderTexture rt = previewCamera.targetTexture;
            int width = Mathf.CeilToInt(transformToCapture.rect.width);
            int height = Mathf.CeilToInt(transformToCapture.rect.height);
            Texture2D screenShot = new Texture2D(width, height, TextureFormat.ARGB32, false);
            Rect rect = new Rect((Screen.width - width) / 2, (Screen.height - height) / 2, width, height);
            screenShot.ReadPixels(rect, 0, 0);
            byte[] bytes = screenShot.EncodeToPNG();
            string filename = ScreenShotName(width, height);
            System.IO.File.WriteAllBytes(filename, bytes);
            Debug.Log(string.Format("Took screenshot to: {0}", filename));
            RenderTexture.ReleaseTemporary(rt);
            previewCamera.targetTexture = null;
        }
    }

    private void TakeScreenShot()
    {
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
        if (transformToCapture.rect.height < 1080)
        {
            TakeScreenShot();
            grabImage = true;
            if (transformToCapture.rect.height > 950)
                Debug.LogError("Please not that images larger than950 pixels does not feet in an A4 page wihtout scaling");
        }
        else
        {
            Debug.LogError("The image is greater than 1080pxs and it isnt yet implemented a way to capture bigger images");
        }

    }

    private void Start()
    {
        previewCamera.transform.position = new Vector3(0, 0, -(1920 / previewCamera.aspect) * 0.5f / Mathf.Tan(previewCamera.fieldOfView * 0.5f * Mathf.Deg2Rad));
    }
}
//make it read more than 1080px height images.
//make it with dynamic data.
//check if i can do the same with the main camera only
