//Made by Joao at 8/10/2020 3:50:20 PM

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.Assets.Scripts {
	public class Player : MonoBehaviour {
		public static Player Instance { get; private set; }

		private void Awake() {
			//check if there's already an instance of the class
			if(Instance != null) {
				Destroy(gameObject);
			} else {
				Instance = this;
			}
		}
	}
}
