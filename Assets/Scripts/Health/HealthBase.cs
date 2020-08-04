//Made by Joao at 7/14/2020 2:43:25 PM

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SAE.Assets.Scripts {
	public abstract class HealthBase : MonoBehaviour {

		[SerializeField]
		protected int _maxHealth;
		[SerializeField]
		protected int _currentHealth;
		[SerializeField]
		private AudioSource _audioSource;
		[SerializeField]
		private AudioClip _damageClip;

		public Team Team;

		public event Action<float> HealthChanged;

		private void OnEnable() {

		}

		private void Awake() {

		}

		private void Start() {
			_currentHealth = _maxHealth;
		}

		private void Update() {

		}

		public void DealDamage(int damage) {
			_currentHealth -= damage;

			HealthChanged?.Invoke((float)_currentHealth / _maxHealth);

			//optional. Since we always the same clip, we don't need to assign it every time
			//_audioSource.clip = _damageClip;

			_audioSource.Play();

			if(_currentHealth <= 0)
				Die();
		}

		protected abstract void Die();
	}
}
