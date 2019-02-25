using UnityEngine;

[CreateAssetMenu(fileName = "enemyData", menuName = "Enemy Data")]
public class EnemyData : ScriptableObject
{
    [SerializeField]
    private WeaponData weaponData;

    [SerializeField]
    private float shootFrequency;

    [SerializeField]
    private float shootChance;

    [SerializeField]
    private Color color;

    [SerializeField]
    private float hp;

    public WeaponData WeaponData => weaponData;
    public float ShootFrequency => shootFrequency;
    public float ShootChance => shootChance;
    public Color Color => color;
    public float Hp => hp;
}
