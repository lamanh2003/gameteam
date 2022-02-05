using Player;
using Skill;
using UnityEngine;

namespace Loader
{
    public class GameAssetsLoader : MonoBehaviour
    {
        private static GameAssetsLoader _i;

        public static GameAssetsLoader Singleton
        {
            get
            {
                if (_i == null) _i = (Instantiate(Resources.Load("GameAssetsLoader")) as GameObject).GetComponent<GameAssetsLoader>();
                return _i;
            }
        }

        #region "Game Resources"
        
        // Prefab
        public GameObject pf_Enemy1;
        public GameObject pf_DamagePopupPrefab;
        public GameObject pf_MagicWandBulletPrefab;
        public GameObject pf_KnifeBullet;
        public GameObject pf_BookBullet;
        public GameObject pf_Exp;
        
        //  ScriptableObject
        public PlayerStats so_PlayerStats;
        public SkillAbstract so_LoadedSkill;
        #endregion
    }
}

