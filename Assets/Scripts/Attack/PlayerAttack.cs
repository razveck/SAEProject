//Made by Joao at 7/13/2020 1:23:14 PM

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace SAE.Assets.Scripts {
	public class PlayerAttack : AttackBase {

		[SerializeField]
		private List<Weapon> _weaponsList;

		protected override void Aim() {
			Vector3 pixelPosition = Camera.main.WorldToScreenPoint(transform.position);

			//Vector A - Vector B = direction from B to A
			Vector3 direction = Input.mousePosition - pixelPosition;

			//convert from radians to degrees
			float angle = Mathf.Atan2(direction.y, direction.x);
			_weapon.transform.rotation = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg);
			
		}

		protected override void Attack() {
			if(Input.GetMouseButton(0)){
				_weapon.Attack();
			}
		}

		protected override void Update() {
			base.Update();
			if(Input.GetKeyDown(KeyCode.Alpha1)){
				ChangeWeapon((WeaponType)0);
			}
			if(Input.GetKeyDown(KeyCode.Alpha2)){
				ChangeWeapon((WeaponType)1);
			}
			if(Input.GetKeyDown(KeyCode.Alpha3)){
				ChangeWeapon((WeaponType)2);
			}
		}

		public void ChangeWeapon(WeaponType newWeapon){
			//look through the weaponList
			for(int i = 0; i < _weaponsList.Count; i++) {
				if(_weaponsList[i].Type == newWeapon){
					//disable the old weapon
					_weapon.gameObject.SetActive(false);

					//change the current weapon
					_weapon = _weaponsList[i];

					//enable the current weapon
					_weapon.gameObject.SetActive(true);

					//play animations/sounds
				}
			}
		}

		public void Reload(){
			_weapon.Reload();
		}
	}
}
