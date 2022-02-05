using System.Collections;
using System.Collections.Generic;
using Loader;
using Skill;
using UnityEngine;
using Player;

namespace Controller
{
    public class SkillController : MonoBehaviour
    {
        [SerializeField] private List<SkillAbstract> allSkill = new List<SkillAbstract>();
        [SerializeField] private GameObject allButton;
        private List<SkillAbstract> _skill= new List<SkillAbstract>();        
        private List<float> _skillCooldown = new List<float>();
        private PlayerStats _playerStats;
        private AudioSource _audioSource;
        

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            
            
        }

        private void Start()
        {
            _playerStats = GameAssetsLoader.Singleton.so_PlayerStats;
           
        }

        private IEnumerator SkillCooldown(int index)
        {
            SkillAbstract vSkillAbstract = _skill[index];
            while (true)
            { 
                if (vSkillAbstract.PrepareSkill())
                {
                    vSkillAbstract.TriggerSkill();
                    CalcCooldown(index);
                }
                yield return new WaitForSeconds(_skillCooldown[index]);
                
            }
        }

        private void CalcCooldown(int index)
        {
            if (index >= _skillCooldown.Count)
            {
                _skillCooldown.Add(_skill[index].skillCooldown * (1 - _playerStats.cooldown / 100));
            }
            _skillCooldown[index] = _skill[index].skillCooldown * (1 - _playerStats.cooldown / 100);
        }

        public void AddSkill(string name)
        {
            switch (name)
            {
                case "MagicWand":
                    _skill.Add(allSkill[0]);
                    StartCoroutine(SkillCooldown(_skill.Count-1));
                    break;
                case "Book":
                    _skill.Add(allSkill[1]);
                    StartCoroutine(SkillCooldown(_skill.Count-1));
                    break;
                case "Knife":
                    _skill.Add(allSkill[2]);
                    StartCoroutine(SkillCooldown(_skill.Count-1));
                    break;
                case "Erase":
                    _skill.Add(allSkill[3]);
                    StartCoroutine(SkillCooldown(_skill.Count-1));
                    break;
            }
        }
    }
}

