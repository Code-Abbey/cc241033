# cc241033 — Engine-based Cross Reality Development

**Course:** Engine-based Cross Reality Development  
**Programme:** Creative Computing  
**University:** University of Applied Sciences  
**Student ID:** cc241033

---

## What this project is

A Unity 3D assignment where I built a small explorable world with two connected scenes — an outdoor environment and an indoor one. The player can move around, rotate the camera, and walk through trigger zones to travel between scenes.

The focus was on understanding how Unity's Input System, Rigidbody physics, and scene management work together in a cross-reality context.

---

## What's in here

### Scenes
| Scene | Description |
|---|---|
| `Outdoor` | Open fantasy environment with terrain, trees, water, and a camp area |
| `Indoor` | Interior space the player can transition into |

### Scripts (`Assets/Scripts/`)
| Script | What it does |
|---|---|
| `PlayerMovement.cs` | Handles movement and camera orbit using Unity's Input System. Movement goes through the Rigidbody so collisions work properly |
| `SceneChanger.cs` | Loads a new scene when the player walks into a trigger. Passes a spawn ID so the player lands at the right spot |
| `SpawnData.cs` | Static class that keeps the target spawn ID alive across scene loads |
| `SpawnPoint.cs` | Marker placed in each scene — the player teleports to the one matching the incoming spawn ID |
| `Moveable.cs` | Makes any object ping-pong between two positions using Lerp |
| `TransformForwardOutward.cs` | Debug helper — draws a blue arrow in the Scene view showing an object's forward direction |

---

## How to run it

1. Clone this repo
2. Open the folder in **Unity 6 (6000.3.10f1)** with the Universal 3D template
3. Download the required Asset Store packages listed below and import them into `Assets/AssetStore/`
4. Open `Assets/Scenes/Outdoor.unity` and hit Play

> The project uses the **Universal Render Pipeline (URP)** — make sure your Unity install includes it.

---

## Asset Store packages used

These are not included in the repo (third-party licences). Download them free from the Unity Asset Store:

- (P&W) Temple Edition
- Character Witch Dragon
- Low Poly Stylized Nature — Cody Dreams
- Fantasy Skybox FREE
- Little Ghost LP (FREE)
- Low Poly Dungeons Lite
- Walldoff Studios Shared Assets
- RPG Monster Buddies PBR/PA
- Pack Pickup

---

## Things I want to add next

- [ ] Wire up walk/idle animations on the character
- [ ] Add sound effects for movement and scene transitions
- [ ] Place SpawnPoint objects in both scenes and connect them to the SceneChangers
- [ ] Build out the indoor scene with more interactables
