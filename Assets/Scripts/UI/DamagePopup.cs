using Controller;
using TMPro;
using UnityEngine;

namespace UI
{
    public class DamagePopup : MonoBehaviour
    {
        private const float MoveSpeed = 2f;
        private const float ScaleSpeed = 20f;
        private const float DisappearSpeed = 5f;
        private float _direction;
        private Color _textColor;
        private TextMeshPro _textMeshPro;
        private float _timeCountdown;

        private void Awake()
        {
            _textMeshPro = GetComponent<TextMeshPro>();
        }


        private void Update()
        {
            transform.position += new Vector3(_direction, 1f, 0) * MoveSpeed * Time.deltaTime;
            _textMeshPro.fontSize += ScaleSpeed / 4f * Time.deltaTime;
            _timeCountdown -= Time.deltaTime;
            if (_timeCountdown < 0)
            {
                _textMeshPro.fontSize -= ScaleSpeed * Time.deltaTime;
                _textColor.a -= DisappearSpeed * Time.deltaTime;
                _textMeshPro.color = _textColor;
                if (_textColor.a < 0) Destroy(gameObject);
            }
        }

        public static DamagePopup CreatePopup(Vector2 locate, float damage, float time = 1f, bool isCriticalHit = false, float direction = 1)
        {
            var loaded = Instantiate(GameAssetsController.Singleton.damagePopupPrefab).GetComponent<DamagePopup>();
            loaded.LoadData(locate, damage, time, isCriticalHit, direction);
            return loaded;
        }

        private void LoadData(Vector2 locate, float damage, float time, bool isCriticalHit, float direction)
        {
            transform.position = locate;
            _direction = direction;
            _timeCountdown = time;
            _textMeshPro.SetText(damage.ToString("0.2"));
            _textMeshPro.color = isCriticalHit ? Color.red : Color.black;
            _textColor = _textMeshPro.color;
        }
    }
}