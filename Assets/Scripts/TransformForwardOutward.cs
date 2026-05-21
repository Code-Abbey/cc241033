using UnityEngine;

// debug helper — attach to any object to see its forward direction as a blue arrow in the scene view
// no runtime cost, only visible inside the Unity editor
public class TransformForwardOutward : MonoBehaviour
{
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, transform.forward * 2f);
    }
}
