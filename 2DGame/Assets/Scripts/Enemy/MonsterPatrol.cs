using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MonsterPatrol : Enemy
{
    [SerializeField] private List<Transform> _points = new List<Transform>();
    [SerializeField] private float _spead;

    private Animator _animator;
    private bool _isFacingRight = true;
    private int _indexPoint;

    protected override void Move()
    {
        _animator.SetFloat("Speed", Mathf.Abs(transform.position.x));
        transform.position = Vector2.MoveTowards(transform.position, _points[_indexPoint].position, _spead * Time.deltaTime);

        if (Vector2.Distance(transform.position, _points[_indexPoint].position) < 0.2f)
        {
            ChangeThePoint();

            if (transform.position.x < _points[_indexPoint].position.x || transform.position.x > _points[_indexPoint].position.x)
            {
                Flip();
            }
        }
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _indexPoint = 0;
    }

    private void Update()
    {
        Move();
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