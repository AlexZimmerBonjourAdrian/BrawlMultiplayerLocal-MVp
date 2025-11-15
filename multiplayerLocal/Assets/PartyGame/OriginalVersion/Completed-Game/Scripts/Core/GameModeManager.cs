using UnityEngine;

#if PUN_2_OR_NEWER
using Photon.Pun;
#endif

/// <summary>
/// Manager singleton que gestiona el modo de juego actual (Local o Online)
/// </summary>
public class GameModeManager : MonoBehaviour
{
    private static GameModeManager _instance;
    private IGameMode _currentGameMode;
    
    public static GameModeManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject obj = new GameObject("GameModeManager");
                _instance = obj.AddComponent<GameModeManager>();
                DontDestroyOnLoad(obj);
            }
            return _instance;
        }
    }
    
    public IGameMode CurrentGameMode
    {
        get
        {
            if (_currentGameMode == null)
            {
                DetectAndSetGameMode();
            }
            return _currentGameMode;
        }
    }
    
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        _instance = this;
        DontDestroyOnLoad(gameObject);
        
        DetectAndSetGameMode();
    }
    
    /// <summary>
    /// Detecta automáticamente el modo de juego basado en la conexión de Photon
    /// </summary>
    private void DetectAndSetGameMode()
    {
#if PUN_2_OR_NEWER
        if (PhotonNetwork.IsConnected && PhotonNetwork.InRoom)
        {
            _currentGameMode = new NetworkGameMode();
            Debug.Log("GameModeManager: Modo Online (Photon) detectado");
        }
        else
        {
            _currentGameMode = new LocalGameMode();
            Debug.Log("GameModeManager: Modo Local detectado");
        }
#else
        _currentGameMode = new LocalGameMode();
        Debug.Log("GameModeManager: Modo Local detectado (Photon no disponible)");
#endif
        
        _currentGameMode.Initialize();
    }
    
    /// <summary>
    /// Fuerza un modo de juego específico (útil para testing)
    /// </summary>
    public void SetGameMode(IGameMode gameMode)
    {
        if (_currentGameMode != null)
        {
            _currentGameMode.Cleanup();
        }
        
        _currentGameMode = gameMode;
        _currentGameMode.Initialize();
        
        Debug.Log($"GameModeManager: Modo cambiado a {(gameMode.IsNetworked ? "Online" : "Local")}");
    }
    
    /// <summary>
    /// Fuerza modo local (útil para testing)
    /// </summary>
    public void ForceLocalMode()
    {
        SetGameMode(new LocalGameMode());
    }
    
    /// <summary>
    /// Fuerza modo online (útil para testing, requiere Photon conectado)
    /// </summary>
    public void ForceNetworkMode()
    {
#if PUN_2_OR_NEWER
        SetGameMode(new NetworkGameMode());
#else
        Debug.LogError("No se puede forzar modo online: Photon PUN no está disponible");
#endif
    }
    
    private void OnDestroy()
    {
        if (_currentGameMode != null)
        {
            _currentGameMode.Cleanup();
        }
    }
}

