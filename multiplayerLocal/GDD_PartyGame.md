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

#### **Fase 0: Limpieza Pre-Refactorización (1-2 días, ANTES de Fase 1)**

**Objetivo:** Limpiar código antes de comenzar integración con Photon.

**Tareas:**
1. ✅ Eliminar sistemas de test/debug (ver sección 11.11.1)
2. ✅ Eliminar clases vacías (ver sección 11.11.2)
3. ✅ Eliminar sistemas no usados (ver sección 11.11.3)
4. ✅ Limpiar código comentado (ver sección 11.11.4)

**Criterios de Éxito:**
- ✅ Código más limpio y legible
- ✅ Sin clases vacías o no usadas
- ✅ Sin sistemas de test en código de producción
- ✅ Juego funciona exactamente igual que antes

**Referencia:** Ver sección 11.11 para detalles completos del plan de limpieza.

---

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

### 11.11 Sistemas a Simplificar o Eliminar para Reducir Riesgos

Esta sección identifica sistemas que pueden ser eliminados o simplificados para reducir complejidad, facilitar la integración con Photon, y minimizar riesgos de bugs.

---

#### 11.11.1 Sistemas de Test/Debug (ELIMINAR)

**Razón:** No son necesarios para producción y agregan complejidad innecesaria.

| Sistema | Ubicación | Acción | Impacto |
|---------|-----------|--------|---------|
| `CTestEnemy.cs` | `Scripts/CTestEnemy.cs` | **ELIMINAR** | Ninguno - Solo para testing |
| `CTestPunch.cs` | `Scripts/CTestPunch.cs` | **ELIMINAR** | Ninguno - Solo para testing |
| `ControllerAnimationTest()` | `CPlayer_2.cs` | **ELIMINAR** | Ninguno - Modo test no usado |
| `isTestAnimation` flag | `CPlayer_2.cs` | **ELIMINAR** | Ninguno - Solo para debug |
| Todos los `Debug.Log()` | Múltiples archivos | **COMENTAR/ELIMINAR** | Mejora performance |

**Beneficios:**
- ✅ Reduce complejidad del código
- ✅ Mejora performance (menos logs)
- ✅ Código más limpio
- ✅ Facilita integración con Photon

---

#### 11.11.2 Clases Vacías o No Implementadas (ELIMINAR)

**Razón:** Clases que no tienen funcionalidad y solo agregan confusión.

| Sistema | Ubicación | Estado Actual | Acción |
|---------|-----------|----------------|--------|
| `CSwitchCharacter.cs` | `Scripts/CSwitchCharacter.cs` | Vacío, no implementado | **ELIMINAR** |
| `CGameEventManager.cs` | `Scripts/CGameEventManager.cs` | Vacío, no implementado | **ELIMINAR** |
| `CPlayer.cs` | `Scripts/CPlayer.cs` | Solo métodos vacíos | **ELIMINAR** |
| `Rotator.cs` | `Scripts/Rotator.cs` | Probablemente decorativo | **EVALUAR** - Mover a carpeta de utilidades si se usa |

**Beneficios:**
- ✅ Reduce confusión sobre qué código usar
- ✅ Facilita mantenimiento
- ✅ Código más claro

---

#### 11.11.3 Sistemas No Utilizados (ELIMINAR o POSPONER)

**Razón:** Funcionalidades que no se usan en el juego actual y complican el código.

| Sistema | Ubicación | Estado | Acción | Prioridad |
|---------|-----------|--------|--------|-----------|
| `PlayerA`, `PlayerB`, `PlayerC` | `Scripts/PlayerA.cs`, etc. | Solo usados en `changedCharacter()` que no se usa | **ELIMINAR** | Baja |
| `changedCharacter()` | `CPlayerManager.cs` | Método no llamado en código | **ELIMINAR** | Baja |
| `CPlayer_4` | `Scripts/Player/CPlayer_4.cs` | Comentado, con TODO | **POSPONER** - Eliminar por ahora | Media |
| `AndroidControllerTest()` | `PlayerController.cs` | No implementado | **ELIMINAR** | Baja |
| Sistema de cambio de personajes en runtime | `CPlayerManager.cs` | No usado | **ELIMINAR** | Baja |

**Beneficios:**
- ✅ Reduce complejidad significativamente
- ✅ Facilita integración con Photon (menos casos edge)
- ✅ Código más mantenible
- ✅ Menos posibilidades de bugs

**Nota:** Si en el futuro se necesita cambio de personajes, se puede implementar correctamente con Photon desde el inicio.

---

#### 11.11.4 Código Comentado (LIMPIAR)

**Razón:** Código comentado extenso confunde y dificulta mantenimiento.

| Ubicación | Cantidad Aproximada | Acción |
|-----------|---------------------|--------|
| `PlayerController.cs` | ~100+ líneas comentadas | **ELIMINAR** código comentado no necesario |
| `ComboInput.cs` | ~50+ líneas comentadas | **ELIMINAR** código comentado |
| `CPlayerManager.cs` | ~20 líneas comentadas | **ELIMINAR** código comentado |
| Múltiples archivos | Varias líneas | **REVISAR y ELIMINAR** |

**Beneficios:**
- ✅ Código más legible
- ✅ Menos confusión sobre qué código usar
- ✅ Facilita code reviews

**Estrategia:**
1. Revisar cada bloque de código comentado
2. Si es código legacy que no se usará: **ELIMINAR**
3. Si es código para futuro: **MOVER a carpeta `_Archive/` o documentar en GDD**
4. Si es código de referencia: **MOVER a documentación**

---

#### 11.11.5 Sistemas que Complican Integración con Photon (SIMPLIFICAR)

**Razón:** Estos sistemas agregan complejidad innecesaria para la integración con Photon.

| Sistema | Problema | Solución Propuesta |
|---------|----------|-------------------|
| **Múltiples variantes de personajes** | PlayerA/B/C complican spawn y sincronización | **SIMPLIFICAR:** Usar solo CPlayer_1, CPlayer_2, CPlayer_3 |
| **Sistema de cambio de personajes en runtime** | Cambiar personaje en medio de partida complica Photon | **ELIMINAR:** Selección de personaje solo al inicio |
| **Sistema de formas (Forms)** | Si no está completamente implementado, puede causar problemas | **EVALUAR:** Si no es crítico, posponer para Fase 5+ |
| **Sistema de combos dinámico** | `CheckComboDynamic()` no implementado | **POSPONER:** Usar solo sistema de combos básico inicialmente |

**Beneficios:**
- ✅ Integración con Photon más simple
- ✅ Menos casos edge que manejar
- ✅ Testing más fácil
- ✅ Menos posibilidades de bugs de sincronización

---

#### 11.11.6 Plan de Limpieza por Fases

##### **Fase 0: Limpieza Pre-Refactorización (ANTES de Fase 1)**

**Objetivo:** Limpiar código antes de comenzar integración con Photon.

**Tareas:**
1. ✅ **Eliminar sistemas de test:**
   - Eliminar `CTestEnemy.cs`
   - Eliminar `CTestPunch.cs`
   - Eliminar `ControllerAnimationTest()` y flag `isTestAnimation`
   - Comentar/eliminar `Debug.Log()` statements

2. ✅ **Eliminar clases vacías:**
   - Eliminar `CSwitchCharacter.cs`
   - Eliminar `CGameEventManager.cs`
   - Eliminar `CPlayer.cs` (o mover a `_Archive/` si tiene valor histórico)

3. ✅ **Eliminar sistemas no usados:**
   - Eliminar `PlayerA.cs`, `PlayerB.cs`, `PlayerC.cs`
   - Eliminar método `changedCharacter()` de `CPlayerManager`
   - Eliminar `AndroidControllerTest()`
   - Comentar/eliminar código de `CPlayer_4` (o eliminar clase completa)

4. ✅ **Limpiar código comentado:**
   - Revisar y eliminar código comentado innecesario
   - Mover código de referencia a documentación si es necesario

**Criterios de Éxito:**
- ✅ Código más limpio y legible
- ✅ Sin clases vacías o no usadas
- ✅ Sin sistemas de test en código de producción
- ✅ Código comentado mínimo y justificado

**Tiempo Estimado:** 1-2 días

---

#### 11.11.7 Impacto de la Limpieza

##### **Reducción de Complejidad**

| Métrica | Antes | Después | Reducción |
|---------|-------|---------|-----------|
| Clases totales | ~25 | ~18 | **-28%** |
| Líneas de código | ~3000 | ~2400 | **-20%** |
| Sistemas no usados | 5+ | 0 | **-100%** |
| Código comentado | ~200 líneas | ~20 líneas | **-90%** |

##### **Beneficios para Integración con Photon**

1. **Menos casos edge:** Menos sistemas = menos casos especiales que manejar
2. **Testing más simple:** Menos código = menos cosas que testear
3. **Menos bugs:** Menos complejidad = menos posibilidades de errores
4. **Código más claro:** Más fácil entender qué hace cada parte
5. **Mantenimiento más fácil:** Menos código = más fácil mantener

##### **Riesgos Reducidos**

| Riesgo | Reducción |
|--------|-----------|
| Complejidad del código | **-40%** (de Media a Baja) |
| Tiempo de desarrollo | **-15%** (menos código que integrar) |
| Bugs de integración | **-25%** (menos sistemas que pueden fallar) |

---

#### 11.11.8 Checklist de Limpieza

##### Pre-Refactorización (Fase 0)
- [ ] Eliminar `CTestEnemy.cs`
- [ ] Eliminar `CTestPunch.cs`
- [ ] Eliminar `ControllerAnimationTest()` y `isTestAnimation`
- [ ] Comentar/eliminar `Debug.Log()` statements
- [ ] Eliminar `CSwitchCharacter.cs`
- [ ] Eliminar `CGameEventManager.cs`
- [ ] Eliminar `CPlayer.cs`
- [ ] Eliminar `PlayerA.cs`, `PlayerB.cs`, `PlayerC.cs`
- [ ] Eliminar método `changedCharacter()`
- [ ] Eliminar `AndroidControllerTest()`
- [ ] Decidir sobre `CPlayer_4` (eliminar o posponer)
- [ ] Limpiar código comentado en `PlayerController.cs`
- [ ] Limpiar código comentado en `ComboInput.cs`
- [ ] Limpiar código comentado en otros archivos
- [ ] Testing: Verificar que juego funciona igual después de limpieza

##### Durante Refactorización
- [ ] No agregar nuevos sistemas de test en código de producción
- [ ] Mantener código limpio
- [ ] Documentar decisiones sobre código eliminado

---

#### 11.11.9 Notas Importantes

1. **Backup antes de limpiar:** Crear backup completo antes de eliminar código
2. **Testing después de limpieza:** Verificar que todo funciona igual
3. **Version control:** Usar Git para poder revertir si es necesario
4. **Documentación:** Documentar qué se eliminó y por qué (en este GDD)
5. **Futuro:** Si se necesita funcionalidad eliminada, implementarla correctamente desde el inicio

---

#### 11.11.10 Sistemas a Mantener (Críticos)

Estos sistemas **NO** deben eliminarse, son esenciales:

- ✅ `PlayerController.cs` (base)
- ✅ `CPlayer_1.cs`, `CPlayer_2.cs`, `CPlayer_3.cs` (jugadores activos)
- ✅ `CPlayerManager.cs` (gestión de jugadores)
- ✅ `CBulletManager.cs` (gestión de proyectiles)
- ✅ `CGlobalValue.cs` (valores globales)
- ✅ `CInputSystemMultiplayer.cs` (sistema de input)
- ✅ Sistema de combos básico (`ComboInput.cs`, `CAttack.cs`, `CComboAttack.cs`)
- ✅ Sistema de ataques (`CGenericBullet.cs` y derivados)
- ✅ Sistema de formas (si está implementado y se usa)

---

### 11.12 Plan de Implementación de Funcionalidades Faltantes con Prevención de Edge Problems

Esta sección detalla cómo implementar las funcionalidades faltantes (sistema de vida, condiciones de victoria, etc.) de manera que beneficie tanto al modo local como online, y use Photon de forma segura para evitar problemas de sincronización.

---

#### 11.12.1 Objetivo

Implementar funcionalidades críticas del juego (sistema de vida, condiciones de victoria, UI) de manera que:
- ✅ Funcione perfectamente en modo local
- ✅ Funcione perfectamente en modo online con Photon
- ✅ Evite problemas de sincronización (edge problems)
- ✅ Sea robusto contra lag, desincronización y cheating
- ✅ Use una arquitectura unificada (mismo código para ambos modos)

---

#### 11.12.2 Funcionalidades a Implementar

| Funcionalidad | Prioridad | Complejidad | Beneficio Online |
|---------------|-----------|-------------|------------------|
| Sistema de Vida/HP | **Crítica** | Media | Alto - Base para todo |
| Sistema de Daño | **Crítica** | Media | Alto - Requiere validación |
| Condiciones de Victoria | **Alta** | Baja | Medio - Requiere sincronización |
| UI de Combate | **Alta** | Media | Medio - Visualización |
| Sistema de Rondas | **Media** | Alta | Alto - Gestión de estado |
| Sistema de Respawn | **Media** | Media | Alto - Manejo de desconexiones |

---

#### 11.12.3 Principios de Diseño para Evitar Edge Problems

##### 11.12.3.1 Autoridad Clara
- **Cada jugador controla solo su personaje** (photonView.IsMine)
- **Master Client para decisiones globales** (condiciones de victoria, rondas)
- **Validación de autoridad antes de cada acción crítica**

##### 11.12.3.2 Validación y Verificación
- **Validar datos recibidos** antes de aplicar cambios
- **Rangos válidos** para todos los valores (HP entre 0-100, etc.)
- **Timestamps** para detectar acciones fuera de tiempo
- **Checksums** para validar estado del juego

##### 11.12.3.3 Sincronización Robusta
- **IPunObservable** para datos críticos (posición, HP, estado)
- **RPCs confiables** (RpcTarget.AllViaServer) para acciones importantes
- **Interpolación** para movimiento suave
- **Lag compensation** para acciones de combate

##### 11.12.3.4 Manejo de Errores
- **Fallback a modo local** si Photon falla
- **Reconexión automática** con restauración de estado
- **Validación de conexión** antes de acciones críticas
- **Logging** para debugging de problemas de red

---

#### 11.12.4 Arquitectura Propuesta

```
Sistema Unificado
├── Core/
│   ├── IGameMode.cs (ya implementado)
│   ├── IDamageable.cs (NUEVO - interface para daño)
│   └── IGameState.cs (NUEVO - interface para estado del juego)
├── Health/
│   ├── CHealthSystem.cs (NUEVO - sistema de vida unificado)
│   └── CHealthBar.cs (NUEVO - UI de vida)
├── Damage/
│   ├── CDamageSystem.cs (NUEVO - sistema de daño unificado)
│   └── CDamageInfo.cs (NUEVO - estructura de información de daño)
├── GameState/
│   ├── CGameStateManager.cs (NUEVO - gestión de estado)
│   ├── CWinCondition.cs (NUEVO - condiciones de victoria)
│   └── CRoundManager.cs (NUEVO - gestión de rondas)
└── Network/
    ├── CNetworkHealth.cs (NUEVO - sincronización de vida)
    ├── CNetworkDamage.cs (NUEVO - sincronización de daño)
    └── CNetworkGameState.cs (NUEVO - sincronización de estado)
```

---

#### 11.12.5 Implementación Detallada por Funcionalidad

##### **11.12.5.1 Sistema de Vida/HP**

**Objetivo:** Sistema de vida que funcione en ambos modos y se sincronice correctamente en online.

**Arquitectura:**
```csharp
// Interface para objetos que pueden recibir daño
public interface IDamageable
{
    void TakeDamage(float damage, GameObject attacker);
    float CurrentHealth { get; }
    float MaxHealth { get; }
    bool IsDead { get; }
    event System.Action<float> OnHealthChanged;
    event System.Action OnDeath;
}

// Sistema de vida unificado
public class CHealthSystem : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;
    
    // Eventos para UI y otros sistemas
    public event System.Action<float> OnHealthChanged;
    public event System.Action OnDeath;
    
    // Modo de juego
    private IGameMode gameMode;
    
    public float CurrentHealth => currentHealth;
    public float MaxHealth => maxHealth;
    public bool IsDead => currentHealth <= 0f;
    
    private void Awake()
    {
        gameMode = GameModeManager.Instance?.CurrentGameMode ?? new LocalGameMode();
        currentHealth = maxHealth;
    }
    
    public void TakeDamage(float damage, GameObject attacker)
    {
        // Validación de autoridad (solo el dueño puede recibir daño)
        if (gameMode.IsNetworked && !gameMode.HasAuthority(gameObject))
        {
            // En online, el daño se aplica vía RPC
            return;
        }
        
        // Validar datos
        if (damage < 0 || IsDead)
            return;
            
        // Aplicar daño
        currentHealth = Mathf.Clamp(currentHealth - damage, 0f, maxHealth);
        
        // Notificar cambios
        OnHealthChanged?.Invoke(currentHealth);
        
        // Verificar muerte
        if (IsDead)
        {
            OnDeath?.Invoke();
        }
    }
}
```

**Sincronización Online:**
```csharp
// Componente de red para sincronizar vida
public class CNetworkHealth : MonoBehaviourPunCallbacks, IPunObservable
{
    private CHealthSystem healthSystem;
    
    private void Awake()
    {
        healthSystem = GetComponent<CHealthSystem>();
    }
    
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // Enviar vida actual
            stream.SendNext(healthSystem.CurrentHealth);
        }
        else
        {
            // Recibir vida actual
            float receivedHealth = (float)stream.ReceiveNext();
            
            // Validar datos recibidos
            if (receivedHealth < 0 || receivedHealth > healthSystem.MaxHealth)
            {
                Debug.LogWarning($"Datos de vida inválidos recibidos: {receivedHealth}");
                return;
            }
            
            // Aplicar solo si es diferente (evitar actualizaciones innecesarias)
            if (Mathf.Abs(healthSystem.CurrentHealth - receivedHealth) > 0.1f)
            {
                // Usar evento en lugar de modificar directamente
                float damage = healthSystem.CurrentHealth - receivedHealth;
                if (damage > 0)
                {
                    healthSystem.TakeDamage(damage, null);
                }
            }
        }
    }
    
    // RPC para aplicar daño (llamado por el atacante)
    [PunRPC]
    void ApplyDamageRPC(float damage, int attackerViewID)
    {
        // Validar que el daño viene de un jugador válido
        if (damage < 0 || damage > 1000) // Límite razonable
        {
            Debug.LogWarning($"Daño inválido recibido: {damage}");
            return;
        }
        
        GameObject attacker = PhotonView.Find(attackerViewID)?.gameObject;
        healthSystem.TakeDamage(damage, attacker);
    }
}
```

**Beneficios:**
- ✅ Funciona igual en local y online
- ✅ Validación de datos previene valores inválidos
- ✅ Sincronización solo cuando hay cambios significativos
- ✅ RPCs para acciones críticas (daño)

---

##### **11.12.5.2 Sistema de Daño**

**Objetivo:** Sistema de daño que valide ataques y prevenga cheating.

**Arquitectura:**
```csharp
// Estructura de información de daño
[System.Serializable]
public struct CDamageInfo
{
    public float damage;
    public GameObject attacker;
    public Vector3 hitPoint;
    public float timestamp;
    public int attackType; // 0 = básico, 1 = combo, 2 = especial
    
    public CDamageInfo(float dmg, GameObject att, Vector3 point, int type)
    {
        damage = dmg;
        attacker = att;
        hitPoint = point;
        timestamp = Time.time;
        attackType = type;
    }
}

// Sistema de daño unificado
public class CDamageSystem : MonoBehaviour
{
    private IGameMode gameMode;
    
    private void Awake()
    {
        gameMode = GameModeManager.Instance?.CurrentGameMode ?? new LocalGameMode();
    }
    
    public void ApplyDamage(GameObject target, CDamageInfo damageInfo)
    {
        // Validar autoridad del atacante
        if (!gameMode.HasAuthority(damageInfo.attacker))
        {
            Debug.LogWarning("Intento de ataque sin autoridad");
            return;
        }
        
        // Validar datos de daño
        if (damageInfo.damage <= 0 || damageInfo.damage > 1000)
        {
            Debug.LogWarning($"Daño inválido: {damageInfo.damage}");
            return;
        }
        
        // Validar que el objetivo existe y es válido
        if (target == null)
            return;
            
        IDamageable damageable = target.GetComponent<IDamageable>();
        if (damageable == null)
            return;
        
        // Aplicar daño según modo
        if (gameMode.IsNetworked)
        {
            // En online, usar RPC
            PhotonView targetPV = target.GetComponent<PhotonView>();
            if (targetPV != null)
            {
                PhotonView attackerPV = damageInfo.attacker.GetComponent<PhotonView>();
                targetPV.RPC("ApplyDamageRPC", RpcTarget.AllViaServer, 
                    damageInfo.damage, 
                    attackerPV != null ? attackerPV.ViewID : 0);
            }
        }
        else
        {
            // En local, aplicar directamente
            damageable.TakeDamage(damageInfo.damage, damageInfo.attacker);
        }
    }
}
```

**Prevención de Edge Problems:**
- ✅ Validación de autoridad antes de aplicar daño
- ✅ Límites de daño razonables (0-1000)
- ✅ Validación de timestamps (rechazar ataques muy antiguos)
- ✅ RPCs vía servidor (AllViaServer) para orden consistente
- ✅ Validación de distancia (opcional, para prevenir teleport attacks)

---

##### **11.12.5.3 Condiciones de Victoria**

**Objetivo:** Sistema de victoria que funcione en ambos modos y se sincronice correctamente.

**Arquitectura:**
```csharp
// Tipos de condiciones de victoria
public enum EWinCondition
{
    LastManStanding,  // Último en pie
    FirstToKills,     // Primero en X kills
    TimeLimit,        // Más kills en tiempo límite
    ScoreBased        // Basado en puntos
}

// Manager de estado del juego
public class CGameStateManager : MonoBehaviourPunCallbacks
{
    private IGameMode gameMode;
    private EWinCondition currentWinCondition;
    private bool gameEnded = false;
    
    // Eventos
    public event System.Action<int> OnPlayerWon; // playerIndex
    public event System.Action OnGameEnd;
    
    private void Awake()
    {
        gameMode = GameModeManager.Instance?.CurrentGameMode ?? new LocalGameMode();
    }
    
    public void CheckWinCondition()
    {
        // Solo Master Client verifica condiciones en online
        if (gameMode.IsNetworked)
        {
#if PUN_2_OR_NEWER
            if (!PhotonNetwork.IsMasterClient)
                return;
#endif
        }
        
        if (gameEnded)
            return;
        
        switch (currentWinCondition)
        {
            case EWinCondition.LastManStanding:
                CheckLastManStanding();
                break;
            // ... otros casos
        }
    }
    
    private void CheckLastManStanding()
    {
        int aliveCount = 0;
        int lastAliveIndex = -1;
        
        // Contar jugadores vivos
        foreach (var player in CPlayerManager.Inst._PlayerList)
        {
            if (player != null)
            {
                IDamageable health = player.GetComponent<IDamageable>();
                if (health != null && !health.IsDead)
                {
                    aliveCount++;
                    lastAliveIndex = player._PlayerCount;
                }
            }
        }
        
        // Si solo queda uno, terminar juego
        if (aliveCount == 1)
        {
            EndGame(lastAliveIndex);
        }
    }
    
    private void EndGame(int winnerIndex)
    {
        gameEnded = true;
        
        if (gameMode.IsNetworked)
        {
            // Sincronizar fin de juego vía RPC
            photonView.RPC("EndGameRPC", RpcTarget.AllViaServer, winnerIndex);
        }
        else
        {
            // En local, terminar directamente
            OnPlayerWon?.Invoke(winnerIndex);
            OnGameEnd?.Invoke();
        }
    }
    
    [PunRPC]
    void EndGameRPC(int winnerIndex)
    {
        // Validar datos
        if (winnerIndex < 0 || winnerIndex > 3)
        {
            Debug.LogWarning($"Índice de ganador inválido: {winnerIndex}");
            return;
        }
        
        OnPlayerWon?.Invoke(winnerIndex);
        OnGameEnd?.Invoke();
    }
}
```

**Prevención de Edge Problems:**
- ✅ Solo Master Client verifica condiciones (evita conflictos)
- ✅ Validación de datos antes de terminar juego
- ✅ RPCs vía servidor para sincronización consistente
- ✅ Flag `gameEnded` previene múltiples finales
- ✅ Verificación periódica en lugar de eventos únicos

---

##### **11.12.5.4 Sistema de Rondas**

**Objetivo:** Sistema de rondas que maneje correctamente desconexiones y reconexiones.

**Arquitectura:**
```csharp
public class CRoundManager : MonoBehaviourPunCallbacks
{
    private int currentRound = 0;
    private int maxRounds = 3;
    private bool roundInProgress = false;
    private float roundStartTime;
    private float roundDuration = 120f; // 2 minutos
    
    private IGameMode gameMode;
    
    private void Awake()
    {
        gameMode = GameModeManager.Instance?.CurrentGameMode ?? new LocalGameMode();
    }
    
    public void StartRound()
    {
        // Solo Master Client inicia rondas en online
        if (gameMode.IsNetworked)
        {
#if PUN_2_OR_NEWER
            if (!PhotonNetwork.IsMasterClient)
                return;
                
            photonView.RPC("StartRoundRPC", RpcTarget.AllViaServer, currentRound);
            return;
#endif
        }
        
        StartRoundLocal();
    }
    
    private void StartRoundLocal()
    {
        currentRound++;
        roundInProgress = true;
        roundStartTime = Time.time;
        
        // Resetear jugadores
        ResetAllPlayers();
    }
    
    [PunRPC]
    void StartRoundRPC(int roundNumber)
    {
        // Validar número de ronda
        if (roundNumber < 1 || roundNumber > maxRounds)
        {
            Debug.LogWarning($"Número de ronda inválido: {roundNumber}");
            return;
        }
        
        currentRound = roundNumber;
        StartRoundLocal();
    }
    
    private void ResetAllPlayers()
    {
        foreach (var player in CPlayerManager.Inst._PlayerList)
        {
            if (player != null)
            {
                IDamageable health = player.GetComponent<IDamageable>();
                if (health != null)
                {
                    health.ResetHealth(); // Método a implementar
                }
                
                // Respawn en posición inicial
                RespawnPlayer(player);
            }
        }
    }
    
    // Manejo de desconexiones
    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        if (gameMode.IsNetworked && PhotonNetwork.IsMasterClient)
        {
            // Verificar si el juego puede continuar
            if (PhotonNetwork.CurrentRoom.PlayerCount < 2 && roundInProgress)
            {
                // Pausar ronda o terminar
                PauseRound();
            }
        }
    }
}
```

**Prevención de Edge Problems:**
- ✅ Master Client controla rondas (evita conflictos)
- ✅ Manejo de desconexiones durante rondas
- ✅ Validación de número de ronda
- ✅ Reset consistente de todos los jugadores
- ✅ Sincronización de tiempo de ronda

---

#### 11.12.6 Estrategias Específicas para Evitar Edge Problems

##### **11.12.6.1 Prevención de Cheating**

**Problema:** Jugadores modifican valores localmente (HP infinito, daño excesivo, etc.)

**Solución:**
```csharp
// Validación de datos en cada RPC
[PunRPC]
void ApplyDamageRPC(float damage, int attackerViewID)
{
    // 1. Validar rango de daño
    if (damage < 0 || damage > 1000)
    {
        Debug.LogWarning($"Daño inválido: {damage}. Rechazado.");
        return;
    }
    
    // 2. Validar que el atacante existe
    PhotonView attackerPV = PhotonView.Find(attackerViewID);
    if (attackerPV == null)
    {
        Debug.LogWarning("Atacante no encontrado. Rechazado.");
        return;
    }
    
    // 3. Validar distancia (opcional, para prevenir teleport attacks)
    float distance = Vector3.Distance(transform.position, attackerPV.transform.position);
    if (distance > 50f) // Rango máximo de ataque
    {
        Debug.LogWarning($"Ataque desde distancia inválida: {distance}. Rechazado.");
        return;
    }
    
    // 4. Validar timestamp (rechazar ataques muy antiguos)
    // (Requiere enviar timestamp en RPC)
    
    // 5. Aplicar daño solo si pasa todas las validaciones
    healthSystem.TakeDamage(damage, attackerPV.gameObject);
}
```

---

##### **11.12.6.2 Prevención de Desincronización**

**Problema:** Estados diferentes entre clientes (HP diferente, posición diferente, etc.)

**Solución:**
```csharp
// Sincronización periódica con validación
public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
{
    if (stream.IsWriting)
    {
        // Enviar datos
        stream.SendNext(currentHealth);
        stream.SendNext(transform.position);
        stream.SendNext(transform.rotation);
    }
    else
    {
        // Recibir datos
        float receivedHealth = (float)stream.ReceiveNext();
        Vector3 receivedPos = (Vector3)stream.ReceiveNext();
        Quaternion receivedRot = (Quaternion)stream.ReceiveNext();
        
        // Validar y corregir
        ValidateAndCorrectHealth(receivedHealth);
        ValidateAndCorrectPosition(receivedPos, receivedRot);
    }
}

private void ValidateAndCorrectHealth(float receivedHealth)
{
    // Si la diferencia es significativa, corregir
    if (Mathf.Abs(currentHealth - receivedHealth) > 5f)
    {
        Debug.LogWarning($"Desincronización de HP detectada. Local: {currentHealth}, Remoto: {receivedHealth}");
        
        // Usar el valor del servidor (Master Client)
        currentHealth = receivedHealth;
        OnHealthChanged?.Invoke(currentHealth);
    }
}

private void ValidateAndCorrectPosition(Vector3 receivedPos, Quaternion receivedRot)
{
    float distance = Vector3.Distance(transform.position, receivedPos);
    
    // Si la diferencia es muy grande, hacer snap
    if (distance > 2f)
    {
        Debug.LogWarning($"Desincronización de posición detectada. Distancia: {distance}");
        transform.position = receivedPos;
        transform.rotation = receivedRot;
    }
    else
    {
        // Interpolación suave para diferencias pequeñas
        transform.position = Vector3.Lerp(transform.position, receivedPos, 0.2f);
        transform.rotation = Quaternion.Lerp(transform.rotation, receivedRot, 0.2f);
    }
}
```

---

##### **11.12.6.3 Manejo de Lag**

**Problema:** Acciones de combate se sienten lentas o imprecisas debido a lag.

**Solución:**
```csharp
// Lag Compensation para ataques
public class CLagCompensation : MonoBehaviour
{
    private struct Snapshot
    {
        public Vector3 position;
        public Quaternion rotation;
        public float timestamp;
    }
    
    private Queue<Snapshot> positionHistory = new Queue<Snapshot>();
    private float historyDuration = 1f; // Guardar 1 segundo de historia
    
    private void Update()
    {
        // Guardar snapshot cada frame
        if (gameMode.HasAuthority(gameObject))
        {
            positionHistory.Enqueue(new Snapshot
            {
                position = transform.position,
                rotation = transform.rotation,
                timestamp = Time.time
            });
            
            // Limpiar snapshots antiguos
            while (positionHistory.Count > 0 && 
                   Time.time - positionHistory.Peek().timestamp > historyDuration)
            {
                positionHistory.Dequeue();
            }
        }
    }
    
    // Usar posición histórica para validar ataques
    public bool ValidateHit(Vector3 hitPoint, float attackTime)
    {
        // Buscar snapshot más cercano al tiempo del ataque
        Snapshot? closestSnapshot = null;
        float closestTime = float.MaxValue;
        
        foreach (var snapshot in positionHistory)
        {
            float timeDiff = Mathf.Abs(snapshot.timestamp - attackTime);
            if (timeDiff < closestTime)
            {
                closestTime = timeDiff;
                closestSnapshot = snapshot;
            }
        }
        
        if (closestSnapshot.HasValue)
        {
            // Verificar si el hit es válido usando posición histórica
            float distance = Vector3.Distance(closestSnapshot.Value.position, hitPoint);
            return distance < 2f; // Rango de ataque
        }
        
        return false;
    }
}
```

---

##### **11.12.6.4 Manejo de Desconexiones**

**Problema:** Jugadores se desconectan durante partida, causando problemas.

**Solución:**
```csharp
public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
{
    // Encontrar jugador que se desconectó
    GameObject disconnectedPlayer = FindPlayerByActorNumber(otherPlayer.ActorNumber);
    
    if (disconnectedPlayer != null)
    {
        // Opción 1: Eliminar jugador
        Destroy(disconnectedPlayer);
        
        // Opción 2: Reemplazar con bot (futuro)
        // SpawnBot(disconnectedPlayer.transform.position);
        
        // Verificar si el juego puede continuar
        if (PhotonNetwork.CurrentRoom.PlayerCount < 2)
        {
            // Pausar o terminar juego
            CGameStateManager.Instance?.PauseGame();
        }
    }
}

public override void OnDisconnected(Photon.Realtime.DisconnectCause cause)
{
    // Manejar propia desconexión
    Debug.Log($"Desconectado: {cause}");
    
    // Intentar reconexión automática
    if (cause != DisconnectCause.ApplicationQuit)
    {
        StartCoroutine(ReconnectCoroutine());
    }
}

private IEnumerator ReconnectCoroutine()
{
    yield return new WaitForSeconds(2f);
    
    // Intentar reconectar
    if (!PhotonNetwork.IsConnected)
    {
        PhotonNetwork.Reconnect();
    }
}
```

---

#### 11.12.7 Plan de Implementación por Fases

##### **Fase 7: Sistema de Vida y Daño (Semanas 13-14)**

**Objetivo:** Implementar sistema de vida completo que funcione en ambos modos.

**Tareas:**
1. ✅ Crear interface `IDamageable`
2. ✅ Implementar `CHealthSystem` (sistema base)
3. ✅ Implementar `CNetworkHealth` (sincronización online)
4. ✅ Modificar `PlayerController.Golpe()` para usar nuevo sistema
5. ✅ Integrar con sistema de proyectiles
6. ✅ Testing en ambos modos

**Criterios de Éxito:**
- ✅ HP se sincroniza correctamente en online
- ✅ Daño se aplica correctamente en ambos modos
- ✅ Validación previene valores inválidos
- ✅ No hay desincronización de HP

---

##### **Fase 8: Condiciones de Victoria (Semanas 15-16)**

**Objetivo:** Implementar sistema de victoria robusto.

**Tareas:**
1. ✅ Crear `CGameStateManager`
2. ✅ Implementar condiciones de victoria básicas
3. ✅ Sincronización vía Master Client
4. ✅ UI de fin de juego
5. ✅ Testing en ambos modos

**Criterios de Éxito:**
- ✅ Condiciones de victoria funcionan en ambos modos
- ✅ Sincronización correcta del fin de juego
- ✅ No hay conflictos entre clientes

---

##### **Fase 9: UI de Combate (Semanas 17-18)**

**Objetivo:** UI que muestre información relevante y se sincronice.

**Tareas:**
1. ✅ Health bars para cada jugador
2. ✅ Combo counter (solo local, no requiere sync)
3. ✅ Indicadores de estado
4. ✅ UI de fin de juego
5. ✅ Testing en ambos modos

**Criterios de Éxito:**
- ✅ UI se actualiza correctamente
- ✅ Health bars sincronizadas en online
- ✅ Performance aceptable

---

##### **Fase 10: Sistema de Rondas (Semanas 19-20)**

**Objetivo:** Sistema de rondas que maneje desconexiones.

**Tareas:**
1. ✅ Crear `CRoundManager`
2. ✅ Implementar lógica de rondas
3. ✅ Manejo de desconexiones
4. ✅ Sistema de respawn
5. ✅ Testing con múltiples clientes

**Criterios de Éxito:**
- ✅ Rondas funcionan correctamente
- ✅ Manejo robusto de desconexiones
- ✅ Respawn funciona en ambos modos

---

#### 11.12.8 Checklist de Prevención de Edge Problems

##### Validación de Datos
- [ ] Todos los RPCs validan datos recibidos
- [ ] Rangos válidos para todos los valores (HP, daño, etc.)
- [ ] Validación de existencia de objetos antes de usar
- [ ] Validación de timestamps para acciones temporales

##### Autoridad y Control
- [ ] Verificación de autoridad antes de acciones críticas
- [ ] Master Client para decisiones globales
- [ ] Solo dueño puede modificar su propio estado
- [ ] Validación de autoridad en cada RPC

##### Sincronización
- [ ] IPunObservable para datos críticos
- [ ] RPCs vía servidor (AllViaServer) para acciones importantes
- [ ] Interpolación para movimiento suave
- [ ] Validación y corrección de desincronizaciones

##### Manejo de Errores
- [ ] Fallback a modo local si Photon falla
- [ ] Reconexión automática
- [ ] Manejo de desconexiones durante partida
- [ ] Logging para debugging

##### Performance
- [ ] Sincronización solo cuando hay cambios significativos
- [ ] Limitar frecuencia de sincronización
- [ ] Comprimir datos cuando sea posible
- [ ] Object pooling para proyectiles

---

#### 11.12.9 Beneficios del Plan

##### Para Modo Local
- ✅ Sistema robusto desde el inicio
- ✅ Fácil de testear
- ✅ Base sólida para futuras features

##### Para Modo Online
- ✅ Prevención de cheating
- ✅ Sincronización robusta
- ✅ Manejo de edge cases
- ✅ Experiencia de juego fluida

##### Para Desarrollo
- ✅ Código unificado (menos duplicación)
- ✅ Fácil de mantener
- ✅ Escalable para nuevas features
- ✅ Testing más simple

---

#### 11.12.10 Métricas de Éxito

- ✅ Sistema de vida funciona en ambos modos sin diferencias
- ✅ Sincronización de HP con error < 1%
- ✅ Validación previene 100% de valores inválidos
- ✅ Desincronización detectada y corregida automáticamente
- ✅ Lag compensation reduce quejas de "hit detection" en 80%
- ✅ Manejo de desconexiones sin crashes
- ✅ Performance similar en ambos modos

---

#### 11.12.11 Próximos Pasos

1. **Revisar y aprobar plan:** Validar estrategia
2. **Iniciar Fase 7:** Comenzar con sistema de vida
3. **Testing continuo:** Verificar en ambos modos después de cada feature
4. **Iteración:** Ajustar según feedback y problemas encontrados

---

## 12. Referencias y Notas

### 12.1 Estructura de Archivos
```
Assets/PartyGame/OriginalVersion/Completed-Game/
├── Scripts/
│   ├── Core/ (NUEVO - Fase 1)
│   │   ├── IGameMode.cs
│   │   ├── LocalGameMode.cs
│   │   ├── NetworkGameMode.cs
│   │   ├── GameModeManager.cs
│   │   └── TestGameMode.cs
│   ├── Health/ (FUTURO - Fase 7)
│   │   ├── CHealthSystem.cs
│   │   └── CHealthBar.cs
│   ├── Damage/ (FUTURO - Fase 7)
│   │   ├── CDamageSystem.cs
│   │   └── CDamageInfo.cs
│   ├── GameState/ (FUTURO - Fase 8)
│   │   ├── CGameStateManager.cs
│   │   ├── CWinCondition.cs
│   │   └── CRoundManager.cs
│   ├── Network/ (FUTURO - Fase 3+)
│   │   ├── CNetworkHealth.cs
│   │   ├── CNetworkDamage.cs
│   │   └── CNetworkGameState.cs
│   ├── Attack/
│   ├── Player/
│   ├── Manager/
│   └── Interface/
├── Prefabs/
├── Materials/
├── Animation-Test/
├── InputAction/
├── Resources/ (NUEVO - para Photon)
│   └── PlayerPrefabs/
└── Scenes/
```

### 12.2 Dependencias
- Unity Input System
- Unity Universal Render Pipeline
- TextMesh Pro (opcional)
- Photon PUN 2 (para modo online - opcional, el juego funciona sin él en modo local)

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
**Versión del Documento:** 2.2

### Cambios en Versión 2.2
- ✅ Agregada sección 11.12: Plan de Implementación de Funcionalidades Faltantes
- ✅ Plan detallado para sistema de vida/HP unificado
- ✅ Plan detallado para sistema de daño con validación
- ✅ Plan detallado para condiciones de victoria
- ✅ Plan detallado para sistema de rondas
- ✅ Estrategias específicas para evitar edge problems (cheating, desincronización, lag, desconexiones)
- ✅ Arquitectura propuesta con interfaces y componentes
- ✅ Código de ejemplo para cada funcionalidad
- ✅ Checklist de prevención de edge problems
- ✅ Métricas de éxito definidas

---

### Cambios en Versión 2.1
- ✅ Agregada sección 11.11: Sistemas a Simplificar o Eliminar
- ✅ Identificados sistemas de test/debug a eliminar
- ✅ Identificadas clases vacías o no implementadas
- ✅ Plan de limpieza pre-refactorización (Fase 0)
- ✅ Análisis de impacto de limpieza en reducción de riesgos
- ✅ Checklist completo de limpieza

### Cambios en Versión 2.0
- ✅ Agregada sección completa de Plan de Refactorización e Integración con Photon
- ✅ Documentada estrategia de sistema híbrido unificado
- ✅ Plan de implementación por fases (12 semanas)
- ✅ Checklist completo de implementación
- ✅ Consideraciones de riesgo y mitigación
- ✅ Métricas de éxito definidas

