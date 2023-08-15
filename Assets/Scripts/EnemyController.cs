using System;
using System.Collections;
using Tanks;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEngine;

[RequireComponent(typeof(MoveComponent), typeof(FireComponent))]
public class EnemyController : MonoBehaviour
{
    private DirectionTye _lastType;
    private Vector2 _directionValue = new Vector2(0,1);    
    private MoveComponent _moveComp;
    private FireComponent _fireComp;
    [SerializeField] private float _delay;

    private float[] dirValue = new float[3] {-1,0,1 };

    private void Start()
    {
        _moveComp = GetComponent<MoveComponent>();
        _fireComp = GetComponent<FireComponent>();
        StartCoroutine(ChangeDirection());
    }


    private void Update()
    {    
        _fireComp.OnFire();

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

    private IEnumerator ChangeDirection()
    {
        while (true)
        {
            int x = UnityEngine.Random.Range(-1, 1);
            int y;
            if (x != 0)
                y = 0;
            else
            {
                if (UnityEngine.Random.Range(0,10)% 2 != 0)
                {
                    y = 1;
                }
                else
                {
                    y= -1;
                }

            }            
            yield return new WaitForSeconds(_delay);
            _directionValue = new Vector2(x,y);
        }        
    }
}