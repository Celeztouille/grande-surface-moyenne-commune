using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using System.IO;
using System.Linq;

public class FilterList : MonoBehaviour
{
    [SerializeField] private int minPeople;
    [SerializeField] private int maxPeople;
    
    // 0     1     2             3             4                       5   6              7     8     9
    // INSEE POST  LAT           LONG          NAME                    DEP REG            POP : 2015  2021
    // 01001,01400,46.1534255214,4.92611354223,L'Abergement-Clémenciat,Ain,Auvergne-Rhône-Alpes,767.0,832.0
    void Start()
    {
        string[] data = Read();

        List<string> validLines = new List<string>();

        int i = 0;
        
        foreach(string line in data)
        {
            string[] splits = line.Split(',');
            
            if (string.IsNullOrEmpty(splits[^1])) continue;
            
            int population = Mathf.RoundToInt(float.Parse(splits[^1], CultureInfo.InvariantCulture));

            if (population >= minPeople && population <= maxPeople)
            {
                validLines.Add(line);
            }

            i++;
            
            if (i%10 == 0) Debug.Log(i);
        }

        List<string> filterDoubles = validLines.Distinct().ToList();
        File.WriteAllLines("Assets/Data/communes_filtered.csv", filterDoubles);
    }

    protected string[] Read()
    {
        string path = $"Assets/Data/communes_full.csv";
        return File.ReadAllLines(path);
    }
}
