
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public float Horizontal;
    public float Vertical;
    public Vector3 MousePosition;
    public delegate void InteractionHappened(InputAction eventType);
    public event InteractionHappened OnInteractionHappened;
    public static InputManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        Horizontal = Input.GetAxisRaw(Constants.Axis.Horizontal);
        Vertical = Input.GetAxisRaw(Constants.Axis.Vertical);
        MousePosition = Input.mousePosition;

        if (Input.GetKeyDown(KeyCode.E))
        {
            OnInteractionHappened?.Invoke(InputAction.OnInteractionHappened);
        }

        if (Input.GetMouseButtonDown(0))
        {
            OnInteractionHappened?.Invoke(InputAction.OnClickHappened);
        }
    }
}
