using UnityEngine;

namespace Tanks
{
    public class ConditionComponent : MonoBehaviour
    {
        protected EventManager _eventManager;
        protected EnemySpawnController _enemySpawnController;
        [SerializeField] protected int _health;

        protected virtual void Start()
        {
            _enemySpawnController = FindObjectOfType<EnemySpawnController>();
            _eventManager = FindObjectOfType<EventManager>();
            _health = GameConfiguration.LiveEnemy;
        }
        public virtual void SetDamage(int damage)
        {            
            _health -= damage;
            if (_health <= 0)
            {
                _enemySpawnController.Enemys.Remove(GetComponent<EnemyController>());
                _eventManager.PostNotification(EventType.Explosion);
                _eventManager.PostNotification(EventType.EnemyDeath);
                Destroy(gameObject);
            }
        } 
    }
}
