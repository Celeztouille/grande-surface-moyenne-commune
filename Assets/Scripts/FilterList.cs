using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FilterList : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FileStream fs = File.OpenRead("Assets/Data/communes_full");

        for (int i = 0; i < 10; i++)
        {
            ReadLines
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
