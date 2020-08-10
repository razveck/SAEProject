using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.Assets.Scripts {
	public abstract class MovementBase : MonoBehaviour {

		protected Vector2 _direction;

		[SerializeField]
		private Rigidbody2D _rigidbody;

		[SerializeField]
		protected float _speed;

		// Start is called before the first frame update
		void Start() {

		}

		// Update is called once per frame
		void Update() {
			CalculateDirection();

			//normalization formula
			//u = x/magnitude, y/magnitude


			if(_direction.magnitude != 0) {
				//using a temporary variable to hold the modified vector
				//Vector2 dir = new Vector2(_direction.x / _direction.magnitude, _direction.y / _direction.magnitude);
				//_direction = dir;


				//using the _direction itself
				//this does the same thing as above (because it's basically what the compiler does)
				_direction = new Vector2(_direction.x / _direction.magnitude, _direction.y / _direction.magnitude);
			}

			//this is a Unity method that does that
			//_direction.Normalize();

			//solution 1: convert world direction to local direction
			//transform.InverseTransformDirection(_direction)

			//solution 2: Translate relative to world space
			//transform.Translate(_direction * _speed * Time.deltaTime, Space.World);
		}

		private void FixedUpdate() {
			//MovePosition is basically like Translate, but it checks for collisions
			_rigidbody.MovePosition(transform.position + (Vector3)_direction * _speed * Time.deltaTime);
		}

		protected abstract void CalculateDirection();


	}
}