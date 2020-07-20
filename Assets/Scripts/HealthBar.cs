//Made by Joao at 7/20/2020 6:25:19 PM

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SAE.Assets.Scripts {
	public class HealthBar : MonoBehaviour {

		[SerializeField]
		private Image _foreground;

		[SerializeField]
		private HealthBase _health;

		private void OnEnable() {
			_health.HealthChanged += OnHealthChanged;
		}

		private void OnHealthChanged(float newHealth){
			_foreground.fillAmount = newHealth;
		}

	}
}
