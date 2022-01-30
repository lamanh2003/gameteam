using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controller
{
    public class GameAssetsController : MonoBehaviour
    {
        private static GameAssetsController _i;

        public static GameAssetsController Singleton
        {
            get
            {
                if (_i == null) _i = (Instantiate(Resources.Load("GameAssetsController")) as GameObject).GetComponent<GameAssetsController>();
                return _i;
            }
        }

        #region "Game Resources"

        public GameObject enemy1;
        public GameObject damagePopupPrefab;
        public GameObject magicWandBulletPrefab;

        #endregion
    }
}

