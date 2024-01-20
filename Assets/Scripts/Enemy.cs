using UnityEngine;

namespace OneHourJam456
{
    public class Enemy : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<Rigidbody2D>().velocity = (SpaceshipController.Instance.transform.position - transform.position).normalized * .5f;
            SpaceshipController.Instance.RegisterEnemy();
        }

        private void OnDestroy()
        {
            SpaceshipController.Instance.DestroyEnemy();
        }
    }
}
