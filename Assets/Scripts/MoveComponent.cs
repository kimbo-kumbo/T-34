using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks
{
    public class MoveComponent : MonoBehaviour
    {
        [SerializeField] private float _speed = 1f;

        public void OnMove(DirectionTye type)
        {
            transform.position += type.ConvertTypeFromDirection() * (Time.deltaTime * _speed);
            transform.eulerAngles = type.ConvertTypeFromRotation();
        }
    }
}