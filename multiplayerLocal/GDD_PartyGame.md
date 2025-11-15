# Game Design Document (GDD)
## PartyGame - Multiplayer Local Brawler

**Versión:** 1.0  
**Fecha:** 2024  
**Plataforma:** PC (Windows)  
**Motor:** Unity 3D  
**Género:** Party Game / Brawler / Fighting Game  
**Modo de Juego:** Multiplayer Local (2-4 jugadores)

---

## 1. Visión General

### 1.1 Concepto del Juego
PartyGame es un juego de lucha en 3D diseñado para sesiones de juego local multijugador. Los jugadores controlan personajes con habilidades especiales y sistemas de transformación, compitiendo en combates dinámicos con mecánicas de combos y ataques especiales.

### 1.2 Propuesta de Valor
- **Multiplayer Local:** Hasta 4 jugadores en la misma máquina
- **Sistema de Combos:** Combos personalizables y encadenables
- **Transformaciones:** Múltiples formas con diferentes estilos de juego
- **Combate Dinámico:** Física realista con Rigidbody
- **Fácil de Aprender, Difícil de Dominar:** Controles simples con profundidad estratégica

### 1.3 Público Objetivo
- Jugadores casuales que buscan experiencias multijugador locales
- Fans de juegos de lucha y party games
- Edad recomendada: 12+

---

## 2. Mecánicas Principales

### 2.1 Movimiento
- **Movimiento Base:** Control direccional con física Rigidbody
- **Velocidad:** Configurable por personaje
- **Rotación:** El personaje rota automáticamente hacia la dirección de movimiento
- **Salto:** Fuerza de impulso vertical configurable
- **Animaciones:** Sistema de animaciones basado en velocidad y estado

### 2.2 Sistema de Combate

#### 2.2.1 Ataques Básicos
- **Attack 1 (Ataque Principal):** Ataque rápido y básico
- **Attack 2 (Ataque Secundario):** Ataque más potente con mayor daño
- **Detección de Golpes:** Sistema de OverlapBox para detectar colisiones
- **Daño:** Sistema de daño configurable por ataque

#### 2.2.2 Sistema de Combos
- **Combo Input System:** Secuencias de ataques (W/S/A/D) para ejecutar combos
- **Combo Chain:** Los combos pueden encadenarse entre sí
- **Delay entre Combos:** Sistema de timing para encadenar combos
- **Combo Básico:** Combo predeterminado disponible desde el inicio
- **Combo Dinámico:** Sistema para detectar y ejecutar combos en tiempo real

#### 2.2.3 Tipos de Ataques
- **Ataques Meele:** Golpes cuerpo a cuerpo
- **Ataques Eléctricos:** Proyectiles eléctricos
- **Ataques de Fuego:** Proyectiles de fuego
- **Ataques Láser:** Proyectiles láser de largo alcance

### 2.3 Sistema de Transformaciones

Los personajes pueden cambiar entre diferentes formas, cada una con características únicas:

#### 2.3.1 Forma Ágil (CForm_Agil)
- Enfoque en velocidad y movilidad
- Ataques rápidos con menor daño

#### 2.3.2 Forma Velocidad (CForm_Speed)
- Movimiento mejorado
- Capacidad de esquivar ataques

#### 2.3.3 Forma Fuerte (CForm_Strong)
- Mayor daño en ataques
- Resistencia mejorada

#### 2.3.4 Forma Distancia (CForm_Distance)
- Ataques a distancia mejorados
- Mayor rango de ataque

### 2.4 Sistema de Proyectiles

- **Bullet Manager:** Gestor singleton para todos los proyectiles
- **Spawn de Proyectiles:** Sistema para instanciar ataques a distancia
- **Garbage Collection:** Limpieza automática de proyectiles destruidos
- **Polimorfismo:** Sistema de herencia para diferentes tipos de proyectiles

---

## 3. Controles

### 3.1 Jugador 1 (Player 0) - Teclado y Mouse

| Acción | Control |
|--------|---------|
| **Movimiento** | `W/A/S/D` o `Flechas Direccionales` |
| **Salto** | `Espacio` |
| **Ataque 1** | `Click Izquierdo` |
| **Ataque 2** | `Click Derecho` |
| **Interactuar** | `Click Medio` |
| **Cambiar Forma** | `1`, `2`, `3`, o `Left Shift` |

### 3.2 Jugador 2 (Player 1) - Gamepad

| Acción | Control (Xbox) | Control (PlayStation) |
|--------|----------------|----------------------|
| **Movimiento** | `Stick Izquierdo` | `Stick Izquierdo` |
| **Ataque 1** | `Botón X` | `Botón Cuadrado` |
| **Ataque 2** | `Botón Y` | `Botón Triángulo` |
| **Salto** | `Botón A` | `Botón X` |
| **Interactuar** | `Botón B` | `Botón Círculo` |
| **Cambiar Forma** | `D-Pad` (cualquier dirección) | `D-Pad` (cualquier dirección) |

### 3.3 Jugador 3 (Player 2) - Gamepad
- Mismo esquema que Jugador 2
- Usa ejes de input: `HorizontalP3` y `VerticalP3`

### 3.4 Jugador 4 (Player 3) - Gamepad
- Mismo esquema que Jugador 2
- Usa ejes de input: `HorizontalP4` y `VerticalP4`

### 3.5 Sistema de Input
- **Unity Input System:** Implementación moderna de Unity
- **Input Actions:** Sistema de acciones configurables
- **Multi-Device Support:** Soporte para múltiples dispositivos simultáneos
- **Control Schemes:** Esquemas de control separados por jugador

---

## 4. Personajes

### 4.1 Personajes Disponibles

#### 4.1.1 Player 1 (CPlayer_1)
- **Clase:** `CPlayer_1 : PlayerController
- **Características:**
  - Movimiento base estándar
  - Sistema de animaciones completo
  - Control de velocidad de animación

#### 4.1.2 Player 2 (CPlayer_2)
- **Clase:** `CPlayer_2 : PlayerController`
- **Características:**
  - Sistema de combos avanzado
  - Lista de ataques personalizables
  - Sistema de animaciones de combate

#### 4.1.3 Player 3 (CPlayer_3)
- **Clase:** `CPlayer_3 : PlayerController`
- **Características:** Similar a Player 2

#### 4.1.4 Player 4 (CPlayer_4)
- **Clase:** `CPlayer_4 : PlayerController`
- **Nota:** Actualmente comentado en el código, pero implementado

### 4.2 Variantes de Personajes
- **PlayerA, PlayerB, PlayerC:** Variantes alternativas de personajes
- **Player-Cat:** Personaje con temática felina

---

## 5. Arquitectura Técnica

### 5.1 Estructura de Clases

#### 5.1.1 Clases Base
```
PlayerController (MonoBehaviour)
├── CPlayer_1
├── CPlayer_2
├── CPlayer_3
└── CPlayer_4
```

#### 5.1.2 Sistema de Ataques
```
CAttack (ScriptableObject)
└── CComboAttack : CAttack
```

#### 5.1.3 Sistema de Proyectiles
```
CGenericBullet
├── CElectricAttack
├── CFireAttack
└── CLaserAttack
```

#### 5.1.4 Sistema de Formas
```
CForm_Agil (MonoBehaviour)
CForm_Speed (MonoBehaviour)
CForm_Strong (MonoBehaviour)
CForm_Distance (MonoBehaviour)
```

### 5.2 Managers (Singleton Pattern)

#### 5.2.1 CPlayerManager
- **Responsabilidad:** Gestión de jugadores activos
- **Funciones:**
  - Spawn de jugadores
  - Lista de jugadores activos
  - Cambio de personajes
  - Limpieza de jugadores destruidos

#### 5.2.2 CBulletManager
- **Responsabilidad:** Gestión de proyectiles
- **Funciones:**
  - Spawn de proyectiles
  - Lista de proyectiles activos
  - Garbage collection automático

#### 5.2.3 CGlobalValue
- **Responsabilidad:** Valores globales del juego
- **Funciones:**
  - Contador de jugadores
  - Asignación de controles
  - Lista global de jugadores

### 5.3 Interfaces

#### 5.3.1 IAttack
- **Propósito:** Interfaz para sistema de ataques
- **Implementación:** `PlayerController`

#### 5.3.2 IChange
- **Propósito:** Interfaz para sistema de transformaciones
- **Implementación:** `PlayerController`

### 5.4 Sistema de Input

#### 5.4.1 CInputSystemMultiplayer
- **Tipo:** Clase generada por Unity Input System
- **Input Actions:**
  - Player (Jugador 1)
  - Player1 (Jugador 2)
  - Player2 (Jugador 3)
  - Player3 (Jugador 4)
- **Control Schemes:**
  - PC Controller Schema
  - Xbox Controller - Player 2/3/4

---

## 6. Sistemas de Juego

### 6.1 Sistema de Spawn
- **CLevelState:** Maneja el spawn inicial de jugadores
- **Posición de Spawn:** Configurable por nivel
- **Spawn Secundario:** Tecla `Tab` para spawn adicional (debug)

### 6.2 Sistema de Combos

#### 6.2.1 ComboInput
- **Funcionalidad:**
  - Detección de secuencias de input
  - Validación de combos
  - Sistema de combos dinámicos
  - Carga de recursos de combos desde Resources

#### 6.2.2 Estructura de Combos
- **Lista de Ataques:** Secuencia de `CAttack` que forman el combo
- **Delay:** Tiempo entre ataques del combo
- **Chain Combos:** Posibilidad de encadenar combos
- **Combo Básico:** Combo predeterminado siempre disponible

### 6.3 Sistema de Detección de Golpes

#### 6.3.1 OverlapBox
- **Método:** `Physics.OverlapBox()`
- **Parámetros:**
  - Posición del controlador de golpe
  - Tamaño de la caja (`_Box`)
  - Rotación del controlador
- **Detección:** Colisiones con objetos con tag "Player"

### 6.4 Sistema de Animaciones

#### 6.4.1 Parámetros de Animator
- **Speed:** Control de velocidad de movimiento
- **IsJump:** Estado de salto
- **IsPunch:** Estado de golpe

#### 6.4.2 Control de Animaciones
- **ControllerAnimation():** Control básico de animaciones
- **ControllerAnimationTest():** Control de animaciones para testing
- **Transiciones:** Basadas en velocidad y estados de combate

---

## 7. Assets y Recursos

### 7.1 Prefabs de Personajes
- `Player-1.prefab`
- `Player-2.prefab`
- `Player-3.prefab`
- `Player-4.prefab`
- `PlayerA.prefab`, `PlayerB.prefab`, `PlayerC.prefab`
- `Player-Cat.prefab`

### 7.2 Prefabs de Ataques
- `Electric.prefab` - Ataque eléctrico
- `RootFire.prefab` - Ataque de fuego
- `RootLaser.prefab` - Ataque láser

### 7.3 Recursos (Resources)
- **Player-2/Attack:** ScriptableObjects de ataques
- **Player-2/Combo:** ScriptableObjects de combos

### 7.4 Animaciones
- Sistema completo de animaciones para personajes
- Animaciones de combate
- Animaciones de movimiento
- Animaciones de transformación

### 7.5 Materiales y Efectos
- Materiales básicos
- Materiales emisivos
- Efectos de partículas para ataques

---

## 8. Flujo de Juego

### 8.1 Inicio de Partida
1. Carga de escena
2. Inicialización de `CLevelState`
3. Spawn automático del primer jugador
4. Activación del sistema de input

### 8.2 Durante la Partida
1. Jugadores se mueven y atacan
2. Sistema de combos detecta secuencias
3. Proyectiles se instancian y gestionan
4. Sistema de daño procesa colisiones
5. Jugadores pueden cambiar de forma

### 8.3 Gestión de Jugadores
1. `CPlayerManager` mantiene lista de jugadores activos
2. Limpieza automática de jugadores destruidos
3. Sistema de asignación de controles

### 8.4 Sistema de Limpieza
- **Garbage Collection:** Limpieza automática de proyectiles destruidos
- **Lista de Jugadores:** Limpieza de referencias nulas
- **Lista de Proyectiles:** Limpieza de objetos destruidos

---

## 9. Configuración Técnica

### 9.1 Unity Input System
- **Input Actions Asset:** `CInputSystemMultiplayer.inputactions`
- **Control Schemes:** Múltiples esquemas para diferentes jugadores
- **Device Support:** Teclado, Mouse, Gamepads

### 9.2 Física
- **Rigidbody:** Sistema de física para movimiento
- **Colliders:** Sistema de colisiones para combate
- **Force Mode:** Impulse para saltos

### 9.3 Rendering
- **Universal Render Pipeline (URP):** Pipeline de renderizado
- **Lighting:** Sistema de iluminación configurado
- **Post-Processing:** Efectos visuales

---

## 10. Características Futuras (Roadmap)

### 10.1 Implementaciones Pendientes
- [ ] Sistema de vida/HP completo
- [ ] Sistema de rondas/partidas
- [ ] UI de combate (health bars, combo counter)
- [ ] Sistema de power-ups
- [ ] Más personajes jugables
- [ ] Modos de juego adicionales
- [ ] Sistema de logros
- [ ] Integración con Photon para multiplayer online

### 10.2 Mejoras Técnicas
- [ ] Optimización de rendimiento
- [ ] Sistema de pooling para proyectiles
- [ ] Mejora del sistema de combos
- [ ] Sistema de guardado/carga
- [ ] Configuración de controles personalizable

---

## 11. Plan de Refactorización e Integración con Photon

### 11.1 Objetivo del Plan

Unificar los sistemas de multiplayer local y online en un solo código base que soporte ambos modos de juego, eliminando duplicación de código y facilitando el mantenimiento futuro.

### 11.2 Estrategia: Sistema Híbrido Unificado

**Decisión Arquitectónica:** Refactorizar a un sistema unificado que soporte ambos modos (Local y Online) usando el patrón Strategy.

#### 11.2.1 Ventajas del Sistema Unificado
- ✅ **Un solo código base:** Mantenimiento simplificado
- ✅ **Features una vez:** Nuevas características funcionan en ambos modos
- ✅ **Modo híbrido:** Permite cambiar entre local y online en runtime
- ✅ **Escalable:** Fácil agregar nuevos modos de juego
- ✅ **Sin duplicación:** Elimina código duplicado entre sistemas

#### 11.2.2 Arquitectura Propuesta

```
Sistema Unificado
├── Core/
│   ├── IGameMode.cs (Interface)
│   ├── LocalGameMode.cs (Implementación Local)
│   └── NetworkGameMode.cs (Implementación Online)
├── Player/
│   ├── PlayerController.cs (Soporta ambos modos)
│   ├── CPlayer_1.cs
│   ├── CPlayer_2.cs
│   └── ...
├── Managers/
│   ├── CPlayerManager.cs (Soporta ambos modos)
│   └── CBulletManager.cs (Soporta ambos modos)
└── Network/ (Opcional, solo activo en modo online)
    ├── NetworkSync.cs
    └── NetworkEvents.cs
```

### 11.3 Implementación del Patrón Strategy

#### 11.3.1 Interface IGameMode

```csharp
public interface IGameMode
{
    // Spawn de jugadores
    GameObject SpawnPlayer(Vector3 position, GameObject prefab, int playerIndex);
    
    // Spawn de proyectiles
    GameObject SpawnProjectile(Vector3 position, GameObject prefab);
    
    // Verificación de modo
    bool IsNetworked { get; }
    
    // Verificación de autoridad (solo para online)
    bool HasAuthority(GameObject obj);
    
    // Inicialización
    void Initialize();
    
    // Limpieza
    void Cleanup();
}
```

#### 11.3.2 Implementación Local

```csharp
public class LocalGameMode : IGameMode
{
    public bool IsNetworked => false;
    
    public GameObject SpawnPlayer(Vector3 pos, GameObject prefab, int playerIndex)
    {
        return Instantiate(prefab, pos, Quaternion.identity);
    }
    
    public GameObject SpawnProjectile(Vector3 pos, GameObject prefab)
    {
        return Instantiate(prefab, pos, Quaternion.identity);
    }
    
    public bool HasAuthority(GameObject obj) => true; // Siempre true en local
    
    public void Initialize() { /* Setup local */ }
    public void Cleanup() { /* Cleanup local */ }
}
```

#### 11.3.3 Implementación Online

```csharp
public class NetworkGameMode : IGameMode
{
    public bool IsNetworked => true;
    
    public GameObject SpawnPlayer(Vector3 pos, GameObject prefab, int playerIndex)
    {
        return PhotonNetwork.Instantiate(prefab.name, pos, Quaternion.identity);
    }
    
    public GameObject SpawnProjectile(Vector3 pos, GameObject prefab)
    {
        return PhotonNetwork.Instantiate(prefab.name, pos, Quaternion.identity);
    }
    
    public bool HasAuthority(GameObject obj)
    {
        PhotonView pv = obj.GetComponent<PhotonView>();
        return pv != null && pv.IsMine;
    }
    
    public void Initialize() { /* Setup Photon */ }
    public void Cleanup() { /* Cleanup Photon */ }
}
```

### 11.4 Plan de Implementación por Fases

#### **Fase 1: Preparación (Semanas 1-2)**

**Objetivo:** Crear la infraestructura base sin romper funcionalidad existente.

**Tareas:**
1. ✅ Crear carpeta `Scripts/Core/`
2. ✅ Implementar `IGameMode.cs`
3. ✅ Implementar `LocalGameMode.cs`
4. ✅ Implementar `NetworkGameMode.cs`
5. ✅ Crear `GameModeManager.cs` (Singleton para gestionar modo actual)
6. ✅ Testing: Verificar que modo local sigue funcionando

**Criterios de Éxito:**
- Modo local funciona exactamente igual que antes
- No hay errores de compilación
- Tests de movimiento y combate pasan

---

#### **Fase 2: Integración en PlayerController (Semanas 3-4)**

**Objetivo:** Modificar PlayerController para usar IGameMode sin romper funcionalidad.

**Tareas:**
1. ✅ Modificar `PlayerController.cs`:
   - Agregar campo `protected IGameMode gameMode`
   - Detectar modo en `Awake()` o `Start()`
   - Agregar checks `if (!gameMode.HasAuthority(this)) return;`
   
2. ✅ Modificar métodos de movimiento:
   - Proteger input con verificación de autoridad
   - Mantener lógica existente

3. ✅ Modificar métodos de ataque:
   - Usar `gameMode.SpawnProjectile()` en lugar de `Instantiate()`
   - Agregar RPCs solo si `gameMode.IsNetworked`

4. ✅ Testing:
   - Modo local funciona correctamente
   - No hay regresiones

**Código de Ejemplo:**
```csharp
public class PlayerController : MonoBehaviour, IChange, IAttack
{
    protected IGameMode gameMode;
    
    protected virtual void Awake()
    {
        // Detectar modo de juego
        if (PhotonNetwork.IsConnected && PhotonNetwork.InRoom)
        {
            gameMode = new NetworkGameMode();
        }
        else
        {
            gameMode = new LocalGameMode();
        }
        
        gameMode.Initialize();
    }
    
    protected virtual void Move()
    {
        // Solo procesar si tenemos autoridad
        if (!gameMode.HasAuthority(gameObject))
            return;
            
        // ... código de movimiento existente
    }
}
```

---

#### **Fase 3: Integración de Photon (Semanas 5-6)**

**Objetivo:** Agregar soporte completo de Photon manteniendo compatibilidad local.

**Tareas:**
1. ✅ Modificar herencia de `PlayerController`:
   ```csharp
   // Cambiar de:
   public class PlayerController : MonoBehaviour
   
   // A:
   public class PlayerController : MonoBehaviourPunCallbacks, IPunObservable
   ```

2. ✅ Agregar `PhotonView` a prefabs de jugadores:
   - Configurar Ownership: Takeover
   - Agregar a lista de Observed Components

3. ✅ Implementar `IPunObservable`:
   ```csharp
   public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
   {
       if (!gameMode.IsNetworked) return;
       
       if (stream.IsWriting)
       {
           // Enviar datos
           stream.SendNext(transform.position);
           stream.SendNext(transform.rotation);
           stream.SendNext(_PlayerCount);
       }
       else
       {
           // Recibir datos
           transform.position = (Vector3)stream.ReceiveNext();
           transform.rotation = (Quaternion)stream.ReceiveNext();
           _PlayerCount = (int)stream.ReceiveNext();
       }
   }
   ```

4. ✅ Agregar RPCs para acciones:
   ```csharp
   [PunRPC]
   void PerformAttack(int attackType, Vector3 position, Quaternion rotation)
   {
       // Ejecutar ataque en todos los clientes
   }
   
   [PunRPC]
   void ChangeForm(int formType)
   {
       // Cambiar forma en todos los clientes
   }
   ```

5. ✅ Testing:
   - Modo local sigue funcionando
   - Modo online básico funciona
   - Sincronización de movimiento funciona

---

#### **Fase 4: Unificación de Managers (Semanas 7-8)**

**Objetivo:** Modificar Managers para usar IGameMode.

**Tareas:**
1. ✅ Modificar `CPlayerManager.cs`:
   ```csharp
   public class CPlayerManager : MonoBehaviour
   {
       private IGameMode gameMode;
       
       private void Awake()
       {
           // Detectar modo
           if (PhotonNetwork.IsConnected && PhotonNetwork.InRoom)
               gameMode = new NetworkGameMode();
           else
               gameMode = new LocalGameMode();
       }
       
       public void Spawn(Vector3 Pos)
       {
           GameObject obj = gameMode.SpawnPlayer(
               Pos, 
               _AssetManager[playerIndex], 
               playerIndex
           );
           // ... resto del código
       }
   }
   ```

2. ✅ Modificar `CBulletManager.cs`:
   ```csharp
   public class CBulletManager : MonoBehaviour
   {
       private IGameMode gameMode;
       
       public void SpawnAttack_1(Vector3 Pos, GameObject obj_A)
       {
           GameObject obj = gameMode.SpawnProjectile(Pos, obj_A);
           // ... resto del código
       }
   }
   ```

3. ✅ Mover prefabs a carpeta `Resources/`:
   - Necesario para `PhotonNetwork.Instantiate()`
   - O usar `PhotonNetwork.InstantiateRoomObject()`

4. ✅ Testing:
   - Spawn funciona en ambos modos
   - Proyectiles se sincronizan en online

---

#### **Fase 5: Sincronización Avanzada (Semanas 9-10)**

**Objetivo:** Sincronizar todas las mecánicas del juego.

**Tareas:**
1. ✅ Sincronizar sistema de combos:
   - RPCs para ejecutar combos
   - Sincronizar estado de combos

2. ✅ Sincronizar transformaciones:
   - RPC para cambios de forma
   - Sincronizar stats de formas

3. ✅ Sincronizar animaciones:
   - Parámetros de Animator en `OnPhotonSerializeView`
   - Estados de animación

4. ✅ Sincronizar sistema de daño:
   - RPCs para aplicar daño
   - Sincronizar salud/HP

5. ✅ Testing:
   - Todas las mecánicas funcionan en online
   - Sin desincronizaciones

---

#### **Fase 6: Optimización y Limpieza (Semanas 11-12)**

**Objetivo:** Optimizar rendimiento y limpiar código.

**Tareas:**
1. ✅ Optimizar sincronización:
   - Reducir frecuencia de sincronización
   - Comprimir datos enviados
   - Usar interpolación para movimiento

2. ✅ Limpiar código duplicado:
   - Eliminar código de sistemas antiguos no usados
   - Consolidar funciones similares

3. ✅ Mejorar manejo de errores:
   - Manejo de desconexiones
   - Reconexión automática
   - Estados de conexión

4. ✅ Documentación:
   - Comentar código nuevo
   - Actualizar GDD
   - Crear guía de uso

5. ✅ Testing final:
   - Testing exhaustivo en ambos modos
   - Testing de stress (múltiples jugadores)
   - Testing de edge cases

---

### 11.5 Estructura de Archivos Final

```
Assets/PartyGame/OriginalVersion/Completed-Game/
├── Scripts/
│   ├── Core/ (NUEVO)
│   │   ├── IGameMode.cs
│   │   ├── LocalGameMode.cs
│   │   ├── NetworkGameMode.cs
│   │   └── GameModeManager.cs
│   ├── Network/ (NUEVO - solo activo en online)
│   │   ├── NetworkSync.cs
│   │   ├── NetworkEvents.cs
│   │   └── NetworkRPCs.cs
│   ├── Attack/
│   │   └── ... (modificado para usar IGameMode)
│   ├── Player/
│   │   ├── PlayerController.cs (modificado)
│   │   └── ... (sin cambios)
│   ├── Manager/
│   │   ├── CPlayerManager.cs (modificado)
│   │   └── CBulletManager.cs (modificado)
│   └── Interface/
│       └── ... (sin cambios)
├── Resources/ (NUEVO)
│   └── PlayerPrefabs/
│       ├── Player-1.prefab
│       ├── Player-2.prefab
│       └── ...
├── Prefabs/
│   └── ... (prefabs de ataques, etc.)
└── Scenes/
    └── ... (sin cambios)
```

### 11.6 Checklist de Implementación

#### Fase 1: Preparación
- [ ] Crear carpeta `Scripts/Core/`
- [ ] Implementar `IGameMode.cs`
- [ ] Implementar `LocalGameMode.cs`
- [ ] Implementar `NetworkGameMode.cs`
- [ ] Crear `GameModeManager.cs`
- [ ] Testing modo local

#### Fase 2: PlayerController
- [ ] Modificar `PlayerController.cs` para usar IGameMode
- [ ] Agregar checks de autoridad en métodos de input
- [ ] Modificar spawn de proyectiles
- [ ] Testing modo local

#### Fase 3: Photon Integration
- [ ] Cambiar herencia a `MonoBehaviourPunCallbacks`
- [ ] Agregar `PhotonView` a prefabs
- [ ] Implementar `IPunObservable`
- [ ] Agregar RPCs básicos
- [ ] Testing modo online básico

#### Fase 4: Managers
- [ ] Modificar `CPlayerManager.cs`
- [ ] Modificar `CBulletManager.cs`
- [ ] Mover prefabs a Resources
- [ ] Testing spawn en ambos modos

#### Fase 5: Sincronización Avanzada
- [ ] Sincronizar combos
- [ ] Sincronizar transformaciones
- [ ] Sincronizar animaciones
- [ ] Sincronizar sistema de daño
- [ ] Testing completo

#### Fase 6: Optimización
- [ ] Optimizar sincronización
- [ ] Limpiar código duplicado
- [ ] Mejorar manejo de errores
- [ ] Documentación
- [ ] Testing final

### 11.7 Consideraciones Importantes

#### 11.7.1 Compatibilidad hacia atrás
- El modo local debe funcionar exactamente igual que antes
- No romper funcionalidad existente durante la refactorización
- Testing continuo en cada fase

#### 11.7.2 Performance
- Sincronizar solo datos necesarios
- Usar compresión para posiciones
- Limitar frecuencia de sincronización (ej: 20 veces por segundo)
- Usar interpolación para movimiento suave

#### 11.7.3 Manejo de Errores
- Detectar desconexiones
- Manejar reconexión automática
- Validar datos recibidos de red
- Fallback a modo local si falla conexión

#### 11.7.4 Testing
- Testing en modo local después de cada cambio
- Testing en modo online con múltiples clientes
- Testing de edge cases (desconexiones, lag, etc.)
- Testing de stress (múltiples jugadores simultáneos)

### 11.8 Riesgos y Mitigación

| Riesgo | Probabilidad | Impacto | Mitigación |
|--------|--------------|---------|------------|
| Romper funcionalidad local | Media | Alto | Testing exhaustivo en cada fase |
| Desincronización en online | Alta | Alto | Implementar validación y corrección |
| Performance degradado | Media | Medio | Optimización continua, profiling |
| Complejidad del código | Media | Medio | Documentación clara, código limpio |
| Tiempo de desarrollo | Alta | Medio | Plan por fases, priorizar features |

### 11.9 Métricas de Éxito

- ✅ Modo local funciona igual que antes (0 regresiones)
- ✅ Modo online funciona con latencia < 100ms
- ✅ Sincronización de movimiento suave (sin jitter)
- ✅ Todas las mecánicas funcionan en ambos modos
- ✅ Código unificado sin duplicación significativa
- ✅ Performance similar o mejor que antes

### 11.10 Próximos Pasos

1. **Revisar y aprobar plan:** Validar estrategia con el equipo
2. **Configurar entorno:** Preparar Photon account y configuración
3. **Iniciar Fase 1:** Comenzar con la creación de interfaces
4. **Seguimiento:** Revisión semanal de progreso

---

## 12. Referencias y Notas

### 12.1 Estructura de Archivos
```
Assets/PartyGame/OriginalVersion/Completed-Game/
├── Scripts/
│   ├── Attack/
│   ├── Player/
│   ├── Manager/
│   └── Interface/
├── Prefabs/
├── Materials/
├── Animation-Test/
├── InputAction/
└── Scenes/
```

### 12.2 Dependencias
- Unity Input System
- Unity Universal Render Pipeline
- TextMesh Pro (opcional)

### 12.3 Convenciones de Código
- Prefijos de clase: `C` (ej: `CPlayer`, `CAttack`)
- Nombres de variables privadas: `_variableName`
- Managers como Singleton Pattern
- ScriptableObjects para datos de ataques y combos

---

## 13. Contacto y Soporte

Para preguntas sobre el diseño o implementación del juego, consultar:
- Código fuente en `Assets/PartyGame/OriginalVersion/Completed-Game/`
- Documentación técnica en comentarios del código
- Scripts de ejemplo en `Assets/PartyGame/OriginalVersion/Completed-Game/Scripts/`

---

**Documento creado:** 2024  
**Última actualización:** 2024  
**Versión del Documento:** 2.0

### Cambios en Versión 2.0
- ✅ Agregada sección completa de Plan de Refactorización e Integración con Photon
- ✅ Documentada estrategia de sistema híbrido unificado
- ✅ Plan de implementación por fases (12 semanas)
- ✅ Checklist completo de implementación
- ✅ Consideraciones de riesgo y mitigación
- ✅ Métricas de éxito definidas

