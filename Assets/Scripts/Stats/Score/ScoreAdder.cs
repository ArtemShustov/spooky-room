using UnityEngine;

namespace Game.Stats {
	public class ScoreAdder: MonoBehaviour {
		[SerializeField] private int _value = 1;
		[SerializeField] private ScoreCounter _counter;

		public void SetCounter(ScoreCounter counter) {
			_counter = counter;
		}
		public void Add() {
			_counter.Add(_value);
		}
	}
}