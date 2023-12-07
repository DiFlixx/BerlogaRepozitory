using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    private int _maxHealth = 6;

    private int _currentHealth;

    void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public int GetHealth()
    {
        return _currentHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        _currentHealth -= damageAmount;

        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
    }

    public void Heal(int healAmount)
    {
        // Добавляем здоровье
        _currentHealth += healAmount;

       _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
    }
}
