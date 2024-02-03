using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum ItemType
{
    Equipment,
    Food,
    Default
}
public enum Attributes
{
    Agillity,
    Intellect,
    Staminna,
    Strenght

}
public abstract class ItemObject : ScriptableObject
{
    public Descriptions description; // Adicione este campo para armazenar a descrição
    public int Id;
    public Sprite uiDisplay;
    public ItemType type;
    [TextArea(15,20)]
    //public string description;
    public ItemBuff[] buffs;

    public Item CreateItem()
    {
        Item newItem = new Item(this);
        return newItem;
    }
}

[System.Serializable]
public class Item
{
    public string Name;
    public int Id;
    //public string Description;
    public ItemBuff[] buffs;
    public Item()
    {
        Name = "";
        Id = -1;
        //Description = "";
        
    }
    public Item(ItemObject item)
    {
        Name = item.name;
        Id = item.Id;
        //Description = item.description;
        buffs = new ItemBuff[item.buffs.Length];
        for (int i = 0; i < buffs.Length; i++)
        {
            buffs[i] = new ItemBuff(item.buffs[i].min, item.buffs[i].max)
            {
                attribute = item.buffs[i].attribute
            };
        }
    }
}

[System.Serializable]
public class ItemBuff
{
    public Attributes attribute;
    public int value;
    public int min;
    public int max;
    public ItemBuff(int _min, int _max)
    {
        min = _min;
        max = _max;
        GenerateValue();
    }
    public void GenerateValue()
    {
        value = UnityEngine.Random.Range(min, max);
    }
}
