using System;
using System.Collections;
using System.Collections.Generic;
using Controller;
using Enemy;
using UnityEngine;
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
            _playerStats = ScriptableObjectController.Singleton.playerStats;
            _playerStats.currentHealth = _playerStats.maxHealth;
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
            if (other.CompareTag("Enemy"))
            {
                TakeDamage(other.gameObject.GetComponent<EnemyAbstract>().damage);
                other.gameObject.GetComponent<EnemyAbstract>().Die();
            }
        }

        private void HandleHealthBar()
        {
            healthBarFill.fillAmount = _playerStats.currentHealth / _playerStats.maxHealth;
        }
    }
}
