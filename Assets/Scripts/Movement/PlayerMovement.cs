using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.Assets.Scripts {
	public class PlayerMovement : MovementBase {
		protected override void CalculateDirection() {
			_direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		}
	}
}