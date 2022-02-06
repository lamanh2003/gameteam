using System;
using System.Collections;
using Loader;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Other
{
    public class Init: MonoBehaviour
    {
        private void Start()
        {
            InitData();
            StartCoroutine(Timer());
        }

        private void InitData()
        {
            GameAssetsLoader.Singleton.so_Book.projectile = 1;
            GameAssetsLoader.Singleton.so_Book.baseDamage = 5;
            GameAssetsLoader.Singleton.so_Erase.skillCooldown = 10;
            GameAssetsLoader.Singleton.so_Knife.projectile = 1;
            GameAssetsLoader.Singleton.so_Knife.baseDamage = 5;
            GameAssetsLoader.Singleton.so_MagicWand.projectile = 1;
            GameAssetsLoader.Singleton.so_MagicWand.baseDamage = 5;
        }

        private IEnumerator Timer()
        {
            yield return new WaitForSeconds(30);
            Winning();
            
        }

        private void Winning()
        {
            GameData gameData = FileLoad.GetGameData();
            gameData.Gold += 100;
            FileLoad.WriteData(gameData);
            SceneManager.LoadScene("Menu");
        }
        
    }
}