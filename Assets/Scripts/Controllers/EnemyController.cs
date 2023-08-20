using System.Collections;
using UnityEngine;

namespace Tanks
{
    [RequireComponent(typeof(MoveComponent), typeof(FireComponent))]
    public class EnemyController : MonoBehaviour
    {
        private float _timerMove;
        private DirectionTye _lastType;
        private Vector2 _directionValue = new Vector2(0, 1);
        private MoveComponent _moveComp;
        private FireComponent _fireComp;
        private Transform _player;
        [SerializeField, Range(1f, 5f)] private float _timeForwardMove;        
        [SerializeField] private GameObject _rayStartPoint;

        private void Start()
        {
            _timerMove = _timeForwardMove;
            _player = FindAnyObjectByType<PlayerConditionComponent>().transform;
            _moveComp = GetComponent<MoveComponent>();
            _fireComp = GetComponent<FireComponent>();
            StartCoroutine(CheckObstacle());
        }
        private IEnumerator CheckObstacle()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.01f);
                StartRay();
            }
        }


        private void FixedUpdate()
        {
            _fireComp.OnFire();

            _timerMove -= Time.fixedDeltaTime;
            if (_timerMove < 0)
            {
                ValuationDirection();
                _timerMove = _timeForwardMove;
            }


            var direction = _directionValue;
            DirectionTye type;
            if (direction.x != 0f && direction.y != 0f)
            {
                type = _lastType;
            }
            else if (direction.x == 0f && direction.y == 0f) return;
            else type = _lastType = direction.ConvertDirectionFromType();

            _moveComp.OnMove(type);
        }


        private void ValuationDirection()
        {

            int x = Random.Range(-1, 2);
            int y;
            if (x != 0)
                y = 0;
            else
            {
                if (Random.Range(0, 10) % 2 != 0)
                {
                    y = 1;
                }
                else
                {
                    y = -1;
                }

            }
            _directionValue = new Vector2(x, y);
        }


        private void OnCollisionStay2D(Collision2D collision)
        {
            CellComponent cell = collision.gameObject.GetComponent<CellComponent>();
            if (cell == null) return;
            if (cell.DestroyCell && cell.DestroyProjectile) return;
            ValuationDirection();
            _timerMove = _timeForwardMove;
            //print("впереди препятствие, упёрся боком");
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Projectile bullet = collision.gameObject.GetComponent<Projectile>();
            if (bullet == null) return;
            if (bullet.Side == SideType.Player)
            {
                СounterAttackPlayer(_player);
                _timerMove = _timeForwardMove;
                //print("В нас стреляет игрок");
            }
        }

        private void СounterAttackPlayer(Transform target)
        {
            float scaleSize = gameObject.transform.localScale.x;
            if (target.position.y - transform.position.y > scaleSize)
                _directionValue = Vector2.up;
            else if (target.position.y - transform.position.y < -scaleSize)
                _directionValue = Vector2.down;
            else if (target.transform.position.x - transform.position.x > scaleSize)
                _directionValue = Vector2.right;
            else if (target.transform.position.x - transform.position.x < -scaleSize)
                _directionValue = Vector2.left;
        }


        private void StartRay()
        {
            RaycastHit2D hit = Physics2D.Raycast(_rayStartPoint.transform.position, transform.up, 0.5f);
            Debug.DrawRay(_rayStartPoint.transform.position, transform.up, Color.yellow);

            if (hit.collider != null)
            {

                CellComponent cell = hit.collider.gameObject.GetComponent<CellComponent>();
                if (cell != null)
                {
                    if (!cell.DestroyCell)
                    {
                        ValuationDirection();
                        _timerMove = _timeForwardMove;
                        //print("впереди препятствие");
                        return;
                    }
                }

                FireComponent fire = hit.collider.gameObject.GetComponent<FireComponent>();
                if (fire != null)
                {
                    if (fire.GetSide == SideType.Enemy)
                    {
                        ValuationDirection();
                        _timerMove = _timeForwardMove;
                        //print("впереди союзный танк");
                    }
                }
            }
        }
    }
}