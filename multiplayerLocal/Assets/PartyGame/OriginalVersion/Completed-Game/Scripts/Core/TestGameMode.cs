using UnityEngine;

/// <summary>
/// Script de prueba para verificar que el sistema de GameMode funciona correctamente
/// Agregar este script a un GameObject en la escena para probar
/// </summary>
public class TestGameMode : MonoBehaviour
{
    private void Start()
    {
        // Verificar que GameModeManager existe
        if (GameModeManager.Instance == null)
        {
            Debug.LogError("TestGameMode: GameModeManager.Instance es null!");
            return;
        }
        
        IGameMode currentMode = GameModeManager.Instance.CurrentGameMode;
        
        Debug.Log($"TestGameMode: Modo actual es {(currentMode.IsNetworked ? "ONLINE (Photon)" : "LOCAL")}");
        
        // Probar autoridad
        bool hasAuth = currentMode.HasAuthority(gameObject);
        Debug.Log($"TestGameMode: Este objeto tiene autoridad: {hasAuth}");
        
        // Probar spawn (solo si hay un prefab de prueba)
        // GameObject testObj = currentMode.SpawnPlayer(Vector3.zero, testPrefab, 0);
    }
    
    private void Update()
    {
        // Mostrar modo actual en cada frame (solo para testing)
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (GameModeManager.Instance != null)
            {
                IGameMode mode = GameModeManager.Instance.CurrentGameMode;
                Debug.Log($"TestGameMode: Modo actual = {(mode.IsNetworked ? "ONLINE" : "LOCAL")}");
            }
        }
    }
}

