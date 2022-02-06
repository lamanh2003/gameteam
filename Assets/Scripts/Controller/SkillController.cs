using System.Collections;
using System.Collections.Generic;
using Loader;
using Skill;
using UnityEngine;
using Player;
using UI;

namespace Controller
{
    public class SkillController : MonoBehaviour
    {
        public List<SkillAbstract> allSkill = new List<SkillAbstract>();
        public List<SkillAbstract> skill= new List<SkillAbstract>();        
        private List<float> _skillCooldown = new List<float>();
        private PlayerStats _playerStats;
        public static SkillController Singleton;
        

        private void Awake()
        {
            Singleton = this;


        }

        private void Start()
        {
            _playerStats = GameAssetsLoader.Singleton.so_PlayerStats;
           
        }

        private IEnumerator SkillCooldown(int index)
        {
            SkillAbstract vSkillAbstract = skill[index];
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
                _skillCooldown.Add(skill[index].skillCooldown * (1 - _playerStats.cooldown / 100));
            }
            _skillCooldown[index] = skill[index].skillCooldown * (1 - _playerStats.cooldown / 100);
        }

        public void AddSkill(string name)
        {
            Debug.Log("add");
            switch (name)
            {
                case "MagicWand":
                    skill.Add(allSkill[0]);
                    StartCoroutine(SkillCooldown(skill.Count-1));
                    break;
                case "Book":
                    skill.Add(allSkill[1]);
                    StartCoroutine(SkillCooldown(skill.Count-1));
                    break;
                case "Knife":
                    skill.Add(allSkill[2]);
                    StartCoroutine(SkillCooldown(skill.Count-1));
                    break;
                case "Erase":
                    skill.Add(allSkill[3]);
                    StartCoroutine(SkillCooldown(skill.Count-1));
                    break;
            }

            AwardUI.Singleton.gameObject.SetActive(false);
        }

        public void UpgradeSkill(int id,string args)
        {
            skill.Find(x => x.skillName == allSkill[id].skillName).UpgradeSkill(args);
            AwardUI.Singleton.gameObject.SetActive(false);
        }
    }
}

