using System;
using Loader;
using UnityEngine;

namespace Other
{
    public class Exp: MonoBehaviour
    {
        private void Awake()
        {
            transform.tag = "Exp";
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                GameAssetsLoader.Singleton.so_PlayerStats.AddExp(2);
                Destroy(gameObject);
            }
        }
    }
}