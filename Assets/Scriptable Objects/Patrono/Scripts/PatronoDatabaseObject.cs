using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Patrono Database", menuName ="Inventory System/Items/DatabaseP")]
public class PatronoDatabaseObject : ScriptableObject, ISerializationCallbackReceiver
{
    public PatronoObject[] Patronos;
    public Dictionary<int, PatronoObject> GetItem = new Dictionary<int, PatronoObject>();
    public void OnAfterDeserialize()
    {
        
        for (int i = 0; i < Patronos.Length; i++)
        {
            //IDS
            Patronos[i].idP = i;
            GetItem.Add( i, Patronos[i]);
        }
    }

    public void OnBeforeSerialize()
    {
        GetItem = new Dictionary<int, PatronoObject>();
    }
    

}
