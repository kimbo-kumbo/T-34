using System.Collections;
using UnityEngine;

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

        private void Start()
        {
            _startPoint = transform.position;
            _renderer = GetComponent<SpriteRenderer>();
        }
        public override void SetDamage(int damage)
        {
            if (_immortal) return;

            _health -= damage;
            transform.position = _startPoint;
            StartCoroutine(OnImmortal());
            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        }

        private IEnumerator OnImmortal()
        {
            _immortal = true;
            var time = _immortalTime;
            while (time > 0f)
            {
                _renderer.enabled = !_renderer.enabled;
                time -= Time.deltaTime;
                yield return new WaitForSeconds(_immortalSwitchVisual);
            }
            _immortal = false;
            _renderer.enabled = true;
        }
    }
}
