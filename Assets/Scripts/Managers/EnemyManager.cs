using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;

    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private EnemyData[] enemyDatas;

    [SerializeField]
    EnemyWeapon weaponPrefab;

    [SerializeField]
    Enemy enemyPrefab;

    [SerializeField]
    float circleRadius = 5;

    [SerializeField]
    int enemyQuantity = 7;

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

        this.SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < enemyQuantity; i++)
        {
            bool instantiated = false;
            Vector2 position = Vector2.zero;
            var enemyData = enemyDatas[Random.Range(0, enemyDatas.Length)];

            while (!instantiated)
            {
                position = Random.insideUnitCircle * this.circleRadius;
                var overlap = Physics2D.OverlapCircle(position, 1f, this.layerMask);
                instantiated = overlap == null;
            }

            var enemy = Instantiate(enemyPrefab, position, Quaternion.identity);
            enemy.Configure(enemyData);
        }
    }
}
