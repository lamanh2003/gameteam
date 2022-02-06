using Loader;
using Player;
using UnityEngine;

namespace Skill.MagicWand
{
    [CreateAssetMenu(menuName = "Skill/MagicWand")]
    public class MagicWand: SkillAbstract
    {
        public float baseDamage;
        [SerializeField]private float force;
        public int projectile;
        private float _damage;
        private GameObject _bulletPrefab;
        private Vector2 _enemyLocate;

        protected override void Awake()
        {
            base.Awake();
            _bulletPrefab = GameAssetsLoader.Singleton.pf_MagicWandBulletPrefab;
        }

        public override bool PrepareSkill()
        {
            _enemyLocate = ClosestEnemy();
            if (PlayerMovement.Singleton.GetCurrentPlayerPosition() != _enemyLocate)
            {
                _damage = playerStats.skillDamage * baseDamage + baseDamage;
                return true;
            }
            return false;
        }
    
        public override void TriggerSkill()
        {
            for (int i = 0; i < projectile; i++)
            {
                GameObject bullet = Instantiate(_bulletPrefab, PlayerMovement.Singleton.GetCurrentPlayerPosition(), Quaternion.identity);
                bullet.GetComponent<MagicBullet>().damage = _damage;
                bullet.GetComponent<Rigidbody2D>().AddForce((_enemyLocate - PlayerMovement.Singleton.GetCurrentPlayerPosition()).normalized*force,ForceMode2D.Impulse);

            }
            
        }
    
    
        private Vector2 ClosestEnemy()
        {
            float minDis = Mathf.Infinity;
            Vector2 res = PlayerMovement.Singleton.GetCurrentPlayerPosition();
            GameObject[] allEnemy = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var v in allEnemy)
            {
                if (minDis>Vector2.Distance(v.transform.position, PlayerMovement.Singleton.GetCurrentPlayerPosition()))
                {
                    minDis = Vector2.Distance(v.transform.position, PlayerMovement.Singleton.GetCurrentPlayerPosition());
                    res = v.transform.position;
                }
            }
            
            return res;
        }

        public override void UpgradeSkill(string args)  // 
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
