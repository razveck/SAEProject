using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.Assets.Scripts {
	public abstract class MovementBase : MonoBehaviour {

		protected Vector2 _direction;

		

		[SerializeField]
		private float _speed;

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


			transform.Translate(_direction * _speed * Time.deltaTime);
		}

		protected abstract void CalculateDirection();


	}
}