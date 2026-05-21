using UnityEngine;

// place this on a GameObject in a scene to mark a valid spawn location
// the id should match the targetSpawnId set on the SceneChanger that leads here
public class SpawnPoint : MonoBehaviour
{
    public int id;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 0.5f);
        Gizmos.DrawRay(transform.position, transform.forward * 1.5f);
    }
}
