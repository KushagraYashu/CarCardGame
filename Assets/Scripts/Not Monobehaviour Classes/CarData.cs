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

    private int _overallRating;
    public int OverallRating
    {
        get { return _overallRating; }
    }

    public void SetData(string name, CSVParser.CarClasses primaryClass, CSVParser.CarClasses secondaryClass, int[] parameters, float ovr)
    {
        _carName = name;

        _primaryClass = primaryClass;
        _secondaryClass = secondaryClass;

        _paceRating = parameters[0];
        _abilityRating = parameters[1];
        _resilienceRating = parameters[2];
        _reliabilityRating = parameters[3];
        _styleRating = parameters[4];
        _appealRating = parameters[5];
        _overallRating = (int)Mathf.Round(ovr * 100f);
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

    public CarData(string name, CSVParser.CarClasses primaryClass, CSVParser.CarClasses secondaryClass, int[] parameters, float ovr)
    {
        _carName = name;

        _primaryClass = primaryClass;
        _secondaryClass = secondaryClass;

        _paceRating = parameters[0];
        _abilityRating = parameters[1];
        _resilienceRating = parameters[2];
        _reliabilityRating = parameters[3];
        _styleRating = parameters[4];
        _appealRating = parameters[5];
        _overallRating = (int)Mathf.Round(ovr * 100f);
    }
}
