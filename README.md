# cc241033 — Engine-based Cross Reality Development

| | |
|---|---|
| **Course** | Engine-based Cross Reality Development |
| **Programme** | Creative Computing (BCC) |
| **University** | USTP — University of Applied Sciences St. Pölten |
| **Student ID** | cc241033 |
| **Engine** | Unity 6 (6000.3.10f1) · Universal Render Pipeline |

---

## About the project

A Unity 3D assignment where I built a small explorable world with two connected scenes — an outdoor fantasy environment and an indoor space. The player can walk around, rotate the camera, and step through trigger zones to travel between scenes.

The main focus was getting comfortable with Unity's Input System, Rigidbody-based physics movement, and scene management — all things that matter a lot when building cross-reality experiences.

---

## Scenes

| Scene | Description |
|---|---|
| `Outdoor` | Open fantasy environment with terrain, trees, water, bridges, and a camp area |
| `Indoor` | Interior space connected to the outdoor scene via trigger portals |

---

## Scripts

| Script | What it does |
|---|---|
| `PlayerMovement.cs` | Third-person movement and camera orbit using Unity's Input System. Uses `Rigidbody.MovePosition` so collisions and gravity are handled by physics |
| `SceneChanger.cs` | Detects when the player enters a trigger and loads the target scene. Passes a spawn ID so the player arrives at the right spot |
| `SpawnData.cs` | Static class that carries the target spawn ID across scene loads (static fields survive scene transitions) |
| `SpawnPoint.cs` | Marker placed in each scene with a matching ID. The player teleports here on arrival. Shows a green gizmo in the editor |
| `Moveable.cs` | Moves any object back and forth between two positions using `Vector3.Lerp` |
| `TransformForwardOutward.cs` | Debug helper — draws a blue arrow in the Scene view to visualise an object's forward direction |

---

## How to run it

1. Clone this repo
2. Open the folder in **Unity 6 (6000.3.10f1)** — use the Universal 3D (URP) template
3. Import the Asset Store packages listed below into `Assets/AssetStore/`
4. Open `Assets/Scenes/Outdoor.unity` and press Play

> **Note:** The project uses the **Universal Render Pipeline (URP)**. Make sure your Unity installation has the URP package.

---

## Asset Store packages

Not included in this repo due to third-party licensing. All are available free on the Unity Asset Store:

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

## What I still want to add

- [ ] Wire up walk/idle animations on the character Animator
- [ ] Add sound effects for movement and scene transitions
- [ ] Place `SpawnPoint` objects in both scenes and connect them to the `SceneChanger` triggers
- [ ] Build out the indoor scene with more interactable objects
