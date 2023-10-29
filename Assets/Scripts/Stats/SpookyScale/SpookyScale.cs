using System;
using UnityEngine;

namespace Game.Stats.Spooky {
	public class SpookyScale: MonoBehaviour {
		[SerializeField] private int _maxValue = 10;
		[SerializeField] private SpookyScaleView _view;

		private int _value;
		public int Value => _value;

		public event Action Overflowed;

		private void Start() {
			_view.Change(0);
		}

		public void Increase() {
			_value++;
			if (_value >= _maxValue) {
				_value = _maxValue;
				Overflowed?.Invoke();
			}
			_view.Change((float)_value / _maxValue);
		}
		public void Decrease() {
			_value--;
			_view.Change((float)_value / _maxValue);
		}
	}
}