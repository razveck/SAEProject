//Made by Joao at 7/14/2020 3:21:58 PM

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.Assets.Scripts {
	public class EnemyAttack : AttackBase {

		private float _timer;

		[SerializeField]
		private Transform _player;

		[SerializeField]
		private Transform _shootPoint;

		[SerializeField]
		private float _attackCooldown = 1;

		protected override void Aim() {
			Vector3 direction = _player.position - transform.position;

			float angle = Mathf.Atan2(direction.y, direction.x);
			_weapon.transform.rotation = Quaternion.Euler(0, 0, angle * 57.2958f);
		}

		protected override void Attack() {
			_timer -= Time.deltaTime;

			if(_timer <= 0) {
				Projectile proj = Instantiate(_projectilePrefab, _shootPoint.position, _weapon.transform.rotation).GetComponent<Projectile>();
				proj.Team = _team;
				_timer = _attackCooldown;
			}
		}
	}
}
