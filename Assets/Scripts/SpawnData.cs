// static holder for spawn info that needs to survive a scene load
// Unity destroys all MonoBehaviours between scenes, but static fields stay alive
public static class SpawnData
{
    public static int TargetSpawnId = -1; // -1 means no specific spawn was requested
}
