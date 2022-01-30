using Controller;
using Player;
using UnityEngine;


namespace Skill
{
    public abstract class SkillAbstract: ScriptableObject
    {
        public string skillName;
        public string skillDescription;
        public float skillCooldown;
        public AudioClip skillSound;
        public PlayerStats playerStats;

        protected virtual void Awake()
        {
            playerStats = ScriptableObjectController.Singleton.playerStats;
        }

        protected virtual void Start()
        {
            
        }


        public abstract bool PrepareSkill();
        public abstract void TriggerSkill();
    }
}
