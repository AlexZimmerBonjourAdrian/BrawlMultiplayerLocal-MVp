using UnityEngine;

/// <summary>
/// Implementación del modo de juego local (sin red)
/// </summary>
public class LocalGameMode : IGameMode
{
    public bool IsNetworked => false;
    
    public GameObject SpawnPlayer(Vector3 position, GameObject prefab, int playerIndex)
    {
        return Object.Instantiate(prefab, position, Quaternion.identity);
    }
    
    public GameObject SpawnProjectile(Vector3 position, GameObject prefab)
    {
        return Object.Instantiate(prefab, position, Quaternion.identity);
    }
    
    public bool HasAuthority(GameObject obj)
    {
        // En modo local, siempre tenemos autoridad
        return true;
    }
    
    public void Initialize()
    {
        // Setup local - no hay configuración especial necesaria
    }
    
    public void Cleanup()
    {
        // Cleanup local - no hay recursos especiales que limpiar
    }
}

