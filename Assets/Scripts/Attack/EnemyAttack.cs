//Made by Joao at 7/14/2020 3:21:58 PM

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.Assets.Scripts {
	public class EnemyAttack : AttackBase {

		[SerializeField]
		private Transform _player;


		protected override void Aim() {
			Vector3 direction = _player.position - transform.position;

			float angle = Mathf.Atan2(direction.y, direction.x);
			_weapon.transform.rotation = Quaternion.Euler(0, 0, angle * 57.2958f);
		}

		protected override void Attack() {
			_weapon.Attack();
		}
	}
}
