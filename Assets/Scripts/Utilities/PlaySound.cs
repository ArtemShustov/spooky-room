using UnityEngine;

namespace Game {
	public class PlaySound: MonoBehaviour {
		[SerializeField] private AudioClip _audioClip;
		[SerializeField] private AudioSource _audioSource;

		public void PlayOneShot() {
			_audioSource.PlayOneShot(_audioClip);
		}
	}
}