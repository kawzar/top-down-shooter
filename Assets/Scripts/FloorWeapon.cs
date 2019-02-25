using UnityEngine;

public class FloorWeapon : Weapon
{
    private SpriteRenderer spriteRenderer;

    public override void Configure(WeaponData weaponData)
    {
        base.Configure(weaponData);
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.spriteRenderer.color = this.WeaponData.Color;
    }

    public void Pickup()
    {
        Destroy(this.gameObject);
    }
}
