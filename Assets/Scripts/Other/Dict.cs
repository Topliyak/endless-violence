using System.Collections.Generic;

namespace Other
{
	[System.Serializable]
	public class Dict<TKey, TValue>
	{
		public List<KeyValuePair<TKey, TValue>> keyValuePairs;

		public Dictionary<TKey, TValue> ToSystemDictionary()
		{
			Dictionary<TKey, TValue> sysDict = new Dictionary<TKey, TValue>();

			foreach (var pair in keyValuePairs)
				sysDict[pair.a] = pair.b;

			return sysDict;
		}
	}
}
