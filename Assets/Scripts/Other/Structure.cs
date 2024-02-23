namespace Other
{
	[System.Serializable]
	public class Structure<T1>
	{
		public T1 t1;
	}

	[System.Serializable]
	public class Structure<T1, T2>
	{
		public T1 t1;
		public T2 t2;
	}

	[System.Serializable]
	public class Structure<T1, T2, T3>
	{
		public T1 t1;
		public T2 t2;
		public T3 t3;
	}

	[System.Serializable]
	public class Structure<T1, T2, T3, T4>
	{
		public T1 t1;
		public T2 t2;
		public T3 t3;
		public T4 t4;
	}
}
