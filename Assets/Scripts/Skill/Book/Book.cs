using System.Collections;
using Loader;
using Player;
using UnityEngine;

namespace Skill.Book
{
    [CreateAssetMenu(menuName = "Skill/Book")]
    public class Book: SkillAbstract
    {
        public float baseDamage;
        [SerializeField] private float totalTime;
        [SerializeField] private float rotateSpeed;
        public int projectile;
        private float _damage;
        public GameObject _bookPrefab;
        protected override void Awake()
        {
            base.Awake();
            _bookPrefab = GameAssetsLoader.Singleton.pf_BookBullet;
        }

        public override bool PrepareSkill()
        {
            _damage = playerStats.skillDamage * baseDamage + baseDamage;
            return true;
        }

        public override void TriggerSkill()
        {
            for (int i = 0; i < projectile; i++)
            {
                Debug.Log("book fire");
                BookBullet loaded = Instantiate(_bookPrefab, PlayerMovement.Singleton.GetCurrentPlayerPosition() + Vector2.up, Quaternion.identity, PlayerMovement.Singleton.gameObject.transform)
                    .GetComponent<BookBullet>();
                loaded.damage = _damage;
                loaded.timer = totalTime;
                loaded.rotateSpeed = rotateSpeed;
            }
        }
        

        public override void UpgradeSkill(string args)  // +Base dmg và tăng projectile   
        {
            switch (args)
            {
                case "baseDamage":
                    baseDamage += 10;
                    break;
                case "projectile":
                    projectile++;
                    break;
                default:
                    break;
            }
        }
    }
}