using System;
using UnityEngine;
using UnityEngine.UI;
[ExecuteInEditMode]
public class ImageWithRoundedCorners : MonoBehaviour
{
    private static readonly int Props = Shader.PropertyToID("_WidthHeightRadius");
    public Material material;
    public float radius;
    private void Start()
    {
        CreateNewMaterialANDRefresh();
    }
    void OnRectTransformDimensionsChange()
    {
        CreateNewMaterialANDRefresh();
    }
    private void OnValidate()
    {
        Refresh();
    }
    private void Refresh()
    {
        var rect = ((RectTransform)transform).rect;
        if (material != null)
            material.SetVector(Props, new Vector4(rect.width, rect.height, radius, 0));
    }
    private void CreateNewMaterialANDRefresh()
    {
        var rect = ((RectTransform)transform).rect;
        Vector4 props = material.GetVector(Props);
        if (rect.width != props.x || rect.height != props.y)
        {
            Image img = GetComponent<Image>();
            img.material = new Material(material);
            material = img.material;
            Refresh();
        }
    }
}