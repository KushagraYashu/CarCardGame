using System;
using TMPro;
using UnityEngine;

public class CarCardUIHelper : MonoBehaviour
{
    [Serializable]
    public class CarCardUIObj
    {
        public TextMeshProUGUI title;
        public TextMeshProUGUI value;
    }

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

        if(prop.secondaryClass != CSVParser.CarClasses.NON)
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
