using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _damage;
    [SerializeField] private float _waitBetweenAttacks;
    [SerializeField] private Coin _coin;

    protected Rigidbody2D _rigedbody;
    private int _health;
    private float _correctTime = 0;

    private void Start()
    {
        _health = _maxHealth;
        _rigedbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _correctTime -= Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_correctTime <= 0 && collision.collider.TryGetComponent<Player>(out Player player))
        {
            player.TakeDamage(_damage);
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Die();
        }
    }

    protected abstract void Move();

    private void Die()
    {
        Destroy(gameObject);
        Instantiate(_coin, transform.position, Quaternion.identity);
    }
}