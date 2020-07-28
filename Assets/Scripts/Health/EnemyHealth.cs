//Made by Joao at 7/14/2020 2:52:46 PM

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.Assets.Scripts {
	public class EnemyHealth : HealthBase {
		protected override void Die() {
			Destroy(gameObject);
		}
	}
}
