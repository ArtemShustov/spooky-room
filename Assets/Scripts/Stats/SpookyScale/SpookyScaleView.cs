using UnityEngine;
using UnityEngine.UI;

namespace Game.Stats.Spooky {
	public class SpookyScaleView: MonoBehaviour {
		[SerializeField] private Image _slider;
		[SerializeField] private SpookyScale _spookyScale;

		public void Change(float value) {
			value = Mathf.Clamp01(value);
			_slider.fillAmount = value;
		}

		private void OnEnable() {
			_spookyScale.Changed += Change;
		}
		private void OnDisable() {
			_spookyScale.Changed -= Change;
		}
	}
}