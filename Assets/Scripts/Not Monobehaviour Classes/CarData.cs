using UnityEngine;

public class CarData
{
    public CSVParser.CarClasses _primaryClass;
    public CSVParser.CarClasses _secondaryClass;

    private string _carName;
    public string CarName
    {
        get { return _carName; }
    }

    private int _paceRating;
    public int PaceRating
    {
        get { return _paceRating; }
    }

    private int _abilityRating;
    public int AbilityRating
    {
        get { return _abilityRating; }
    }

    private int _resilienceRating;
    public int ResilienceRating
    {
        get { return _resilienceRating; }
    }

    private int _reliabilityRating;
    public int ReliabilityRating
    {
        get { return _reliabilityRating; }
    }

    private int _styleRating;
    public int StyleRating
    {
        get { return _styleRating; }
    }

    private int _appealRating;
    public int AppealRating
    {
        get { return _appealRating; }
    }

    private float _overallRating;
    public float OverallRating
    {
        get { return _overallRating; }
    }

    public void SetData(CSVParser.CarProperties carProp)
    {
        _carName = carProp.name;

        _primaryClass = carProp.primaryClass;
        _secondaryClass = carProp.secondaryClass;

        _paceRating = carProp.paceRating;
        _abilityRating = carProp.abilityRating;
        _resilienceRating = carProp.resilienceRating;
        _reliabilityRating = carProp.reliabilityRating;
        _styleRating = carProp.styleRating;
        _appealRating = carProp.appealRating;
        _overallRating = carProp.overallRating;
    }

    public void DisplayCarData()
    {
        Debug.Log("Car Name: " + _carName);
        Debug.Log("Primary Class: " + _primaryClass.ToString());
        Debug.Log("Secondary Class: " + _secondaryClass.ToString());
        Debug.Log("Pace Rating: " + _paceRating);
        Debug.Log("Ability Rating: " + _abilityRating);
        Debug.Log("Resilience Rating: " + _resilienceRating);
        Debug.Log("Reliability Rating: " + _reliabilityRating);
        Debug.Log("Style Rating: " + _styleRating);
        Debug.Log("Appeal Rating: " + _appealRating);
        Debug.Log("Overall Rating: " + _overallRating);
    }

    public CarData() { }

    public CarData(CSVParser.CarProperties carProp)
    {
        _carName = carProp.name;

        _primaryClass = carProp.primaryClass;
        _secondaryClass = carProp.secondaryClass;

        _paceRating = carProp.paceRating;
        _abilityRating = carProp.abilityRating;
        _resilienceRating = carProp.resilienceRating;
        _reliabilityRating = carProp.reliabilityRating;
        _styleRating = carProp.styleRating;
        _appealRating = carProp.appealRating;
        _overallRating = carProp.overallRating;
    }
}
