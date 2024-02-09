using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Light Patrono", menuName = "Inventory System/Patronos/LightPatrono")]
public class LightPatrono : PatronoObject
{
    public void Awake()
    {
        ptype = PatronoType.Light;
    }
}