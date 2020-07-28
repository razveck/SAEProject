//Made by Joao at 7/20/2020 2:32:23 PM

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.Assets.Scripts {
	public class PlayerHealth : HealthBase {
		protected override void Die() {
			Destroy(gameObject);
		}
	}
}
