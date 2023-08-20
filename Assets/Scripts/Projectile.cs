using UnityEngine;

namespace Tanks
{
    [RequireComponent(typeof(MoveComponent))]
    public class Projectile : MonoBehaviour
    {
        private SideType _side;
        private DirectionTye _direction;
        private EventManager _eventManager;
        private MoveComponent _moveComp;

        [SerializeField] private int _damage =1;
        [SerializeField] private float _lifeTime = 3f;

        public SideType Side  => _side;

        private void Start()
        {
            _moveComp = GetComponent<MoveComponent>();
            _eventManager = FindObjectOfType<EventManager>();
            Destroy(gameObject, _lifeTime);            
        }

        public void SetParams(DirectionTye direction, SideType side)
            => (_direction, _side) = (direction, side);

        private void Update()
        {
            _moveComp.OnMove(_direction);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
             var fire = collision.GetComponent<FireComponent>();
            if(fire != null)
            {
                if (fire.GetSide == _side) return;
                var condition = fire.GetComponent<ConditionComponent>();
                condition.SetDamage(_damage);
                _eventManager.PostNotification(EventType.Brickhit);
                Destroy(gameObject);
                return;
            }

            var cell = collision.GetComponent<CellComponent>();
            if(cell != null)
            {
                if (cell.DestroyProjectile)
                    Destroy(gameObject);
                if (cell.DestroyCell) 
                {
                    _eventManager.PostNotification(EventType.Brickhit);
                    Destroy(cell.gameObject);                    
                } 
                return;
            }
        }
    }
}