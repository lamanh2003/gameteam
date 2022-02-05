using System;
using Loader;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    public class Magnet: MonoBehaviour
    {
        public float speed;
        public float baseRange;
        
        private void Awake()
        {
            GetComponent<CircleCollider2D>().radius = GameAssetsLoader.Singleton.so_PlayerStats.magnet * baseRange / 100 + baseRange;
        }

        private void OnTriggerStay2D(Collider2D col)
        {
            if (col.CompareTag("Exp"))
            {
                col.transform.position = Vector2.MoveTowards(col.transform.position, PlayerMovement.Singleton.GetCurrentPlayerPosition(), speed * Time.deltaTime);
            }
        }
    }
}