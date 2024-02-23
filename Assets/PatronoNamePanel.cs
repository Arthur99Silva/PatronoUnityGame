using UnityEngine;
using TMPro;

public class PatronoNamePanel : MonoBehaviour
{
    public TMP_Text nameText; // Referência ao componente de texto onde a descrição será exibida

    public PatronoDatabaseObject patronoDatabase;

    public void UpdateName(int patronoId)
    {
        // Verifica se o patrono está no banco de dados
        if (patronoDatabase.GetItem.ContainsKey(patronoId))
        {
            PatronoObject patrono = patronoDatabase.GetItem[patronoId];
            // Verifica se o patrono possui uma descrição
            if (patrono.namePatrono != null)
            {
                Debug.LogWarning("Apareceu nome!!!");
                // Atualiza o texto da descrição no painel de descrição
                nameText.text = patrono.namePatrono.textContent;
            }
            else
            {
                Debug.LogWarning("Nenhuma descrição disponível para este patrono.");
                // Se não houver descrição, limpe o texto
                nameText.text = "";
            }
        }
        else
        {
            Debug.LogWarning("Item não encontrado no banco de dados.");
            // Se o patrono não estiver no banco de dados, limpe o texto
            nameText.text = "";
        }
    }
}
