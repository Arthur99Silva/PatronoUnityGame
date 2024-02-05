using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTextAsset", menuName = "Assets/Scriptable Objects/Items/Images", order = 1)]
public class Images : ScriptableObject
{
    public Image images;
    public Sprite display;
}
