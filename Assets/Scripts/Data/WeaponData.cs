using UnityEngine;

[CreateAssetMenu(fileName = "weaponData", menuName = "Weapon Data")]
public class WeaponData : ScriptableObject
{
    [SerializeField]
    private string _name;

    [SerializeField]
    private Color _color;

    [SerializeField]
    private float _fireRate;

    [SerializeField]
    private float _damage;

    [SerializeField]
    private float _bulletVelocity;

    public string Name => _name;
    public Color Color => _color;
    public float FireRate => _fireRate;
    public float Damage => _damage;
    public float BulletVelocity => _bulletVelocity;
}
