//Made by Joao at 7/27/2020 1:27:56 PM

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.Assets.Scripts {
	public class Weapon : MonoBehaviour {

		private float _timer;
		[SerializeField]
		private float _attackCooldown = 1;
		[SerializeField]
		protected GameObject _projectilePrefab;
		[SerializeField]
		private Transform _shootPoint;
		[SerializeField]
		private Team _team;

		private void Update() {
			if(_timer > 0)
				_timer -= Time.deltaTime;
		}

		public void Attack() {
			if(_timer <= 0) {
				Projectile proj = Instantiate(_projectilePrefab, _shootPoint.position, transform.rotation).GetComponent<Projectile>();
				proj.Team = _team;
				_timer = _attackCooldown;
			}
		}

	}
}
