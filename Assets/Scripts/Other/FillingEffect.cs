using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Other
{
	public class FillingEffect : MonoBehaviour
	{
		private Image _image;
		private float _playStartedMoment;
		private float _duration;

		public bool playing { get; private set; } = false;

		private void Awake()
		{
			_image = GetComponent<Image>();
		}

		private void Update()
		{
			if (!playing)
				return;

			float timeSincePlayed = Time.realtimeSinceStartup - _playStartedMoment;
			_image.fillAmount = timeSincePlayed / _duration;
		}

		public void Play(float duration_sec)
		{
			_playStartedMoment = Time.realtimeSinceStartup;
			_duration = duration_sec;

			playing = true;
		}

		public void Stop()
		{
			playing = false;
			_image.fillAmount = 0;
		}
	}
}
