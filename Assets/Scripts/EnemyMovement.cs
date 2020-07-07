using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.Assets.Scripts {
	public class EnemyMovement : MovementBase {

		private float _timer;

		[SerializeField]
		private float _directionCooldown;

		public Transform player;

		private void Start() {
			_direction = Vector2.right;
		}

		protected override void CalculateDirection() {
			_timer -= Time.deltaTime;

			if(_timer <= 0) {
				_direction = player.position - transform.position;

				_timer = _directionCooldown;
			}
		}
	}
}