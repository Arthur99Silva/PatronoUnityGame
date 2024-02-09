using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;
using System.Runtime.Serialization;
//using FileMode = System.IO.FileMode;// OLHA AQ So POR ISSTO TA FUNCIONAL

[ CreateAssetMenu(fileName = "New Inventory Patrono", menuName = "Inventory System/Patrono Inventory")]

public class InventoryPatrono : ScriptableObject
{
    public string savePath;
    public PatronoDatabaseObject database;

    public InventoryP ContainerP;

    public void AddPatronoPower(Patrono _patrono, int _amount)
    {
        if(_patrono.stats.Length > 0)
        {
            SetEmptySlotP(_patrono, _amount);
            return;
        }

        for (int i = 0; i < ContainerP.Patronos.Length; i++)
        {
            if (ContainerP.Patronos[i].IDP == _patrono.idP)
            {
                ContainerP.Patronos[i].AddAmount(_amount);
                return;
            }
        }
        SetEmptySlotP(_patrono, _amount);
    }

    public PatronoSlot SetEmptySlotP(Patrono _patrono, int _amount)
    {
        for (int i = 0; i < ContainerP.Patronos.Length; i++)
        {
            if(ContainerP.Patronos[i].IDP <= -1)
            {
                ContainerP.Patronos[i].UpdateSlotP(_patrono.idP, _patrono, _amount);
                return ContainerP.Patronos[i];
            }
        }
        //inv full
        return null;
    }

    public void MovePatrono(PatronoSlot patrono1, PatronoSlot patrono2)
    {
        PatronoSlot temp = new PatronoSlot(patrono2.IDP, patrono2.patrono, patrono2.amount);
        patrono2.UpdateSlotP(patrono1.IDP, patrono1.patrono, patrono1.amount);
        patrono1.UpdateSlotP(temp.IDP, temp.patrono, temp.amount);
    }

    public void RemovePatrono(PatronoSlot _patronoSlot)
{
    for (int i = 0; i < ContainerP.Patronos.Length; i++)
    {
        if(ContainerP.Patronos[i].IDP == _patronoSlot.IDP){
            ContainerP.Patronos[i].UpdateSlotP(-1, null, 0);
        }
    }
}


[ContextMenu("Save")]
public void Save()
    {
        string saveData = JsonUtility.ToJson(this, true);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
        bf.Serialize(file, saveData);
        file.Close();

        // IFormatter formatter = new BinaryFormatter();
        // Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Create, FileAccess.Write);
        // formatter.Serialize(stream, ContainerP);
        // stream.Close();
    }

    [ContextMenu("Load")]
    public void Load()
    {
        if(File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open);
            JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            file.Close();

        // IFormatter formatter = new BinaryFormatter();
        // Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Open, FileAccess.Read);
        // Inventory newContainer = (Inventory)formatter.Deserialize(stream);
        // for (int i = 0; i < ContainerP.Items.Length; i++)
        // {
        //     ContainerP.Items[i].UpdateSlotP(newContainer.Items[i].IDP, newContainer.Items[i].item, newContainer.Items[i].amount);
        // }
        // stream.Close();
        }
    }


[ContextMenu("Clear")]
    public void Clear()
    {
        ContainerP.Clear();
    }
}
   
[System.Serializable]
public class InventoryP
{
    public PatronoSlot[] Patronos = new PatronoSlot[50];
    public void Clear()
    {
        for (int i = 0; i < Patronos.Length; i++)
        {
            Patronos[i].UpdateSlotP(-1, new Patrono(), 0);
        }
    }
}

[System.Serializable]
public class PatronoSlot
{
    public PatronoType[] AllowedPatronos = new PatronoType[0];
    public PatronoInterface parent;
    public int IDP = -1;
    public Patrono patrono;
    public int amount;
    public PatronoSlot()
    {
        IDP = - 1;
        patrono = null;
        amount = 0;
    }
    public PatronoSlot(int _id, Patrono _patrono, int _amount)
    {
        IDP = _id;
        patrono = _patrono;
        amount = _amount;
    }

public void UpdateSlotP(int _id, Patrono _patrono, int _amount)
    {
        IDP = _id;
        patrono = _patrono;
        amount = _amount;
    }
    public void AddAmount(int value)
    {
        amount += value;
    }
    public bool CanPlaceInSlotP(PatronoObject _patrono)
    {
        if(AllowedPatronos.Length <= 0)
        {
            return true;
        }
        for (int i = 0; i < AllowedPatronos.Length; i++)
        {
            if(_patrono.ptype == AllowedPatronos[i])
            {
                return true;
            }
        }
        return false;
    }
}