using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerP : MonoBehaviour
{
    public MousePatrono mousePatrono = new MousePatrono();
    public InventoryPatrono inventoryP;

    public void OnTriggerEnter(Collider other)
    {
        var patrono = other.GetComponent<GroundPatrono>();
        if (patrono)
        {
            inventoryP.AddPatronoPower(new Patrono(patrono.patrono), 1);
            Destroy(other.gameObject);
        }
    }

    private void Update()
    {   //K SALVA
        if(Input.GetKeyDown(KeyCode.N))
        {
            inventoryP.Save();
        }
        if(Input.GetKeyDown(KeyCode.B)) // J CARREGA
        {
            inventoryP.Load();
        }
    }
    
    private void OnApplicationQuit()
    {
        inventoryP.ContainerP.Patronos = new PatronoSlot[50];
    }
}
