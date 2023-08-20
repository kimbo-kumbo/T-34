using System.Collections;
using UnityEngine;

namespace Tanks
{
    public class FireComponent : MonoBehaviour
    {
        private bool _canFire = true;
        private EventManager _eventManager;
        [SerializeField, Range(0.1f, 3f)] private float _delayFire = 0.25f;
        [SerializeField] private Projectile _prefab;
        [SerializeField] private SideType _side;
        

        private void Awake()
        {
            _eventManager = FindObjectOfType<EventManager>();
        }

        public SideType GetSide => _side;

        public void OnFire()
        {
            if (!_canFire || GameState.GameStateType == GameStateType.PauseGame) return;
            var bullet = Instantiate(_prefab,transform.position, transform.rotation);
            bullet.SetParams(transform.eulerAngles.ConvertRotationFromType(), _side);
            if(_eventManager != null)
            _eventManager.PostNotification(EventType.Shoot);
            StartCoroutine(OnDelay());
        }

        private IEnumerator OnDelay()
        {
            _canFire = false;
            yield return new WaitForSeconds(_delayFire);
            _canFire = true;
        }
    }
}