//Made by Joao at 7/14/2020 1:36:42 PM

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.Assets.Scripts {
	public class ProjectileMovement : MovementBase {

		[SerializeField]
		private float _range = 10;

		//after how long the projectile is destroyed, in seconds
		//v = d/t     _speed = _range/Lifetime
		//t = d/v     Lifetime = _range/_speed

		//public float Lifetime
		//{
		//	get
		//	{
		//		return _range / _speed;
		//	}
		//}

		//this is a readonly property (it's the same as the one above) - it's syntactic sugar
		public float Lifetime => _range / _speed;

		private void OnEnable() {
			Destroy(gameObject, Lifetime);
		}

		protected override void CalculateDirection() {
			_direction = transform.right;
		}
	}
}
