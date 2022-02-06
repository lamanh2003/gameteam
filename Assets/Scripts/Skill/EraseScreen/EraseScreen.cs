using Enemy;
using Player;
using UnityEngine;

namespace Skill.EraseScreen
{
    [CreateAssetMenu(menuName = "Skill/EraseScreen")]
    public class EraseScreen : SkillAbstract
    {
       
        
        protected override void Awake()
        {
            base.Awake();
        }

        public override bool PrepareSkill()
        {
            return true;
        }

        public override void TriggerSkill()
        {
            foreach (var vGameObject in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                Vector2 vPos = Camera.main.WorldToScreenPoint(vGameObject.transform.position);
                Debug.Log(vPos);
                if (vPos.x >0 && vPos.x <Screen.width && vPos.y >0 && vPos.y < Screen.height) 
                {
                    vGameObject.GetComponent<EnemyAbstract>().Die();
                }
            }
        }

        public override void UpgradeSkill(string args)
        {
            switch (args)
            {
                case "cooldown":
                    skillCooldown -= 1f;
                    break;
                default:
                    break;
            }
            return;
        }
    }


}