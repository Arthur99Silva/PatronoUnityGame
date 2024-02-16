using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum PatronoType
{
    Fire,
    Water,
    Dark,
    Light
}

public enum Stats
{
    Agillity,
    Elemental,
    Strenght

}

public abstract class PatronoObject : ScriptableObject
{
    public string objectName; // Adiciona uma propriedade para armazenar o nome do objeto
    public Descriptions description;
    public NamePatrono namePatrono;
    public int idP;
    public Sprite uiDisplay;
    public PatronoType ptype;
    public PatronoStats[] stats;

    public Patrono CreatePatrono()
    {
        Patrono newPatrono = new Patrono(this);
        newPatrono.Name = objectName;
        return newPatrono;
    }
}

[System.Serializable]
public class Patrono
{
    public string Name;
    public int idP;
    public PatronoStats[] stats;
    public Patrono()
    {
        Name = "";
        idP = -1;
    }
    public Patrono(PatronoObject patrono)
    {
        Name = patrono.name;
        idP = patrono.idP;
        stats = new PatronoStats[patrono.stats.Length];
        for (int i = 0; i < stats.Length; i++)
        {
            stats[i] = new PatronoStats(patrono.stats[i].min, patrono.stats[i].max)
            {
                statsP = patrono.stats[i].statsP
            };
        }
    }
}

[System.Serializable]
public class PatronoStats
{
    public Stats statsP;
    public int value;
    public int min;
    public int max;
    public PatronoStats(int _min, int _max)
    {
        min = _min;
        max = _max;
        GenerateValue();
    }

    public void AddValue(ref int baseValue)
    {
        baseValue += value;
    }

    public void GenerateValue()
    {
        value = UnityEngine.Random.Range(min, max);
    }
}
