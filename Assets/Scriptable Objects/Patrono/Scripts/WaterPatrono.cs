using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Water Patrono", menuName = "Inventory System/Patronos/WaterPatrono")]
public class WaterPatrono : PatronoObject
{
    public void Awake()
    {
        ptype = PatronoType.Water;
    }
}