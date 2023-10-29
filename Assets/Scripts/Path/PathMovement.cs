using System;
using System.Collections;
using UnityEngine;

namespace Game.Path {
	public class PathMovement: MonoBehaviour {
		[SerializeField] private float _speed = 1f;
		[SerializeField] private bool _loop = false;
		[SerializeField] private Vector2[] _path;

		private Coroutine _pathMovement;

		public void SetPath(Vector2[] path) {
			_path = path;
		}
		public void SetSpeed(float speed) {
			_speed = speed;
		}

		public void StartMovement() {
			if (_pathMovement != null) {
				return;
			}
			_pathMovement = StartCoroutine(MoveByPath(_path));
		}
		public void StopMovement() {
			if (_pathMovement == null) {
				return;
			}
			StopCoroutine(_pathMovement);
			_pathMovement = null;
		}

		private IEnumerator MoveByPath(Vector2[] points) {
			var index = 0;
			while (true) {
				if (index >= points.Length) {
					index = 0;
				}

				var movement = MoveTo(points[index]);
				while (movement.MoveNext()) {
					yield return movement.Current;
				}
				index++;
			}
		}
		private IEnumerator MoveTo(Vector2 point) {
			while (true) {
				var movement = GetCurrentVelocity(point) * Time.deltaTime;
				if (movement.magnitude >= Vector2.Distance(point, (Vector2)transform.position)) {
					transform.position = point;
					yield break;
				}
				transform.position += movement;
				yield return new WaitForEndOfFrame();
			}

			Vector3 GetCurrentVelocity(Vector2 point) {
				return (point - (Vector2)transform.position).normalized * _speed;
			}
		}

	}
}