using UnityEngine;
using UnityEngine.InputSystem;

namespace Tanks
{
    [RequireComponent(typeof(MoveComponent), typeof(FireComponent))]
    public class InputComponent : MonoBehaviour
    {
        private DirectionTye _lastType;
        private MoveComponent _moveComp;
        private FireComponent _fireComp;
        private MenuController _menuController;        
        private EventManager _eventManager;

        [SerializeField] private InputAction _move;
        [SerializeField] private InputAction _fire;
        [SerializeField] private InputAction _pause;
        [SerializeField] private float _timerPause;
        private float _startTime = 0f;     
        

        void Start()
        {
            _moveComp = GetComponent<MoveComponent>();
            _fireComp = GetComponent<FireComponent>();
            _menuController = FindObjectOfType<MenuController>();
            _eventManager = FindObjectOfType<EventManager>();
            _move.Enable();
            _fire.Enable();
            _pause.Enable();           

            _startTime = _timerPause;
        }
        private void FixedUpdate()
        {
            var fire = _fire.ReadValue<float>();
            if (fire == 1f) _fireComp.OnFire();

            if(Input.GetKeyDown(KeyCode.Escape)) { _menuController.OnPause(); }

            if (Input.GetKey(KeyCode.Escape))
            {
                _startTime -= Time.deltaTime;
                if (_startTime < 0)
                {
                    _menuController.LoadScene(SceneExample.MainMenu);
                    _startTime = _timerPause;
                }                    
            }
            else
                _startTime = _timerPause;


            var direction = _move.ReadValue<Vector2>();
            DirectionTye type;
            if (direction.x != 0f && direction.y != 0f)
            {
                type = _lastType;
            }
            else if (direction.x == 0f && direction.y == 0f) return;
            else type = _lastType = direction.ConvertDirectionFromType();
            
            _moveComp.OnMove(type);
            _eventManager.PostNotification(EventType.Moving);
        }

        private void OnDestroy()
        {
            _move.Dispose();
            _fire.Dispose();
            _pause.Dispose();
        }
    }
}
