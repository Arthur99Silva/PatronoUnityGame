using UnityEngine;
using TMPro;

public class ItemDescriptionPanel : MonoBehaviour
{
    public TMP_Text descriptionText; // Referência ao componente de texto onde a descrição será exibida

    public ItemDatabaseObject itemDatabase;

    public void UpdateDescription(int itemId)
    {
        // Verifica se o item está no banco de dados
        if (itemDatabase.GetItem.ContainsKey(itemId))
        {
            ItemObject item = itemDatabase.GetItem[itemId];
            // Verifica se o item possui uma descrição
            if (item.description != null)
            {
                // Atualiza o texto da descrição no painel de descrição
                descriptionText.text = item.description.textContent;
            }
            else
            {
                Debug.LogWarning("Nenhuma descrição disponível para este item.");
                // Se não houver descrição, limpe o texto
                descriptionText.text = "";
            }
        }
        else
        {
            Debug.LogWarning("Item não encontrado no banco de dados.");
            // Se o item não estiver no banco de dados, limpe o texto
            descriptionText.text = "";
        }
    }
}
