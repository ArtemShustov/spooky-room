using UnityEngine;
using UnityEngine.UI;

namespace Game.Stats.Spooky {
	public class SpookyScaleView: MonoBehaviour {
		[SerializeField] private Image _slider;

		public void Change(float value) {
			value = Mathf.Clamp01(value);
			_slider.fillAmount = value;
		}
	}
}