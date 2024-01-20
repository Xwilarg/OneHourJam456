using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace OneHourJam456
{
    public class SpaceshipController : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _timer;

        [SerializeField]
        private AudioSource _source;

        [SerializeField]
        private GameObject _bulletPrefab;

        [SerializeField]
        private TMP_Text _timeSpent;

        private float _startGame = 3f;

        private float _score;

        private void Awake()
        {
            
        }

        private void Update()
        {
            if (_startGame > 0f)
            {
                _startGame -= Time.time;
                if (_startGame <= 0f )
                {
                    _timer.gameObject.SetActive(false);
                    _source.Play();
                }
                else
                {
                    _timer.text = Mathf.CeilToInt(_startGame).ToString();
                }
            }

            Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mouse - (Vector2)transform.position).normalized;
            transform.up = direction;
        }

        public void OnHit(InputAction.CallbackContext value)
        {
            if (value.performed)
            {

                var r = _source.time % 1;

                if ((r > .15f & r < .35f) || (r > .65f & r < .85f))
                {
                    _timeSpent.text = "No";
                    _timeSpent.color = Color.red;
                }
                else
                {
                    var go = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
                    go.GetComponent<Rigidbody2D>().AddForce(transform.up * 5f, ForceMode2D.Impulse);
                    Destroy(go, 10f);
                    _timeSpent.text = "OK";
                    _timeSpent.color = Color.green;
                }
            }
        }
    }
}