using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private WeaponData weaponData;

    public WeaponData WeaponData => weaponData;

    public virtual void Configure(WeaponData weaponData)
    {
        this.weaponData = weaponData;
    }
}
