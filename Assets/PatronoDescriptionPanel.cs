using UnityEngine;
using TMPro;

public class PatronoDescriptionPanel : MonoBehaviour
{
    public TMP_Text descriptionText; // Referência ao componente de texto onde a descrição será exibida

    public PatronoDatabaseObject patronoDatabase;

    public void UpdateDescription(int patronoId)
    {
        // Verifica se o patrono está no banco de dados
        if (patronoDatabase.GetItem.ContainsKey(patronoId))
        {
            PatronoObject patrono = patronoDatabase.GetItem[patronoId];
            // Verifica se o patrono possui uma descrição
            if (patrono.description != null)
            {
                // Atualiza o texto da descrição no painel de descrição
                descriptionText.text = patrono.description.textContent;
            }
            else
            {
                Debug.LogWarning("Nenhuma descrição disponível para este patrono.");
                // Se não houver descrição, limpe o texto
                descriptionText.text = "";
            }
        }
        else
        {
            Debug.LogWarning("Item não encontrado no banco de dados.");
            // Se o patrono não estiver no banco de dados, limpe o texto
            descriptionText.text = "";
        }
    }
}