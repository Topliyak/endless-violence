using UnityEngine;
using UnityEngine.Events;
using MyExceptions;

namespace Weapons
{
	public abstract class FireGun : MonoBehaviour
	{
		[SerializeField] private float _delay_s;
		[SerializeField] private int _maxBullets;
		[SerializeField] private int _bulletCount;

		public event UnityAction Shot;

		private float lastShootMoment;

		public int FreeBulletSlots => _maxBullets - _bulletCount;

		public int BulletCount => _bulletCount;

		public int MaxBullets => _maxBullets;

		public bool BulletsIsOver => _bulletCount == 0;

		public bool CanShoot => TimeFromDelayIsOver && BulletsIsOver == false;

		private bool TimeFromDelayIsOver => Time.realtimeSinceStartup - lastShootMoment >= _delay_s;

		public void TryShoot()
		{
			if (CanShoot)
			{
				Shoot();

				_bulletCount--;
				lastShootMoment = Time.realtimeSinceStartup;

				Shot?.Invoke();
			}
		}

		protected abstract void Shoot();

		public void AddBullets(int count)
		{
			if (count > FreeBulletSlots)
				throw new System.ArgumentException("Tryed add more bullets than count of available slots");

			if (count <= 0)
				throw new System.ArgumentException("Tryed add not positive bullets count");

			_bulletCount += count;
		}

		protected virtual void OnValidate()
		{
			if (_bulletCount < 0)
				throw new ValidationExcepiton("Bullet count must be non negative");

			if (_bulletCount > _maxBullets)
				throw new ValidationExcepiton("Bullet count is more than maximum count");

			if (_delay_s <= 0)
				throw new ValidationExcepiton("Delay must be positive");
		}
	}
}
