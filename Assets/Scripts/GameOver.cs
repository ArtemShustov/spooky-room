using Game.Shooting;
using Game.Stats.Spooky;
using UnityEngine;

namespace Game {
	public class GameOver: MonoBehaviour {
		[SerializeField] private SpawnersController _spawners;
		[SerializeField] private Shooter _shooter;
		[SerializeField] private SpookyScale _spookyScale;
		[SerializeField] private GameObject _ui;
		[SerializeField] private PlaySound _loseSound;
		
		public void Execute() {
			_spawners.StopSpawn();
			_shooter.enabled = false;
			_ui.SetActive(true);
			_loseSound.PlayOneShot();
		}

		private void OnEnable() {
			_spookyScale.Overflowed += Execute;
		}
		private void OnDisable() {
			_spookyScale.Overflowed -= Execute;
		}
	}
}