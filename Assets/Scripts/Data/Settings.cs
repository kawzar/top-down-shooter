using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "Settings")]
public class Settings : ScriptableObject
{
    [SerializeField]
    private float _disableBulletAfterSeconds;

    public float DisableBulletAfterSeconds => _disableBulletAfterSeconds;
}
