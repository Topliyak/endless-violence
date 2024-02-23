using UnityEngine;

namespace MyExceptions
{
    public class ValidationExcepiton: UnityException
	{
		public ValidationExcepiton(string message): base(message) { }

		public ValidationExcepiton(): base() { }
	}

	public class BaseInitializerWasntCalledException: UnityException
	{
		public BaseInitializerWasntCalledException(string message): base(message) { }

		public BaseInitializerWasntCalledException(): base() { }
	}

	public class ValidationException : UnityException
	{
		public ValidationException() : base() { }

		public ValidationException(string message) : base(message) { }
	}

	public class SingletonException : UnityException
	{
		public SingletonException() : base() { }

		public SingletonException(string message) : base(message) { }
	}
}
