using System;
using System.Collections;
using Enemy;
using Player;
using UnityEngine;

namespace Skill.Book
{
    
    public class BookBullet: MonoBehaviour
    {
        
        public float damage;
        public float timer;
        public float rotateSpeed;
        
        private void Start()
        {
            StartCoroutine(Timer());
            
            
        }

        private void Update()
        {
            
            transform.RotateAround(PlayerMovement.Singleton.GetCurrentPlayerPosition(),Vector3.forward, rotateSpeed * Time.deltaTime);
        }

        private IEnumerator Timer()
        {
            yield return new WaitForSeconds(timer);
            Destroy(gameObject);
        }
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Enemy"))
            {
                col.GetComponent<EnemyAbstract>().TakeDamage(damage);
            }
        }
    }
}