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

		private void Update() {
			Aim();
		}

		protected abstract void Aim();
	}
}
