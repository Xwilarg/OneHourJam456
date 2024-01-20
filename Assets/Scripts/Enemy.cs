using UnityEngine;

namespace OneHourJam456
{
    public class Enemy : MonoBehaviour
    {
        private void Start()
        {
            SpaceshipController.Instance.RegisterEnemy();
        }

        private void OnDestroy()
        {
            SpaceshipController.Instance.DestroyEnemy();
        }
    }
}
