
using Player;
using Skill;
using Skill.MagicWand;
using UnityEngine;


namespace Controller
{
    public class ScriptableObjectController : MonoBehaviour
    {
        private static ScriptableObjectController _i;
        public static ScriptableObjectController Singleton
        {
            get
            {
                if (_i == null) _i = (Instantiate(Resources.Load("ScriptableObjcetController")) as GameObject).GetComponent<ScriptableObjectController>();
                return _i;
            }
        }
        #region "Game Resources"
        public PlayerStats playerStats;
        public SkillAbstract loadedSkill;
        #endregion
    }
}




/*
namespace Controller
{
    public class ScriptableObjectController: MonoBehaviour
    {
        public static ScriptableObjectController Singleton;
        [SerializeField] private PlayerStats playerStats;
        [SerializeField] private MagicWand magicWand;
        private readonly Dictionary<string, ScriptableObject> _scriptableObjects = new Dictionary<string, ScriptableObject>();

        private void Awake()
        {
            // Init Singleton
            if (Singleton != null)
            {
                Destroy(this);
                return;
            }
            Singleton = this;
            // Contain All ScriptableObject
            _scriptableObjects.Add("PlayerStats",playerStats);
            _scriptableObjects.Add("MagicWand",magicWand);
        }

        public T GetScriptableObjectByName<T>(string scriptableObjectName)
        {
            if (_scriptableObjects.ContainsKey(scriptableObjectName))
            {
                return (T) Convert.ChangeType(_scriptableObjects[scriptableObjectName],typeof(T));
            }
            Debug.Log("ScriptableObject " + scriptableObjectName + " not exist");
            return default;

        }
    }
}
*/