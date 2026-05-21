using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementPerSecond;
    [SerializeField] private float rotationPerSecond;
    [SerializeField] private GameObject camera;
    [SerializeField] private InputActionReference rotateCamera;
    [SerializeField] private InputActionReference movePlayer;

    // optional — drag the character's Animator here in the Inspector
    // needs a bool parameter matching walkBoolName in the Animator Controller
    [SerializeField] private Animator characterAnimator;
    [SerializeField] private string walkBoolName = "isWalking";

    private Rigidbody rb;
    private float cameraOrbitInput;
    private Vector3 moveDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        rotateCamera.action.Enable();
        rotateCamera.action.performed += OnCameraRotation;
        rotateCamera.action.canceled += OnCameraRotationStop;

        movePlayer.action.Enable();
        movePlayer.action.performed += OnPlayerMovement;
        movePlayer.action.canceled += OnPlayerMovementStop;

        TryApplySpawnPoint();
    }

    private void OnDestroy()
    {
        // always unsubscribe callbacks — skipping this causes ghost listeners if the object is destroyed and recreated
        rotateCamera.action.performed -= OnCameraRotation;
        rotateCamera.action.canceled -= OnCameraRotationStop;

        movePlayer.action.performed -= OnPlayerMovement;
        movePlayer.action.canceled -= OnPlayerMovementStop;
    }

    // checks if SceneChanger requested a specific spawn point and teleports the player there
    private void TryApplySpawnPoint()
    {
        if (SpawnData.TargetSpawnId < 0) return;

        foreach (var point in FindObjectsByType<SpawnPoint>(FindObjectsSortMode.None))
        {
            if (point.id == SpawnData.TargetSpawnId)
            {
                transform.SetPositionAndRotation(point.transform.position, point.transform.rotation);
                break;
            }
        }

        SpawnData.TargetSpawnId = -1;
    }

    private void OnPlayerMovement(InputAction.CallbackContext ctx)
    {
        Vector2 input = ctx.ReadValue<Vector2>();
        moveDirection = new Vector3(input.x, 0, input.y);
    }

    private void OnPlayerMovementStop(InputAction.CallbackContext ctx)
    {
        moveDirection = Vector3.zero;
    }

    private void OnCameraRotation(InputAction.CallbackContext ctx)
    {
        Vector2 input = ctx.ReadValue<Vector2>();
        cameraOrbitInput = input.magnitude * Mathf.Sign(input.x);
    }

    private void OnCameraRotationStop(InputAction.CallbackContext ctx)
    {
        cameraOrbitInput = 0;
    }

    private void Update()
    {
        // orbit the camera horizontally around the player each frame
        camera.transform.RotateAround(transform.position, Vector3.up, cameraOrbitInput * rotationPerSecond * Time.deltaTime);
        cameraOrbitInput = 0;
    }

    private void FixedUpdate()
    {
        bool isMoving = moveDirection != Vector3.zero;

        if (isMoving)
        {
            // rotating the player drags the camera along (it's a child object),
            // so we freeze its world transform, rotate the player, then put it back
            Vector3 savedCamPos = camera.transform.position;
            Quaternion savedCamRot = camera.transform.rotation;

            transform.forward = camera.transform.forward;
            transform.rotation *= Quaternion.LookRotation(moveDirection);

            camera.transform.SetPositionAndRotation(savedCamPos, savedCamRot);

            // MovePosition goes through the physics engine so colliders are respected
            rb.MovePosition(rb.position + transform.forward * movementPerSecond * Time.fixedDeltaTime);
        }

        if (characterAnimator != null)
            characterAnimator.SetBool(walkBoolName, isMoving);
    }
}
