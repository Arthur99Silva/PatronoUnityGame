using UnityEngine;
using TMPro;

public class UpdateTextWithObjectName : MonoBehaviour
{
    public GroundPatrono groundPatrono;
    private TextMeshProUGUI textField;

    void Start()
    {
        textField = GetComponentInChildren<TextMeshProUGUI>();

        if (textField == null)
        {
            Debug.LogError("No TextMeshPro component found!");
            return;
        }

        if (groundPatrono == null || groundPatrono.patrono == null)
        {
            Debug.LogError("No GroundPatrono or PatronoObject assigned!");
            return;
        }

        // Atualiza o texto com o nome do PatronoObject associado ao GroundPatrono
        textField.text = groundPatrono.patrono.objectName;
    }
}
