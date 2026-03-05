using UnityEngine;

public class Town
{
    public double latitude;
    public double longitude;
    public string name;
    public int population;

    public Town(string name, double latitude, double longitude, int population)
    {
        this.latitude = latitude;
        this.longitude = longitude;
        this.name = name;
        this.population = population;
    }
}
