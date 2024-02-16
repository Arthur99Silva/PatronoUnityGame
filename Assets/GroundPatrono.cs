using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GroundPatrono : MonoBehaviour
{
    public PatronoObject patrono;
    public TextMeshProUGUI textField; // Adicionando referência ao TextMeshPro

    void Start()
    {
        if (patrono != null && textField != null)
        {
            textField.text = patrono.objectName; // Definindo o texto como o nome do objeto
        }
    }
}
