using UnityEngine;

namespace Tanks
{
    public class MoveComponent : MonoBehaviour
    {
        [SerializeField] private float _speed = 1f;   
 
        public void OnMove(DirectionTye type)
        {
            if (GameState.GameStateType == GameStateType.PauseGame) return;
            transform.position += type.ConvertTypeFromDirection() * (Time.deltaTime * _speed);
            transform.eulerAngles = type.ConvertTypeFromRotation();            
        }
    }
}