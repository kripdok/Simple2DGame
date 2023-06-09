using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator),typeof(HashEnemyAnimation))]
public class MonsterPatrol : Enemy
{
    [SerializeField] private List<Transform> _points = new List<Transform>();
    [SerializeField] private float _spead;

    private HashEnemyAnimation _hashAnimation;
    private Animator _animator;
    private bool _isFacingRight = true;
    private float _pointDistance = 0.2f;
    private int _indexPoint;

    private void Start()
    {
        _hashAnimation = GetComponent<HashEnemyAnimation>();
        _animator = GetComponent<Animator>();
        _indexPoint = 0;
    }

    private void Update()
    {
        Move();
    }

    protected override void Move()
    {
        _animator.SetFloat(_hashAnimation.SpeedHash, Mathf.Abs(transform.position.x));
        transform.position = Vector2.MoveTowards(transform.position, _points[_indexPoint].position, _spead * Time.deltaTime);

        if (Vector2.Distance(transform.position, _points[_indexPoint].position) < _pointDistance)
        {
            ChangeThePoint();

            if (transform.position.x < _points[_indexPoint].position.x || transform.position.x > _points[_indexPoint].position.x)
            {
                Flip();
            }
        }
    }

    private void ChangeThePoint()
    {
        if (_indexPoint == _points.Count - 1)
        {
            _indexPoint = 0;
        }
        else
        {
            _indexPoint++;
        }
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
}