using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHialth;
    [SerializeField] private TMP_Text _textHealth;
    [SerializeField] private TMP_Text _textPoint;

    public event UnityAction Dead;
    public event UnityAction AddForce;

    private int _health;
    private int _point = 0;

    private void Start()
    {
        _health = _maxHialth;
        _textHealth.text = _health.ToString();
        _textPoint.text = _point.ToString();
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        _textHealth.text = _health.ToString();
        AddForce?.Invoke();

        if (_health <= 0)
        {
            Die();
        }
    }

    public void AddPoints(int point)
    {
        _point += point;
        _textPoint.text = _point.ToString();
    }

    private void Die()
    {
        Dead?.Invoke();
    }
}