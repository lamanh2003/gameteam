using System.Collections;
using Loader;
using Player;
using UnityEngine;

namespace Controller
{
    public class SpawnController : MonoBehaviour
    {
        private float _height;
        private float _width;

        private bool _flagIsStart;

        private void Awake()
        {
            _flagIsStart = true;
        }

        private void Start()
        {
            _height = Camera.main.orthographicSize * 2f;
            _width = _height * Screen.width / Screen.height;
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            while (_flagIsStart)
            {
                InstantiateEnemyOutOfScreen();
                yield return new WaitForSeconds(1);
            }

            yield return null;
        }

        private void InstantiateEnemyOutOfScreen()
        {
            float x, y;
            if (Random.Range(0, 2) == 0)
            {
                //x in y out
                x = Random.Range(-_width / 2f, _width / 2f);
                if (Random.Range(0, 2) == 0)
                {
                    y = Random.Range(_height / 2f, _height / 2 + 1f);
                }
                else
                {
                    y = Random.Range(-_height / 2f, -_height / 2 - 1f);
                }
            }
            else
            {
                //x out y in
                y = Random.Range(-_height / 2f, _height / 2f);
                if (Random.Range(0, 2) == 0)
                {
                    x = Random.Range(_width / 2f, _width / 2 + 1f);
                }
                else
                {
                    x = Random.Range(-_width / 2f, -_width / 2 - 1f);
                }
            }

            x += PlayerMovement.Singleton.GetCurrentPlayerPosition().x;
            y += PlayerMovement.Singleton.GetCurrentPlayerPosition().y;

            Instantiate(GameAssetsLoader.Singleton.pf_Enemy1, new Vector3(x, y, 0), Quaternion.identity);
        }
    }
}
