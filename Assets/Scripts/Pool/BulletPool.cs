using UnityEngine;

namespace Pool
{
	public class BulletPool : ObjectsPool<Rigidbody>
	{
		private static bool _awaked = false;

		protected override void Awake()
		{
			base.Awake();

			if (_awaked)
				throw new MyExceptions.SingletonException();

			_awaked = true;
		}
	}
}
