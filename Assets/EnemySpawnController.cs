using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] spawnPoints = new SpawnPoint[4];
    [SerializeField] private EnemyController _enemyPrefab;

    private void Start()
    {
        Invoke("SpawnEnemy", 2.0f);
    }

    private void SpawnEnemy()
    {
        foreach (var spawnPoint in spawnPoints)
        {
            EnemyController enemy = Instantiate(_enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
        }        
    }
}