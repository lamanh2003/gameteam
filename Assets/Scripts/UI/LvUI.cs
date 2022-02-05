using System;
using Loader;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LvUI: MonoBehaviour
    {
        public Text lvText;

        private void Update()
        {
            lvText.text = GameAssetsLoader.Singleton.so_PlayerStats.currentLevel.ToString();
        }
    }
}