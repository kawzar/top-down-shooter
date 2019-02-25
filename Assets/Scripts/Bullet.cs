using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public WeaponData WeaponData => _weaponData;

    [SerializeField]
    private WeaponData _weaponData;
    private Vector2 direction;
    private SpriteRenderer spriteRenderer;
    private bool isConfigured;


    void Update()
    {
        this.Move();
    }

    public void Configure(WeaponData weaponData, Vector2 direction, Vector2 origin)
    {
        this._weaponData = weaponData;
        this.direction = direction;
        transform.position = origin;
        gameObject.SetActive(true);
        StartCoroutine(DisableAfterSeconds(SettingsManager.Instance.Settings.DisableBulletAfterSeconds));
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.spriteRenderer.color = this._weaponData.Color;
    }

    private IEnumerator DisableAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Die();
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }

    private void Move()
    {
        var translation = direction;
        transform.Translate(translation * Time.deltaTime * this._weaponData.BulletVelocity);
    }
}
