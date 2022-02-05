using Loader;
using Player;
using UnityEngine;

namespace Skill.Knife
{
    [CreateAssetMenu(menuName = "Skill/Knife")]
    public class Knife: SkillAbstract
    {
        [SerializeField] private float baseDamage;
        [SerializeField] private float force;
        private float _damage;
        private GameObject _bulletPrefab;

        protected override void Awake()
        {
            base.Awake();
            _bulletPrefab = GameAssetsLoader.Singleton.pf_KnifeBullet;
        }

        public override bool PrepareSkill()
        {
            _damage = playerStats.skillDamage * baseDamage + baseDamage;
            return true;
        }

        public override void TriggerSkill()
        {
            GameObject loaded = Instantiate(_bulletPrefab, PlayerMovement.Singleton.GetCurrentPlayerPosition(), Quaternion.identity);
            loaded.GetComponent<KnifeBullet>().damage = _damage;
            loaded.GetComponent<Rigidbody2D>().AddForce(PlayerMovement.Singleton.GetPlayerDirection() * force,ForceMode2D.Impulse);
        }
    }
}