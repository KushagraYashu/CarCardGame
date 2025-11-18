using System;
using System.IO;
using UnityEngine;
using UnityEngine.Windows;

public static class CSVParser
{
    public enum CarClasses
    {
        NON,
        HTB,    //Hatchback
        SUV,    //SUV
        OFF,    //Offroad
        SDN,    //Sedan
        STG,    //Station Wagon
        SPR,    //Sports
        CON,    //Convertible
        COU,    //Coupe
        MUS,    //Muscle
        HYB,    //Hybrid
        ELV,    //Electric Vehicle
        VAN,    //Van and Performance Vans
        TRK,    //Trucks except Pickups
        PKT,    //Pickup Trucks except Performance or Baja Trucks (they go in offroad)
        LUX     //Luxury Cars (most of these can be categorised as sedans so this will include extremely expensive sedans, rest can go to SDN)
    }

    public class CarProperties
    {
        public string name;

        public CarClasses primaryClass;
        public CarClasses secondaryClass;

        public int paceRating;
        public int abilityRating;
        public int resilienceRating;
        public int reliabilityRating;
        public int styleRating;
        public int appealRating;

        public float overallRating;

        public string iconName;
        public string iconBlurName;

        public int order;

        public CarProperties()
        {
            name = "Default";

            primaryClass = CarClasses.NON;
            secondaryClass = CarClasses.NON;

            paceRating = 0;
            abilityRating = 0;
            resilienceRating = 0;
            reliabilityRating = 0;
            styleRating = 0;
            appealRating = 0;
            overallRating = 0.0f;

            iconName = "default_icon";
            iconBlurName = "default_icon_blur";

            order = 10;
        }
    }

    public static void ParseCSV(string filePath)
    {
        string csvText = System.IO.File.ReadAllText(filePath);
        string[] rows = csvText.Split('\n');

        for (int i = 2; i < rows.Length - 1; i++) {
            // lets make sense of the row now
            string[] elements = rows[i].Split(',');
            
            CarProperties carProperties = new();

            string carClass = elements[0];
            carProperties.name = elements[1];
            carProperties.paceRating = int.Parse(elements[2]);
            carProperties.abilityRating = int.Parse(elements[3]);
            carProperties.resilienceRating = int.Parse(elements[4]);
            carProperties.reliabilityRating = int.Parse(elements[5]);
            carProperties.styleRating = int.Parse(elements[6]);
            carProperties.appealRating = int.Parse(elements[7]);
            carProperties.overallRating = float.Parse(elements[8]);
            carProperties.iconName = elements[9];
            carProperties.iconBlurName = elements[10];
            carProperties.order += i;

            string[] allClasses = carClass.Split('-');
            for(int j = 0; j < allClasses.Length; j++) {
                if (Enum.TryParse<CarClasses>(allClasses[j], true, out CarClasses result))
                {
                    if(j == 0)
                    {
                        carProperties.primaryClass = result;
                    }
                    else
                    {
                        carProperties.secondaryClass = result;
                    }
                }
            }

            GameManager.Instance.CreateCards(carProperties);
        }
    }

}
