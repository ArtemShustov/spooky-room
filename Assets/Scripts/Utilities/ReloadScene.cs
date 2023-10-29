using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Utilities {
	public class ReloadScene: MonoBehaviour {
		public void Reload() {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}