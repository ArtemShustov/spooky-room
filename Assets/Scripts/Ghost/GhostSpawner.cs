using Game.Path;
using Game.Shooting;
using System;
using UnityEngine;

namespace Game {
	public class GhostSpawner: MonoBehaviour {
		[SerializeField] private Vector2 _speedRange = new Vector2(1, 3);
		[Space]
		[SerializeField] private GhostBulder _prefab;
		[SerializeField] private PathBuilder _pathBuilder;

		public event Action GhostDied;
		public event Action<Shootable> GhostSpawned;

		private Vector2[] _path;

		private void Start() {
			_path = _pathBuilder.GetPath();
		}

		public void Spawn() {
			var instance = Instantiate(_prefab, transform);
			instance.transform.SetParent(null);
			float speed = UnityEngine.Random.Range(_speedRange[0], _speedRange[1]);
			var ghost = instance.SetMovement(_path, speed).AddDiedAction(OnGhostDied).Build();
			GhostSpawned?.Invoke(ghost);
		}

		public void OnGhostDied() {
			GhostDied?.Invoke();
		}
	}
}