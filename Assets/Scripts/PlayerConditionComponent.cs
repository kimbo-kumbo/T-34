using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tanks
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class PlayerConditionComponent : ConditionComponent
    {       
        private bool _immortal;
        private Vector3 _startPoint;
        private SpriteRenderer _renderer;
        [SerializeField] private float _immortalTime = 3f;
        [SerializeField] private float _immortalSwitchVisual = 0.2f;

        protected override void Start()
        {
            base.Start();
            _health = GameConfiguration.LivePlayer;
            _startPoint = transform.position;
            _renderer = GetComponent<SpriteRenderer>();
        }
        public override void SetDamage(int damage)
        {
            if (_immortal) return;

            _health -= damage;
            _eventManager.PostNotification(EventType.Explosion);
            transform.position = _startPoint;
            StartCoroutine(OnImmortal());
            if (_health <= 0)
            {                
                gameObject.SetActive(false);
                _eventManager.PostNotification(EventType.Gameover);
            }
        }             

        private IEnumerator OnImmortal()
        {
            _immortal = true;
            var time = _immortalTime;
            while (time > 0f)
            {
                _renderer.enabled = !_renderer.enabled;
                time -= _immortalSwitchVisual;                
                yield return new WaitForSeconds(_immortalSwitchVisual);
            }
            _immortal = false;
            _renderer.enabled = true;
        }
    }
}
