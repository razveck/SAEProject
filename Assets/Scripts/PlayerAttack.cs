//Made by Joao at 7/13/2020 1:23:14 PM

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.Assets.Scripts {
	public class PlayerAttack : AttackBase {

		public Vector3 PixelPosition;
		public float Angle;
		[SerializeField]
		private float _weaponDistance;

		protected override void Aim() {
			PixelPosition = Camera.main.WorldToScreenPoint(transform.position);

			//Vector A - Vector B = direction from B to A
			Vector3 direction = Input.mousePosition - PixelPosition;

			//convert from radians to degrees
			Angle = Mathf.Atan2(direction.y, direction.x);
			_weapon.transform.rotation = Quaternion.Euler(0, 0, Angle * 57.2958f);

			_weapon.transform.localPosition = new Vector3(Mathf.Cos(Angle), Mathf.Sin(Angle)) * _weaponDistance;

		}

		protected override void Attack() {
			if(Input.GetMouseButtonDown(0)){
				Instantiate(_projectilePrefab, _weapon.transform.position, _weapon.transform.rotation);
			}
		}
	}
}
