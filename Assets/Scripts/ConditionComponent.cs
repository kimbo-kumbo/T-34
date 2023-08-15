using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks
{
    public class ConditionComponent : MonoBehaviour
    {
        [SerializeField] protected int _health = 3;
        public virtual void SetDamage(int damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        } 
    }
}
