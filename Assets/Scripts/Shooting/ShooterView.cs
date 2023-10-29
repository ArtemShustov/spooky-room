using UnityEngine;

namespace Game.Shooting {
	public class ShooterView: MonoBehaviour { // V
		[SerializeField] private AudioClip _shootSound;
		[SerializeField] private AudioSource _audioSource;

		public void Shoot() {
			_audioSource.PlayOneShot(_shootSound);
		}
	}
}