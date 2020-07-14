//Made by Joao at 7/13/2020 1:20:23 PM

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.MemoryProfiler;
using UnityEngine;

namespace SAE.Assets.Scripts {
	public abstract class AttackBase : MonoBehaviour {

		[SerializeField]
		protected GameObject _weapon;

		[SerializeField]
		protected GameObject _projectilePrefab;

		private void Update() {
			Aim();
			if(Input.GetMouseButtonDown(0)){
				//instantiate a projectile
				Instantiate(_projectilePrefab, _weapon.transform.position, _weapon.transform.rotation);
				//move the projectile
			}
		}

		protected abstract void Aim();
	}
}
