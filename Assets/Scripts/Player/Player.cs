using Enemy;
using Loader;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Player
{
    public class Player : MonoBehaviour
    {
        public static Player Singleton;
        private PlayerStats _playerStats;
        private Animator _animator;

        private bool _flagIsDeath;

        public Image healthBarFill;


        private void Awake()
        {
            Singleton = this;
            _animator = GetComponent<Animator>();
            _flagIsDeath = false;
            
        }

        private void Start()
        {
            _playerStats = GameAssetsLoader.Singleton.so_PlayerStats;
            _playerStats.currentHealth = _playerStats.maxHealth;
            _playerStats.currentLevel = 1;
        }

        private void Update()
        {
            HandleHealthBar();
            if (_flagIsDeath) return;
            if (PlayerMovement.Singleton.isMoving())
            {
                _animator.Play("Run");
            }
            else
            {
                _animator.Play("Idle");
            }
        }

        private void Die()
        {
            if (_flagIsDeath) return;
            _animator.Play("Die");
            _flagIsDeath = true;
            SceneManager.LoadScene("Menu");
        }

        public void TakeDamage(float amount)
        {
            float temp = _playerStats.currentHealth - Mathf.Max(amount - _playerStats.armor, 0);
            _playerStats.currentHealth = Mathf.Clamp(temp, 0, _playerStats.maxHealth);
            if (_playerStats.currentHealth <= 0)
            {
                Die();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            
        }

        private void HandleHealthBar()
        {
            healthBarFill.fillAmount = _playerStats.currentHealth / _playerStats.maxHealth;
        }
    }
}
