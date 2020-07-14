//Made by Joao at 7/14/2020 1:36:42 PM

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.Assets.Scripts {
	public class ProjectileMovement : MovementBase {

		protected override void CalculateDirection() {
			_direction = transform.right;
		}
	}
}
