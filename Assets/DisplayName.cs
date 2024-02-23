using UnityEngine;
using TMPro;

public class DisplayName : MonoBehaviour
{
    //public int patronoObjectID; // ID do objeto Scriptable na database
    public PatronoDatabaseObject database;
    public TextMeshProUGUI textField;

    // void Start()
    // {
    //     if (database != null && textField != null)
    //     {
    //         if (database.GetItem.ContainsKey(patronoObjectID))
    //         {
    //             PatronoObject patronoObject = database.GetItem[patronoObjectID];
    //             textField.text = patronoObject.objectName;
    //         }
    //         else
    //         {
    //             Debug.LogWarning("Objeto com ID " + patronoObjectID + " não encontrado na database.");
    //         }
    //     }
    // }
}
