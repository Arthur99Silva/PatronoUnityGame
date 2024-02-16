using UnityEngine;

[CreateAssetMenu(fileName = "NewTextAsset", menuName = "Assets/Scriptable Objects/Patrono/Name", order = 1)]
public class NamePatrono : ScriptableObject
{
    [TextArea(15, 20)]
    public string textContent;
}