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


    public static void ParseCSV(string filePath)
    {
        string csvText = System.IO.File.ReadAllText(filePath);
        string[] rows = csvText.Split('\n');

        for (int i = 2; i < rows.Length - 1; i++) {
            // lets make sense of the row now
            string[] elements = rows[i].Split(',');
            string carClass = elements[0];
            string carName = elements[1];
            string paceRating = elements[2];
            string abilityRating = elements[3];
            string resilienceRating = elements[4];
            string reliabilityRating = elements[5];
            string styleRating = elements[6];
            string appealRating = elements[7];
            string overallRating = elements[8];

            CarData carData = new();
            CarClasses primaryClass = CarClasses.NON;
            CarClasses secondaryClass = CarClasses.NON;

            string[] allClasses = carClass.Split('-');
            for(int j = 0; j < allClasses.Length; j++) {
                if (Enum.TryParse<CarClasses>(allClasses[j], true, out CarClasses result))
                {
                    if(j == 0)
                    {
                        primaryClass = result;
                    }
                    else
                    {
                        secondaryClass = result;
                    }
                }
            }

            carData.SetData(
                carName,
                primaryClass, secondaryClass,
                new int[] {
                    int.Parse(paceRating),
                    int.Parse(abilityRating),
                    int.Parse(resilienceRating),
                    int.Parse(reliabilityRating),
                    int.Parse(styleRating),
                    int.Parse(appealRating)
                },
                float.Parse(overallRating)
            );

            carData.DisplayCarData();
        }
    }

}
