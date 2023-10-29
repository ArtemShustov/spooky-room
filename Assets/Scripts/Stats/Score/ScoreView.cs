using TMPro;
using UnityEngine;

namespace Game.Stats.UI {
	public class ScoreView: MonoBehaviour {
		[SerializeField] private string _pattern = "Score: {0}";
		[SerializeField] private TMP_Text _label;
		[SerializeField] private ScoreCounter _counter;

		private void UpdateLabel(int score) {
			_label.text = string.Format(_pattern, score);
		}
		
		private void OnEnable() {
			_counter.Changed += UpdateLabel;
			UpdateLabel(_counter.Value);
		}
		private void OnDisable() {
			_counter.Changed -= UpdateLabel;
		}
	}
}