using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private int sceneId;

    // set this to the id of the SpawnPoint in the destination scene where the player should appear
    [SerializeField] private int targetSpawnId;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SpawnData.TargetSpawnId = targetSpawnId;
            SceneManager.LoadScene(sceneId);
        }
    }
}
