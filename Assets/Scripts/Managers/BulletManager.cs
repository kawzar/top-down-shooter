using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public static BulletManager Instance;

    [SerializeField]
    private Pool<Bullet> bulletPool;

    [SerializeField]
    private Bullet bulletPrefab;

    [SerializeField]
    private LayerMask playerLayer;

    [SerializeField]
    private LayerMask enemyLayer;

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

        bulletPool = new Pool<Bullet>(bulletPrefab);
    }

    public void PlayerShoot(WeaponData weaponData, Vector3 direction)
    {
        Shoot(direction, weaponData, playerLayer);
    }

    public void EnemyShoot(WeaponData weaponData, Vector3 direction)
    {
        Shoot(direction, weaponData, enemyLayer);
    }

    public float BulletDamage(Collider2D collision)
    {
        var bullet = collision.GetComponent<Bullet>();
        float dmg = bullet.WeaponData.Damage;
        bullet.Die();

        return dmg;
    }

    private void Shoot(Vector3 direction, WeaponData weaponData, LayerMask layerMask)
    {
        var bullet = bulletPool.Get();
        bullet.gameObject.layer = layerMask;
        bullet.Configure(weaponData, direction.normalized, transform.position);

    }
}
