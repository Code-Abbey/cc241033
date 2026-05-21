using UnityEngine;

public class Moveable : MonoBehaviour
{
    [SerializeField] Vector3 moveBy;
    [SerializeField] float timeForMovement;

    Vector3 startPos, targetPos;
    float passedTime;

    void Start()
    {
        startPos = transform.position;
        targetPos = startPos + moveBy;
    }

    void Update()
    {
        float t = passedTime / timeForMovement;
        transform.position = Vector3.Lerp(startPos, targetPos, t);
        passedTime += Time.deltaTime;

        // once we reach the target, flip the direction so it goes back and forth
        if (t >= 1f)
        {
            (startPos, targetPos) = (targetPos, startPos);
            passedTime = 0;
        }
    }
}
