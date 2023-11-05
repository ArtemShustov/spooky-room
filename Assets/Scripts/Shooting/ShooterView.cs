using UnityEngine;

namespace Game.Shooting {
	public class ShooterView: MonoBehaviour {
		[SerializeField] private Shooter _shooter;
		[SerializeField] private AudioClip _shootSound;
		[SerializeField] private AudioSource _audioSource;

		public void Shoot() {
			_audioSource.PlayOneShot(_shootSound);
		}

		private void OnEnable() {
			_shooter.Shooted += Shoot;
		}
		private void OnDisable() {
			_shooter.Shooted -= Shoot;
		}
	}
}