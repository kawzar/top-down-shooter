using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float velocity;

    [SerializeField]
    private EquippedWeapon Weapon;

    [SerializeField]
    private float hp;

    private bool isNearWeapon;
    private FloorWeapon pickupWeapon;
    private float lastTimeShot;
    private Rigidbody2D rb;
    private Camera _camera;

    private void Start()
    {
        InputManager.Instance.OnInteractionHappened += this.HandleInput;
        this.rb = GetComponent<Rigidbody2D>();
        _camera = Camera.main;
    }

    private void OnDestroy()
    {
        InputManager.Instance.OnInteractionHappened -= this.HandleInput;
    }

    void Update()
    {
        this.Move(InputManager.Instance.Horizontal, InputManager.Instance.Vertical);
    }

    private void HandleInput(InputAction inputAction)
    {
        switch (inputAction)
        {
            case InputAction.OnInteractionHappened:
                this.Interact();
                break;
            case InputAction.OnClickHappened:
                this.Shoot();
                break;
        }
    }

    private void Shoot()
    {
        if (this.Weapon.WeaponData != null && Time.time - lastTimeShot >= Weapon.WeaponData.FireRate)
        {
            var direction = _camera.ScreenToWorldPoint(InputManager.Instance.MousePosition) - transform.position;
            BulletManager.Instance.PlayerShoot(Weapon.WeaponData, direction);
            lastTimeShot = Time.time;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constants.Tags.Weapon))
        {
            this.isNearWeapon = true;
            this.pickupWeapon = collision.gameObject.GetComponent<FloorWeapon>();
        }

        if (collision.CompareTag(Constants.Tags.Projectile))
        {
            this.hp -= BulletManager.Instance.BulletDamage(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(Constants.Tags.Weapon))
        {
            this.isNearWeapon = false;
            this.pickupWeapon = null;
        }
    }

    private void Interact()
    {
        if (isNearWeapon)
        {
            this.Weapon.Configure(pickupWeapon.WeaponData);
            pickupWeapon.Pickup();
            Debug.Log($"Equipped weapon: {this.Weapon.WeaponData.Name}");
        }
    }

    private void Move(float horizontal, float vertical)
    {
        var translation = new Vector3(horizontal, vertical, 0f).normalized;
        rb.velocity = (translation * Time.deltaTime * velocity);
    }
}
