using UnityEngine;

public class PositionManager : MonoBehaviour
{
    public static PositionManager Instance;

    [SerializeField]
    private Player player;

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

    public Vector3 PlayerPosition()
    {
        return player.transform.position;
    }
}
