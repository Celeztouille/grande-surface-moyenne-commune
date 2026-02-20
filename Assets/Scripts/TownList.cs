using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using Random = UnityEngine.Random;

public class TownList : MonoBehaviour
{
    private List<Town> towns = new List<Town>();

    public int MaxRange => towns.Count;

    private void Awake()
    {
        StartCoroutine(LoadCSV());
    }

    // 0     1     2             3             4                       5   6                    7     8
    // INSEE POST  LAT           LONG          NAME                    DEP REG            POP : 2015  2021
    // 01001,01400,46.1534255214,4.92611354223,L'Abergement-Clémenciat,Ain,Auvergne-Rhône-Alpes,767.0,832.0
    private void Init()
    {
        TextAsset csv = Resources.Load<TextAsset>("communes_filtered");
        string[] stowns = csv.text.Split('\n');

        towns.Clear();
        
        foreach (string s in stowns)
        {
            string[] splits = s.Split(',');
            if (splits.Length < 4)
            {
                Debug.LogError($"Ligne trop courte : {s}");
                return;
            }

            string latStr = splits[2].Trim();
            string lonStr = splits[3].Trim();
            string popStr = splits[8].Trim();

            if (!double.TryParse(latStr, NumberStyles.Float, CultureInfo.InvariantCulture, out double lat))
            {
                Debug.LogError($"Latitude invalide: '{latStr}' | ligne: {s}");
                continue;
            }

            if (!double.TryParse(lonStr, NumberStyles.Float, CultureInfo.InvariantCulture, out double lon))
            {
                Debug.LogError($"Longitude invalide: '{lonStr}' | ligne: {s}");
                continue;
            }
            
            if (!float.TryParse(popStr, NumberStyles.Float, CultureInfo.InvariantCulture, out float pop))
            {
                Debug.LogError($"Population invalide: '{popStr}' | ligne: {s}");
                continue;
            }

            towns.Add(new Town(splits[4].Trim(), lat, lon, Mathf.RoundToInt(pop)));
        }
    }
    
    IEnumerator LoadCSV()
    {
        towns.Clear();
        string path = System.IO.Path.Combine(Application.streamingAssetsPath, "communes_filtered.csv");

        UnityWebRequest req = UnityWebRequest.Get(path);
        yield return req.SendWebRequest();

        if (req.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError($"Erreur CSV: {req.error}");
            yield break;
        }

        string csvText = req.downloadHandler.text;
        ParseCSV(csvText);
    }

    void ParseCSV(string csv)
    {
        string[] lines = csv.Split('\n');
        foreach (string line in lines)
        {
            string[] splits = line.Split(',');
            if (splits.Length < 4)
            {
                Debug.LogError($"Ligne trop courte : {line}");
                return;
            }

            string latStr = splits[2].Trim();
            string lonStr = splits[3].Trim();
            string popStr = splits[8].Trim();

            if (!double.TryParse(latStr, NumberStyles.Float, CultureInfo.InvariantCulture, out double lat))
            {
                Debug.LogError($"Latitude invalide: '{latStr}' | ligne: {line}");
                continue;
            }

            if (!double.TryParse(lonStr, NumberStyles.Float, CultureInfo.InvariantCulture, out double lon))
            {
                Debug.LogError($"Longitude invalide: '{lonStr}' | ligne: {line}");
                continue;
            }
            
            if (!float.TryParse(popStr, NumberStyles.Float, CultureInfo.InvariantCulture, out float pop))
            {
                Debug.LogError($"Population invalide: '{popStr}' | ligne: {line}");
                continue;
            }

            towns.Add(new Town(splits[4].Trim(), lat, lon, Mathf.RoundToInt(pop)));
        }
    }

    [ContextMenu("Random Town")]
    public void GetRandomTown()
    {
        int i = Random.Range(0, towns.Count);
        
        Debug.Log($"Random town is : {towns[i].name}");
    }

    public Town GetTownAtIndex(int index)
    {
        if (index >= towns.Count)
        {
            Debug.LogError("[ShopList] OutOfRange");
        }

        return towns[index];
    }
}
