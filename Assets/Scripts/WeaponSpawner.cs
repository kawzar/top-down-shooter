using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    [SerializeField]
    private WeaponData[] weaponDatas;

    [SerializeField]
    FloorWeapon weaponPrefab;

    [SerializeField]
    float circleRadius = 5;

    [SerializeField]
    private LayerMask LayerMask;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            this.SpawnWeapon();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnWeapon()
    {
        bool instantiated = false;
        Vector2 position = Vector2.zero;
        var weaponData = weaponDatas[Random.Range(0, weaponDatas.Length)];

        while (!instantiated)
        {
            position = Random.insideUnitCircle * this.circleRadius;
            var overlapCollider = Physics2D.OverlapCircle(position, 1f, this.LayerMask);
            instantiated = overlapCollider == null;
        }

        var weapon = Instantiate(weaponPrefab, position, Quaternion.identity);
        weapon.Configure(weaponData);
    }
}
