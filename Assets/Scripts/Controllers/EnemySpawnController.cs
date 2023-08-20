using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tanks
{
    public class EnemySpawnController : MonoBehaviour, IListener
    {
        private int _maxCountEnemy;
        private int _curentCountEnemy;
        private EventManager _eventManager;
        private List<float> _mindistances = new List<float>();
        private List<EnemyController> _enemys = new List<EnemyController>();

        [SerializeField, Range(0f, 2f)] private float _delaySpawnEnemy;
        [SerializeField] private SpawnPoint[] spawnPoints = new SpawnPoint[4];
        [SerializeField] private EnemyController _enemyPrefab;


        public List<EnemyController> Enemys { get => _enemys; set => _enemys = value; }

        private void Start()
        {
            Invoke("SpawnEnemys", _delaySpawnEnemy);
            _eventManager = FindObjectOfType<EventManager>();
            _maxCountEnemy = GameConfiguration.CountEnemy;
            _eventManager.AddListener(EventType.EnemyDeath, this);
        }

        private void SpawnEnemys()
        {
            foreach (var spawnPoint in spawnPoints)
            {
                SpawnEnemy(spawnPoint);
            }
        }

        private void SpawnEnemy(SpawnPoint spawnPoint)
        {
            EnemyController enemy = Instantiate(_enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
            Enemys.Add(enemy);
            _curentCountEnemy++;
        }

        public void OnEvent(EventType eventType)
        {           
            if (_curentCountEnemy >= _maxCountEnemy) return;

            if (eventType == EventType.EnemyDeath)
            {
                foreach (var spawnPoint in spawnPoints)
                {
                    float minDistance = Mathf.Infinity;
                    foreach (EnemyController enemy in Enemys)
                    {
                        if (enemy != null)
                        {
                            var dist = Vector2.Distance(spawnPoint.transform.position, enemy.transform.position);
                            if (dist < minDistance) minDistance = dist;
                        }
                    }
                    spawnPoint._distanceNearestEnemy = minDistance;
                    _mindistances.Add(minDistance);
                }

                var orderedSpawnPoints = spawnPoints.OrderByDescending(n => n._distanceNearestEnemy);
                StartCoroutine(Spawn(orderedSpawnPoints.First()));
            }
        }

        private IEnumerator Spawn(SpawnPoint point)
        {
            yield return new WaitForSeconds(_delaySpawnEnemy);
            SpawnEnemy(point);
        }
    }
}