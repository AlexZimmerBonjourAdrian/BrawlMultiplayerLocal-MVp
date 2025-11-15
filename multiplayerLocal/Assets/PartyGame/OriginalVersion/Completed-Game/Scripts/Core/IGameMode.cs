using UnityEngine;

/// <summary>
/// Interface que define el contrato para diferentes modos de juego (Local y Online)
/// </summary>
public interface IGameMode
{
    /// <summary>
    /// Indica si el modo actual es online (networked)
    /// </summary>
    bool IsNetworked { get; }
    
    /// <summary>
    /// Spawn de un jugador en el modo correspondiente
    /// </summary>
    /// <param name="position">Posición donde spawnear</param>
    /// <param name="prefab">Prefab del jugador</param>
    /// <param name="playerIndex">Índice del jugador</param>
    /// <returns>GameObject instanciado</returns>
    GameObject SpawnPlayer(Vector3 position, GameObject prefab, int playerIndex);
    
    /// <summary>
    /// Spawn de un proyectil en el modo correspondiente
    /// </summary>
    /// <param name="position">Posición donde spawnear</param>
    /// <param name="prefab">Prefab del proyectil</param>
    /// <returns>GameObject instanciado</returns>
    GameObject SpawnProjectile(Vector3 position, GameObject prefab);
    
    /// <summary>
    /// Verifica si el objeto tiene autoridad (puede ser controlado)
    /// </summary>
    /// <param name="obj">Objeto a verificar</param>
    /// <returns>True si tiene autoridad, False si no</returns>
    bool HasAuthority(GameObject obj);
    
    /// <summary>
    /// Inicializa el modo de juego
    /// </summary>
    void Initialize();
    
    /// <summary>
    /// Limpia recursos del modo de juego
    /// </summary>
    void Cleanup();
}

