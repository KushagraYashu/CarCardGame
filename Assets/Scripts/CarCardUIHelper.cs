using System;
using TMPro;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class CarCardUIHelper : MonoBehaviour
{
    private static string iconPath = "Car_PNGs/";

    [Serializable]
    public class CarCardUIObj
    {
        public TextMeshProUGUI title;
        public TextMeshProUGUI value;
    }

    public SpriteRenderer carIconSR;
    public SpriteMask carIconMask;

    public SpriteRenderer carIconBlurSR;
    public List<SpriteMask> carIconBlurMasks = new();

    public TextMeshProUGUI carNameUITMP;

    public TextMeshProUGUI carClassUITMP;  //add both primary and secondary here (example: SUV - OFF)
    
    public CarCardUIObj paceRatingUI;
    public CarCardUIObj abilityRatingUI;
    public CarCardUIObj resilienceRatingUI;
    public CarCardUIObj reliabilityRatingUI;
    public CarCardUIObj styleRatingUI;
    public CarCardUIObj appealRatingUI;

    public TextMeshProUGUI overallRatingUITMP;

    public void SetUI(CSVParser.CarProperties prop)
    {
        carNameUITMP.text = prop.name;

        string path = iconPath + prop.iconName;
        carIconSR.sprite = Resources.Load<Sprite>(path);
        carIconSR.sortingOrder = prop.order;
        carIconMask.sprite = carIconSR.sprite;
        carIconMask.frontSortingOrder = prop.order;

        path = iconPath + prop.iconBlurName;
        if(Resources.Load<Sprite>(path) == null)
        {
            Debug.LogError($"Car icon blur sprite not found at path: {path}");
        }
        carIconBlurSR.sprite = Resources.Load<Sprite>(path);
        carIconBlurSR.sortingOrder = prop.order;
        foreach (SpriteMask sm in carIconBlurMasks)
        {
            sm.sprite = carIconBlurSR.sprite;
            sm.frontSortingOrder = prop.order;
        }

        if (prop.secondaryClass != CSVParser.CarClasses.NON)
        {
            carClassUITMP.text = $"{prop.primaryClass} - {prop.secondaryClass}";
        }
        else
        {
            carClassUITMP.text = $"{prop.primaryClass}";
        }

        paceRatingUI.value.text = prop.paceRating.ToString();
        abilityRatingUI.value.text = prop.abilityRating.ToString();
        resilienceRatingUI.value.text = prop.resilienceRating.ToString();
        reliabilityRatingUI.value.text = prop.reliabilityRating.ToString();
        styleRatingUI.value.text = prop.styleRating.ToString();
        appealRatingUI.value.text = prop.appealRating.ToString();

        overallRatingUITMP.text = ((int)Mathf.Round(prop.overallRating * 100f)).ToString();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
