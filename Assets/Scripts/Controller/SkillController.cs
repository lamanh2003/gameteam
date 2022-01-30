using System;
using System.Collections;
using Skill;
using Skill.MagicWand;
using UnityEngine;
using Player;

namespace Controller
{
    public class SkillController : MonoBehaviour
    {
        private SkillAbstract _skill;
        private float _skillCooldown;
        private PlayerStats _playerStats;
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            
            
        }

        private void Start()
        {
            _playerStats = ScriptableObjectController.Singleton.playerStats;
            _skill = ScriptableObjectController.Singleton.loadedSkill;
            StartCoroutine(SkillCooldown());
        }

        private IEnumerator SkillCooldown()
        {
            while (_skill != null)
            {
                if (_skill.PrepareSkill())
                {
                    _audioSource.clip = _skill.skillSound;
                    _audioSource.Play();
                    _skill.TriggerSkill();
                    CalcCooldown();
                }
                yield return new WaitForSeconds(_skillCooldown);
            }
        }

        private void CalcCooldown()
        {
            _skillCooldown = _skill.skillCooldown * (1 - _playerStats.cooldown / 100);
        }

    }
}

