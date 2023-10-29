using System;
using UnityEngine;

namespace Game.Stats {
	public class ScoreCounter: MonoBehaviour {
		[SerializeField] private int _value = 0;

		public int Value => _value;
		public event Action<int> Changed;

		public void Add(int value) {
			_value += Mathf.Abs(value);
			Changed?.Invoke(_value);
		}
	}
}