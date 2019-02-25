using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData EnemyData => enemyData;

    [SerializeField]
    private float hp;

    [SerializeField]
    private EnemyWeapon weapon;

    [SerializeField]
    private EnemyData enemyData;

    private float lastTimeShot;
    private bool isConfigured;

    public void Configure(EnemyData enemyData)
    {
        this.enemyData = enemyData;
        this.weapon.Configure(enemyData.WeaponData);
        this.hp = enemyData.Hp;
        GetComponent<SpriteRenderer>().color = enemyData.Color;
        isConfigured = true;
    }

    void Update()
    {
        if (isConfigured && CanShoot())
        {
            AttemptShooting();
        }
    }

    private void AttemptShooting()
    {
        if (Random.Range(0f, 1f) > enemyData.ShootChance)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        var direction = PositionManager.Instance.PlayerPosition() - transform.position;
        BulletManager.Instance.EnemyShoot(weapon.WeaponData, direction);
        lastTimeShot = Time.time;
    }

    private bool CanShoot()
    {
        return weapon.WeaponData != null && Time.time - lastTimeShot >= weapon.WeaponData.FireRate && Time.time - lastTimeShot >= enemyData.ShootFrequency;
    }
}
