﻿//Made by Joao at 7/14/2020 2:55:20 PM

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.Assets.Scripts {
	public class Projectile : MonoBehaviour {

		private void OnTriggerEnter2D(Collider2D collision) {
			if(collision.TryGetComponent(out HealthBase health)){
				health.DealDamage(10);

				Destroy(gameObject);
			}
		}

	}
}
