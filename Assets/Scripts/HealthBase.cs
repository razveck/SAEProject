//Made by Joao at 7/14/2020 2:43:25 PM

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.Assets.Scripts {
	public abstract class HealthBase : MonoBehaviour {

		[SerializeField]
		protected int _maxHealth;
		[SerializeField]
		protected int _currentHealth;

		public Team Team;

		private void OnEnable() {

		}

		private void Awake() {

		}

		private void Start() {
			_currentHealth = _maxHealth;
		}

		private void Update() {

		}

		public void DealDamage(int damage){
			_currentHealth -= damage;

			if(_currentHealth <= 0)
				Die();
		}

		protected abstract void Die();
	}
}
