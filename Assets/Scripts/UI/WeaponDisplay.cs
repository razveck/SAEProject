//Made by Joao at 8/10/2020 2:05:40 PM

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SAE.Assets.Scripts.UI {
	public class WeaponDisplay : MonoBehaviour {

		[SerializeField]
		private TextMeshProUGUI _ammoText;
		[SerializeField]
		private TextMeshProUGUI _weaponNameText;

		[SerializeField]
		private AttackBase _attack;

		private void OnEnable() {
			//subscribing OR adding a listener
			_attack.WeaponChanged += OnWeaponChanged;
		}

		private void OnWeaponChanged(Weapon newWeapon) {
			_weaponNameText.text = newWeapon.Type.ToString();
			newWeapon.AmmoChanged -= OnAmmoChanged;
			newWeapon.AmmoChanged += OnAmmoChanged;
		}

		private void OnAmmoChanged(int value) {
			_ammoText.text = value.ToString();
		}
	}
}
