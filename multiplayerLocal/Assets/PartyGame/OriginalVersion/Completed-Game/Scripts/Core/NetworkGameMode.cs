using UnityEngine;

#if PUN_2_OR_NEWER
using Photon.Pun;
#endif

/// <summary>
/// Implementación del modo de juego online (con Photon)
/// </summary>
public class NetworkGameMode : IGameMode
{
    public bool IsNetworked => true;
    
    public GameObject SpawnPlayer(Vector3 position, GameObject prefab, int playerIndex)
    {
#if PUN_2_OR_NEWER
        if (PhotonNetwork.IsConnected && PhotonNetwork.InRoom)
        {
            // El prefab debe estar en la carpeta Resources para PhotonNetwork.Instantiate
            return PhotonNetwork.Instantiate(prefab.name, position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Photon no está conectado, usando Instantiate local como fallback");
            return Object.Instantiate(prefab, position, Quaternion.identity);
        }
#else
        Debug.LogError("Photon PUN no está disponible. Usando modo local como fallback.");
        return Object.Instantiate(prefab, position, Quaternion.identity);
#endif
    }
    
    public GameObject SpawnProjectile(Vector3 position, GameObject prefab)
    {
#if PUN_2_OR_NEWER
        if (PhotonNetwork.IsConnected && PhotonNetwork.InRoom)
        {
            return PhotonNetwork.Instantiate(prefab.name, position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Photon no está conectado, usando Instantiate local como fallback");
            return Object.Instantiate(prefab, position, Quaternion.identity);
        }
#else
        Debug.LogError("Photon PUN no está disponible. Usando modo local como fallback.");
        return Object.Instantiate(prefab, position, Quaternion.identity);
#endif
    }
    
    public bool HasAuthority(GameObject obj)
    {
#if PUN_2_OR_NEWER
        PhotonView pv = obj.GetComponent<PhotonView>();
        return pv != null && pv.IsMine;
#else
        // Si Photon no está disponible, asumimos autoridad (fallback a local)
        return true;
#endif
    }
    
    public void Initialize()
    {
#if PUN_2_OR_NEWER
        // Setup Photon - verificar conexión
        if (!PhotonNetwork.IsConnected)
        {
            Debug.LogWarning("NetworkGameMode: Photon no está conectado. Algunas funcionalidades pueden no funcionar.");
        }
#else
        Debug.LogWarning("NetworkGameMode: Photon PUN no está disponible. El modo online no funcionará correctamente.");
#endif
    }
    
    public void Cleanup()
    {
        // Cleanup Photon - no hay recursos especiales que limpiar aquí
        // La desconexión se maneja en otros lugares
    }
}

