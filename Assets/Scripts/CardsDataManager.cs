using UnityEngine;

public class CardsDataManager : MonoBehaviour
{
    string filePath = "Assets/Data CSV/CarDataForCardGame.csv";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CSVParser.ParseCSV(filePath);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
