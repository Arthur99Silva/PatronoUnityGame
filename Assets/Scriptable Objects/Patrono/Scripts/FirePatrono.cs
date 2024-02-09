using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fire Patrono", menuName = "Inventory System/Patronos/FirePatrono")]
public class FirePatrono : PatronoObject
{
    public void Awake()
    {
        ptype = PatronoType.Fire;
    }
}