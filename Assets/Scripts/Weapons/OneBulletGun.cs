using UnityEngine;
using Pool;

namespace Weapons
{
	public class OneBulletGun : FireGun
	{
		[SerializeField] private Transform _bulletExit;
		[SerializeField] private float _shootVelocity;

		private BulletPool _bulletPool;

		private void Awake()
		{
			_bulletPool = FindObjectOfType<BulletPool>();
		}

		protected override void Shoot()
		{
			Rigidbody bullet = _bulletPool.Get();
			PrepareBulletToShoot(bullet);
			bullet.WakeUp();
		}

		private void PrepareBulletToShoot(Rigidbody bullet)
		{
			bullet.transform.position = _bulletExit.position;
			bullet.transform.rotation = _bulletExit.rotation;

			bullet.velocity = _bulletExit.forward * _shootVelocity;
			
			bullet.gameObject.SetActive(true);
		}
	}
}
