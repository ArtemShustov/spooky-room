using Game.Shooting;
using Game.Stats;
using Game.Stats.Spooky;
using System.Collections;
using UnityEngine;

namespace Game {
	public class SpawnersController: MonoBehaviour {
		[SerializeField] private Vector2 _delayRange = new Vector2(0.2f, 10);
		[SerializeField] private GhostSpawner[] _spawners;
		[SerializeField] private ScoreAdder _score;
		[SerializeField] private SpookyScale _spookyScale;
		[SerializeField] private PlaySound _deathSound;

		private Coroutine _spawnLoop;

		private void Awake() {
			StartSpawn();
		}

		private void StartSpawn() {
			if (_spawnLoop != null) {
				return;
			}
			_spawnLoop = StartCoroutine(Loop());
		}
		public void StopSpawn() {
			if (_spawnLoop == null) {
				return;
			}
			StopCoroutine(_spawnLoop);
			_spawnLoop = null;
		}
		public void TriggerRandom() {
			var index = Random.Range(0, _spawners.Length);
			_spawners[index].Spawn();
		}

		public IEnumerator Loop() {
			while (true) {
				yield return new WaitForSeconds(Random.Range(_delayRange[0], _delayRange[1]));
				TriggerRandom();
			}
		}

		private void OnEnemySpawned(Shootable enemy) {
			_spookyScale.Increase();
		}
		private void OnEnemyDied() {
			_score.Add();
			_spookyScale.Decrease();
			_deathSound.PlayOneShot();
		}

		private void OnEnable() {
			foreach (var spawner in _spawners) {
				spawner.GhostDied += OnEnemyDied;
				spawner.GhostSpawned += OnEnemySpawned;
			}
		}
		private void OnDisable() {
			foreach (var spawner in _spawners) {
				spawner.GhostDied -= OnEnemyDied;
				spawner.GhostSpawned -= OnEnemySpawned;
			}
		}
	}
}