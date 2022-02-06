using System;
using Controller;
using Skill;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace UI
{
    public class AwardUI: MonoBehaviour
    {
        private GameObject _allSkillGameObject;
        public static AwardUI Singleton;

        private void Awake()
        {
            _allSkillGameObject = transform.GetChild(0).gameObject;
            Singleton = this;
        }

        private void Start()
        {
            Init();
        }

        public void Init()
        {
            int skillCount = 4;
            for (int i = 0; i < 3; i++)
            {
                int tmp = UnityEngine.Random.Range(0, skillCount);
                Transform textTmp = _allSkillGameObject.transform.GetChild(i);
                Debug.Log(tmp);
                if (!SkillController.Singleton.skill.Contains(SkillController.Singleton.allSkill[tmp]))
                {
                    textTmp.GetChild(0).GetComponent<TextMeshProUGUI>().text = SkillController.Singleton.allSkill[tmp].skillName;
                    textTmp.GetComponent<Button>().onClick.AddListener((() => SkillController.Singleton.AddSkill(SkillController.Singleton.allSkill[tmp].skillName)));
                }
                else
                {
                    int upgradeCount = SkillController.Singleton.allSkill[tmp].upgradeable.Count;
                    int ran = UnityEngine.Random.Range(0, skillCount);
                    textTmp.GetChild(0).GetComponent<TextMeshProUGUI>().text = SkillController.Singleton.allSkill[tmp].skillName+": "+SkillController.Singleton.allSkill[tmp].upgradeable[ran];
                    textTmp.GetComponent<Button>().onClick.AddListener((() => SkillController.Singleton.UpgradeSkill(tmp, SkillController.Singleton.allSkill[tmp].upgradeable[ran])));
                }
            }
            
            
             

        }

    }
}