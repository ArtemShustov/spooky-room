using UnityEngine;

namespace Game.Path {
	public class PathBuilder: MonoBehaviour {
		[SerializeField] private Color _pathColor = Color.red;

		public Vector2[] GetPath() {
			var path = new Vector2[transform.childCount];
			for (int i = 0; i < transform.childCount; i++) {
				path[i] = transform.GetChild(i).position;
			}
			return path;
		}
		public void OnDrawGizmos() {
			Gizmos.color = _pathColor;

			var path = new Vector3[transform.childCount];
			for (int i = 0; i < transform.childCount; i++) {
				var point = transform.GetChild(i);
				point.name = "Point " + i;
				path[i] = point.position;
				Gizmos.DrawSphere(path[i], 0.1f);
			}

			if (path.Length == 0) {
				return;
			}
			Gizmos.DrawLineStrip(path, true);
			Gizmos.color = Color.white;
			Gizmos.DrawLine(path[0], path[1]);
		}
	}
}