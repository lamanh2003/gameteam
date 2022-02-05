using System.Collections;
using Enemy;
using UI;
using UnityEngine;

namespace Skill.Knife
{
    public class KnifeBullet: MonoBehaviour
    {
        public float damage;

        private void Awake()
        {
            StartCoroutine(Timer());
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Enemy"))
            {
                col.GetComponent<EnemyAbstract>().TakeDamage(damage);
                Destroy(gameObject);
            }
        }

        private IEnumerator Timer()
        {
            yield return new WaitForSeconds(10f);
            Destroy(gameObject);
        }
    }
}