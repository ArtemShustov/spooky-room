using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Utilities {
	public class LoadScene: MonoBehaviour {
		[SerializeField] private string _sceneName;

		public void Load() {
			SceneManager.LoadScene(_sceneName);
		}
	}
}