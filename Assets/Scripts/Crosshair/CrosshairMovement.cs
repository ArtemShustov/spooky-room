using UnityEngine;

namespace Game.Crosshair {
	public class CrosshairMovement: MonoBehaviour {
		[SerializeField] private float _deepth = 0;
		[SerializeField] private Camera _camera;

		private void Awake() {
			if (_camera == null) {
				_camera = Camera.main;
			}
		}

		private void Update() {
			var mousePosition = Input.mousePosition;
			mousePosition.x = Mathf.Clamp(mousePosition.x, 0, Screen.width);
			mousePosition.y = Mathf.Clamp(mousePosition.y, 0, Screen.height);

			var mouseWorldPosition = _camera.ScreenToWorldPoint(mousePosition);
			mouseWorldPosition.z = _deepth;
			transform.position = mouseWorldPosition;
		}
	}
}