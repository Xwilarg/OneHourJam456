using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace OneHourJam456
{
    public class SpaceshipController : MonoBehaviour
    {
        public static SpaceshipController Instance { get; private set; }

        [SerializeField]
        private TMP_Text _timer;

        [SerializeField]
        private AudioSource _source;

        [SerializeField]
        private GameObject _bulletPrefab;

        [SerializeField]
        private TMP_Text _timeSpent;

        [SerializeField]
        private TMP_Text _winText;

        private float _startGame = 3f;
        private float _otherTime;

        private float _score;

        private int _enemies;

        private float _timeout;

        public void RegisterEnemy()
        {
            _enemies++;
        }
        public void DestroyEnemy()
        {
            _enemies--;

            if (_enemies == 0)
            {
                _winText.gameObject.SetActive(true);
                _winText.text = $"You won!\nYour time: {_otherTime:n2}";
            }
        }

        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            if (_timeout > 0f)
            {
                _timeout -= Time.deltaTime;
                    }

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
            else
            {
                _otherTime += Time.deltaTime;
            }

            Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mouse - (Vector2)transform.position).normalized;
            transform.up = direction;
        }

        public void OnHit(InputAction.CallbackContext value)
        {
            if (value.performed && _source.isPlaying && _timeout <= 0f)
            {

                var r = _source.time % 1;

                if ((r > .15f & r < .35f) || (r > .65f & r < .85f))
                {
                    _timeSpent.text = "No";
                    _timeSpent.color = Color.red;
                    _timeout = 2f;
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