using System;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Shooting {
    public class Shootable: MonoBehaviour {
        [SerializeField] private string _deathTrigger = "Shoot";
        [SerializeField] private Animator _animator;
        [SerializeField] private Collider2D _collider;

        public UnityEvent Died;

        public void Death() {
            _collider.enabled = false;
            _animator.SetTrigger(_deathTrigger);
            Died?.Invoke();
        }

        public void OnNeedDestory() {
            Destroy(gameObject);
        }
    }
}
