using Game.Path;
using Game.Shooting;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Game {
	[RequireComponent(typeof(PathMovement))]
	[RequireComponent(typeof(Shootable))]
	public class GhostBulder: MonoBehaviour {
		private PathMovement _pathMovement;
		private Shootable _shootable;

		private void Awake() {
			_pathMovement = GetComponent<PathMovement>();
			_shootable = GetComponent<Shootable>();
		}
		public GhostBulder SetMovement(Vector2[] path, float speed) {
			_pathMovement.SetPath(path);
			_pathMovement.SetSpeed(speed);
			_pathMovement.StartMovement();
			return this;
		}
		public GhostBulder AddDiedAction(UnityAction action) {
			_shootable.Died.AddListener(action);
			return this;
		}
		public Shootable Build() {
			gameObject.SetActive(true);
			Destroy(this);
			return _shootable;
		}

		[Obsolete]
		public void Setup(Vector2[] path, float speed, UnityAction onDied) {
			_shootable.Died.AddListener(onDied);

			_pathMovement.SetPath(path);
			_pathMovement.SetSpeed(speed);
			_pathMovement.StartMovement();
			
			Destroy(this);
		}
	}
}