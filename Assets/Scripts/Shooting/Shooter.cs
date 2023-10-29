using System;
using UnityEngine;

namespace Game.Shooting {
	public class Shooter: MonoBehaviour { // M & C
		[SerializeField] private ShooterView _view;
		[SerializeField] private Transform _point;

		private void Update() {
			if (_point == null) {
				return;
			}

			if (Input.GetMouseButtonDown(0)) {
				Shoot();
			}
		}

		private void Shoot() {
			var hits = Physics2D.OverlapCircleAll(transform.position, 0.1f);
			foreach (var hit in hits) {
				if (hit.transform.TryGetComponent<Shootable>(out var target)) {
					target.Death();
				}
			}
			_view.Shoot();
		}
	}
}