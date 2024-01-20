using UnityEngine;

namespace OneHourJam456
{
    public class Enemy : MonoBehaviour
    {
        private bool _canMove;

        private void Start()
        {
            SpaceshipController.Instance.RegisterEnemy();
        }

        private void Update()
        {
            if (!_canMove)
            {
                if (SpaceshipController.Instance.CanMove)
                {
                    GetComponent<Rigidbody2D>().velocity = (SpaceshipController.Instance.transform.position - transform.position).normalized * .5f;
                    _canMove = true;
                }
            }
        }

        private void OnDestroy()
        {
            SpaceshipController.Instance.DestroyEnemy();
        }
    }
}
