//Made by Joao at 8/4/2020 3:24:24 PM

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.Assets.Scripts {
	public class Pickup : MonoBehaviour {

		[SerializeField]
		private AudioClip _clip;

		private void OnTriggerEnter2D(Collider2D collision) {
			if(collision.TryGetComponent<PlayerAttack>(out PlayerAttack player)){
				player.Reload();

				AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1);
				ObjectPool.Instance.Return(gameObject);
			}
		}

	}
}
