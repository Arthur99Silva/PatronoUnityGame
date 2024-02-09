using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dark Patrono", menuName = "Inventory System/Patronos/DarkPatrono")]
public class DarkPatrono : PatronoObject
{
    public void Awake()
    {
        ptype = PatronoType.Dark;
    }
}