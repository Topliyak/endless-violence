using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Starter : MonoBehaviour
{
	public UnityEvent started;

	private void Start()
	{
		started.Invoke();
	}
}
