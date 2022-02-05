using Loader;
using Player;
using UnityEngine;

namespace Skill.Book
{
    [CreateAssetMenu(menuName = "Skill/Book")]
    public class Book: SkillAbstract
    {
        [SerializeField] private float baseDamage;
        [SerializeField] private float totalTime;
        [SerializeField] private float rotateSpeed;
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
            BookBullet loaded = Instantiate(_bookPrefab, PlayerMovement.Singleton.GetCurrentPlayerPosition() + Vector2.up, Quaternion.identity,PlayerMovement.Singleton.gameObject.transform).GetComponent<BookBullet>();
            loaded.damage = _damage;
            loaded.timer = totalTime;
            loaded.rotateSpeed = rotateSpeed;
        }
    }
}