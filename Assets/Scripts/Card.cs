using UnityEngine;

public class Card : MonoBehaviour
{
    public CarCardUIHelper _uiHelper;

    private CarData _cardData = new();

    public CarData CardData
    {
        get { return _cardData; }
    }

    public void SetCardDetailsAndUI(CSVParser.CarProperties prop)
    {
        _cardData.SetData(prop);

        _uiHelper.SetUI(prop);
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
