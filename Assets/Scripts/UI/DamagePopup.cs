using System.Collections;
using Controller;
using TMPro;
using UnityEngine;

namespace UI
{
    public class DamagePopup : MonoBehaviour
    {
        public static DamagePopup Create(Vector3 position, float dir, bool isCriticalHit, float damageAmount=1f)
        {
            GameObject damagePopupGameObject = Instantiate(GameAssetsController.Singleton.damagePopupPrefab, position, Quaternion.identity);
            DamagePopup damagePopup = damagePopupGameObject.GetComponent<DamagePopup>();
            damagePopup.Setup(damageAmount, dir, isCriticalHit);
            return damagePopup;
        }

        private TextMeshPro _textMesh;
        private float _dir = 1; //-1 is left, 1 is right
        private float _disappearCountdown;
        private Color _textColor;

        private void Awake()
        {
            _textMesh = transform.GetComponent<TextMeshPro>();
        }

        void Update()
        {
            float moveSpeed = 2f;
            float scaleSpeed = 20f;
            Vector3 direction = new Vector3(_dir, 1f, 0);
            transform.position += direction * moveSpeed * Time.deltaTime;

            _textMesh.fontSize += scaleSpeed / 4f * Time.deltaTime;

            _disappearCountdown -= Time.deltaTime;
            if(_disappearCountdown < 0)
            {
                _textMesh.fontSize -= scaleSpeed * Time.deltaTime;

                float disappearSpeed = 5f;
                _textColor.a -= disappearSpeed * Time.deltaTime;
                _textMesh.color = _textColor;
                if(_textColor.a < 0)
                {
                    Destroy(gameObject);
                }
            }
        }

        public void Setup(float damageAmount, float dir, bool isCriticalHit)
        {
            _textMesh.SetText("-" + damageAmount.ToString());
            _dir = dir;
            if (isCriticalHit) _textMesh.color = new Color(255f / 255f, 117f / 255f, 117f / 255f, 1f);
            _textColor = _textMesh.color;
            _disappearCountdown = .3f;
        }
    }
}
