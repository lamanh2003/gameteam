using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "PlayerStatsSO", menuName = "Player/PlayerStats", order = 1)]
    public class PlayerStats : ScriptableObject
    {
        public float maxHealth;
        public float currentHealth;
        public int currentLevel;
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
    }
}

