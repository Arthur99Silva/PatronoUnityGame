using UnityEngine;

[CreateAssetMenu(fileName = "NewTextAsset", menuName = "Assets/Scriptable Objects/Items/Descriptions", order = 1)]
public class Descriptions : ScriptableObject
{
    [TextArea(15, 20)]
    public string textContent;
}

