using System;
using Other;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menu
{
    public class Menu: MonoBehaviour
    {
        public Button startButton;
        private TextMeshProUGUI gold;
        private GameData gameData;

        private void Awake()
        {
            startButton.onClick.AddListener(Click);
            gameData = FileLoad.GetGameData();
            gold = startButton.transform.parent.GetChild(1).GetComponent<TextMeshProUGUI>();
        }

        private void Update()
        {
            gold.text = gameData.Gold.ToString();
        }

        private void Click()
        {
            SceneManager.LoadScene("MainGame");
            
        }
    }
}