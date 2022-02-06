using Loader;
using Player;
using UnityEngine;

namespace Skill.Knife
{
    [CreateAssetMenu(menuName = "Skill/Knife")]
    public class Knife: SkillAbstract
    {
        public float baseDamage;
        [SerializeField] private float force;
        public int projectile;
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
            for (int i = 0; i < projectile; i++)
            {
                GameObject loaded = Instantiate(_bulletPrefab, PlayerMovement.Singleton.GetCurrentPlayerPosition(), Quaternion.identity);
                loaded.GetComponent<KnifeBullet>().damage = _damage;
                loaded.GetComponent<Rigidbody2D>().AddForce(PlayerMovement.Singleton.GetPlayerDirection() * force,ForceMode2D.Impulse);
            }
        }

        public override void UpgradeSkill(string args)
        {
            switch (args)
            {
                case "baseDamage":
                    baseDamage += 1;
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