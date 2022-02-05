using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    [CreateAssetMenu(fileName = "PlayerStatsSO", menuName = "Player/PlayerStats", order = 1)]
    public class PlayerStats : ScriptableObject
    {
        public float maxHealth;
        public float currentHealth;
        public int currentLevel=1;
        public float currentExperience;
        public float recovery;
        public float armor;
        public float moveSpeed;

        public float skillDamage;
        public int amountSkill;
        public float cooldown;

        public float luck;
        public float growth;
        public float greed;
        public float magnet;
        
        
        public void AddExp(float amount)
        {
            currentExperience += amount;
            if (currentExperience >= 10)
            {
                currentLevel++;
                currentExperience = 0;
            }
        }
    }
}

