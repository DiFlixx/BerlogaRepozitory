using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    private int _maxHealth = 6;
    [SerializeField]
    private HealthBar _healthBar;

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
        _healthBar.UpdateHealthUI();

        if (_currentHealth <= 0)
        {
            Death();
        }
    }

    public void Heal(int healAmount)
    {
        // Добавляем здоровье
        _currentHealth += healAmount;

       _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
    }

    public void Death()
    {
        SceneManager.LoadScene("DeathScene");
    }
}
