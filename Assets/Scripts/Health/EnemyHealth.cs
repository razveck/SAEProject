//Made by Joao at 7/14/2020 2:52:46 PM

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.Assets.Scripts {
	public class EnemyHealth : HealthBase {

		[SerializeField]
		private GameObject _lootPrefab;

		protected override void Die() {
			//Instantiate(_lootPrefab, transform.position, Quaternion.identity);
			var loot = ObjectPool.Instance.Request(_lootPrefab);
			loot.transform.position = transform.position;

			Destroy(gameObject);
		}
	}
}
