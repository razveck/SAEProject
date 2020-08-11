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
		private int _maximumAmmo;

		//backing field ("backend" of the property)
		private int _currentAmmoBacking;
		private int _currentAmmo
		{
			get {
				return _currentAmmoBacking;
			}
			set
			{
				_currentAmmoBacking = value;

				AmmoChanged?.Invoke(value);
			}
		}

		[SerializeField]
		private AudioSource _audioSource;
		[SerializeField]
		private AudioClip[] _shootClips;

		public WeaponType Type;

		public event Action<int> AmmoChanged;

		private void Start() {
			Reload();
		}

		private void Update() {
			if(_timer > 0)
				_timer -= Time.deltaTime;

			Vector3 scale = transform.localScale;
			float angle = transform.rotation.eulerAngles.z;

			if(angle > 90 && angle < 270) {
				scale.y = -1;
			} else {
				scale.y = 1;
			}
			transform.localScale = scale;

		}
		public void Attack() {
			if(_timer <= 0 && _currentAmmo > 0) {

				for(int i = 0; i < _projectileAmount; i++) {
					Vector3 euler = transform.rotation.eulerAngles;
					float angle = _deviationAngle / 2;
					euler.z += Random.Range(-angle, angle);

					//Projectile proj = Instantiate(_projectilePrefab, _shootPoint.position, Quaternion.Euler(euler)).GetComponent<Projectile>();
					GameObject obj = ObjectPool.Instance.Request(_projectilePrefab);
					obj.transform.position = _shootPoint.position;
					obj.transform.rotation = Quaternion.Euler(euler);

					Projectile proj = obj.GetComponent<Projectile>();

					proj.Team = _team;
					_timer = _attackCooldown;
				}

				_currentAmmo--;

				_audioSource.clip = _shootClips[Random.Range(0, _shootClips.Length)];
				_audioSource.Play();
			}
		}

		public void Reload() {
			_currentAmmo = _maximumAmmo;
		}
	}
}