//Made by Joao at 7/27/2020 1:27:56 PM

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SAE.Assets.Scripts {
	public class Weapon : MonoBehaviour {

		private float _timer;

		[SerializeField]
		private Team _team;
		[SerializeField]
		private float _attackCooldown = 1;
		[SerializeField]
		protected GameObject _projectilePrefab;
		[SerializeField]
		private Transform _shootPoint;

		[SerializeField]
		private int _projectileAmount = 1;
		[SerializeField]
		private float _deviationAngle = 0;

		[SerializeField]
		private AudioSource _audioSource;
		[SerializeField]
		private AudioClip[] _shootClips;

		public WeaponType Type;

		private void Update() {
			if(_timer > 0)
				_timer -= Time.deltaTime;
		}

		public void Attack() {
			if(_timer <= 0) {

				for(int i = 0; i < _projectileAmount; i++) {
					Vector3 euler = transform.rotation.eulerAngles;
					float angle = _deviationAngle / 2;
					euler.z += Random.Range(-angle, angle);

					Projectile proj = Instantiate(_projectilePrefab, _shootPoint.position, Quaternion.Euler(euler)).GetComponent<Projectile>();
					proj.Team = _team;
					_timer = _attackCooldown;
				}

				_audioSource.clip = _shootClips[Random.Range(0, _shootClips.Length)];
				_audioSource.Play();
			}
		}
	}
}