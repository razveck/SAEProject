//Made by Joao at 7/13/2020 1:20:23 PM

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.MemoryProfiler;
using UnityEngine;

namespace SAE.Assets.Scripts {
	public abstract class AttackBase : MonoBehaviour {

		[SerializeField]
		protected Weapon _weapon;

		[SerializeField]
		protected Team _team;

		public event Action<Weapon> WeaponChanged;

		private void Start() {
			WeaponChanged?.Invoke(_weapon);
		}

		protected virtual void Update() {
			Aim();
			Attack();
		}

		public virtual void ChangeWeapon(WeaponType newWeapon){
			WeaponChanged?.Invoke(_weapon);
		}

		protected abstract void Aim();
		protected abstract void Attack();
	}
}
