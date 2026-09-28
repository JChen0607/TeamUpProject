using System;
using UnityEngine;

public class Spraycans : MonoBehaviour, IItems
{
    public static event Action<int> OnSpraycansCollect;
    public int SpraycansValue = 1;
    public void Collect()
    {
        OnSpraycansCollect.Invoke (SpraycansValue);
        Destroy(gameObject);
    }
    
}
