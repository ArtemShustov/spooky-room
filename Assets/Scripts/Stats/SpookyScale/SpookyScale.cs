using System;
using UnityEngine;

namespace Game.Stats.Spooky {
	public class SpookyScale: MonoBehaviour {
		[SerializeField] private int _maxValue = 10;

		private int _value;
		public int Value => _value;

		public event Action Overflowed;
		public event Action<float> Changed;

		private void Start() {
			Changed?.Invoke(0);
		}

		public void Increase() {
			_value++;
			if (_value >= _maxValue) {
				_value = _maxValue;
				Overflowed?.Invoke();
			}
			Changed?.Invoke((float)_value / _maxValue);
		}
		public void Decrease() {
			_value--;
			Changed?.Invoke((float)_value / _maxValue);
		}
	}
}