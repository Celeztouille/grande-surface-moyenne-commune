using System;
using UnityEngine;

public class PinSetter : MonoBehaviour
{
    [SerializeField] private int mapSize = 500;
    [SerializeField] private double minLat;
    [SerializeField] private double maxLat;
    [SerializeField] private double minLong;
    [SerializeField] private double maxLong;
    [SerializeField] private RectTransform pin;

    [SerializeField] private double testLat;
    [SerializeField] private double testLong;

    [ContextMenu("Set Pin")]
    public void SetPinTest()
    {
        float x = Mathf.InverseLerp((float)minLong, (float)maxLong, (float)testLong);
        float y =  Mathf.InverseLerp((float)minLat, (float)maxLat, (float)testLat);
        
        pin.anchoredPosition = new Vector2(x * mapSize, y * mapSize);
        
        pin.gameObject.SetActive(true);
    }
    
    public void SetPin(double latitude, double longitude)
    {
        float x = Mathf.InverseLerp((float)minLong, (float)maxLong, (float)longitude);
        float y =  Mathf.InverseLerp((float)minLat, (float)maxLat, (float)latitude);
        
        pin.anchoredPosition = new Vector2(x * mapSize, y * mapSize);
        
        pin.gameObject.SetActive(true);
    }
    
    public void Reset()
    {
        pin.anchoredPosition = Vector2.zero;
        pin.gameObject.SetActive(false);
    }
}
