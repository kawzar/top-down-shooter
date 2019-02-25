using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public static BulletManager Instance;

    [SerializeField]
    private Pool<Bullet> bulletPool;

    [SerializeField]
    private Bullet bulletPrefab;

    [SerializeField]
    private int playerLayer;

    [SerializeField]
    private int enemyLayer;

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

    public void PlayerShoot(WeaponData weaponData, Vector3 direction, Vector2 origin)
    {
        Shoot(direction, origin, weaponData, playerLayer);
    }

    public void EnemyShoot(WeaponData weaponData, Vector3 direction, Vector2 origin)
    {
        Shoot(direction, origin, weaponData, enemyLayer);
    }

    public float BulletDamage(Collider2D collision)
    {
        var bullet = collision.GetComponent<Bullet>();
        float dmg = bullet.WeaponData.Damage;
        bullet.Die();

        return dmg;
    }

    private void Shoot(Vector3 direction, Vector2 origin, WeaponData weaponData, int layer)
    {
        var bullet = bulletPool.Get();
        bullet.Configure(weaponData, direction.normalized, origin);
        bullet.gameObject.layer = layer;
    }
}
