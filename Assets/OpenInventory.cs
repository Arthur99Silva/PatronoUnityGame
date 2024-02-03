using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    public GameObject InventoryMenu;
    public GameObject EquipamentMenu;
    public Camera playerCamera; // Referência à câmera do jogador
    private bool isPaused = false;

    // Guarde a referência para o script de controle da câmera
    private MonoBehaviour cameraMovementScript;

    void Start()
    {
        // Tente encontrar um script de movimento da câmera no objeto da câmera
        cameraMovementScript = playerCamera.GetComponent<MonoBehaviour>();
    }

    void Update()
    {
        // Verifica se a tecla "I" foi pressionada
        if (Input.GetKeyDown(KeyCode.I))
        {
            // Inverte o estado do pause
            isPaused = !isPaused;

            // Ativa/desativa o menu de inventário conforme necessário
            InventoryMenu.SetActive(isPaused);
            EquipamentMenu.SetActive(isPaused);

            // Pausa ou retoma o jogo alterando a escala de tempo
            Time.timeScale = isPaused ? 0f : 1f;

            // Pausa ou retoma o movimento da câmera
            PauseCameraMovement(isPaused);

            // Habilita ou desabilita a captura do cursor
            if (isPaused)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    void PauseCameraMovement(bool pause)
    {
        // Pausa ou retoma o movimento da câmera
        if (cameraMovementScript != null)
        {
            cameraMovementScript.enabled = !pause;
        }
    }
}
