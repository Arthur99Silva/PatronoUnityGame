using UnityEngine;
using UnityEngine.UI;

public class ItemImagePanel : MonoBehaviour
{
    public Image itemImage; // Referência para a imagem do item no painel

    public ItemDatabaseObject itemDatabase; // Referência para o banco de dados de itens

    public void UpdateImage(int itemId)
    {
        Debug.Log("----------Entrou aqui--------------");
        // Verifica se o item está no banco de dados
        if (itemDatabase.GetItem.ContainsKey(itemId))
        {
            Debug.Log("Verificou");
            ItemObject item = itemDatabase.GetItem[itemId];
            // Atualiza a imagem do item no painel
            itemImage.sprite = item.uiDisplay;
        }
        else
        {
            Debug.LogWarning("Item não encontrado no banco de dados.");
            // Se o item não estiver no banco de dados, limpe a imagem
            itemImage.sprite = null;
        }
    }
}

