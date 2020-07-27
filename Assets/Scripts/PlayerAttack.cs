//Made by Joao at 7/13/2020 1:23:14 PM

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.Assets.Scripts {
	public class PlayerAttack : AttackBase {

		protected override void Aim() {
			Vector3 pixelPosition = Camera.main.WorldToScreenPoint(transform.position);

			//Vector A - Vector B = direction from B to A
			Vector3 direction = Input.mousePosition - pixelPosition;

			//convert from radians to degrees
			float angle = Mathf.Atan2(direction.y, direction.x);
			_weapon.transform.rotation = Quaternion.Euler(0, 0, angle * 57.2958f);
		}

		protected override void Attack() {
			if(Input.GetMouseButton(0)){
				_weapon.Attack();
			}
		}
	}
}
