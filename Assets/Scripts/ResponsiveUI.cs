using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class ResponsiveUI : MonoBehaviour
{
    private Vector2 referenceResolution = new Vector2(1920, 1080);

    public struct ResponsiveItems{
        public RectTransform rectTransform;
        public float widthMultiplier;
        public float heightMultiplier;
        public float xPosMultiplier;
        public float yPosMultiplier;
    }

    public RectTransform canvas;

    public List<RectTransform> responsiveItemsRectTrans = new List<RectTransform>();
    public List<ResponsiveItems> responsiveItems = new List<ResponsiveItems>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ResolutionMonitor.OnResolutionChange += ResChange;

        //Fill the screen with canvas
        canvas.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width);
        canvas.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height);

        //Initialize responsive items
        responsiveItems = new List<ResponsiveItems>(responsiveItemsRectTrans.Count);
        for(int i = 0; i < responsiveItemsRectTrans.Count; i++){
            ResponsiveItems newItem = new ResponsiveItems();
            newItem.rectTransform = responsiveItemsRectTrans[i];
            newItem.widthMultiplier = responsiveItemsRectTrans[i].rect.width / referenceResolution.x;
            newItem.heightMultiplier = responsiveItemsRectTrans[i].rect.height / referenceResolution.y;
            newItem.xPosMultiplier = responsiveItemsRectTrans[i].anchoredPosition.x / referenceResolution.x;
            newItem.yPosMultiplier = responsiveItemsRectTrans[i].anchoredPosition.y / referenceResolution.y;
            responsiveItems.Add(newItem);
        }
    }

    void ResChange(Vector2 newResolution)
    {
        //Fill the screen with canvas
        canvas.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, newResolution.x);
        canvas.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, newResolution.y);

        //Update responsive items, conserving their original width and height ratios
        foreach (var item in responsiveItems)
        {
            item.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, newResolution.x * item.widthMultiplier);
            item.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, newResolution.y * item.heightMultiplier);
            item.rectTransform.anchoredPosition = new Vector2(newResolution.x * item.xPosMultiplier, newResolution.y * item.yPosMultiplier);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
