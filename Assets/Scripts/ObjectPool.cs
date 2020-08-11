//Made by Joao at 8/11/2020 1:38:52 PM

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE.Assets.Scripts {
	public class ObjectPool : MonoBehaviour {

		//Singleton
		public static ObjectPool Instance { get; private set; }

		//we will change this from string to something else
		/// <summary>
		/// Key: prefab
		/// Value: List of instances
		/// </summary>
		private Dictionary<GameObject, List<GameObject>> _pool;

		[SerializeField]
		private List<GameObject> _prefabs;

		private void Awake() {
			if(Instance != null) {
				Destroy(gameObject);
			} else {
				Instance = this;
				//when changing scenes, don't destroy this object
				//Optional: you could have an object pool per scene. In that case, delete the next line
				DontDestroyOnLoad(gameObject);
			}
		}

		private void Start() {
			_pool = new Dictionary<GameObject, List<GameObject>>();

			/* Testing dictionary
			_pool.Add("goat", 2);
			_pool.Add("cat", 2);
			_pool.Add("dog", 5);

			//similar to List. In List the index is the place in the list (number), in Dictionary, the index is the Key
			if(_pool.ContainsKey("giraffe"))
				Debug.Log(_pool["giraffe"].ToString());

			//prefer this version, because it only accessed the dictionary ONCE
			if(_pool.TryGetValue("giraffe", out int ammount)){
				Debug.Log(ammount);
			}
			*/

			for(int i = 0; i < _prefabs.Count; i++) {
				var list = new List<GameObject>();

				for(int n = 0; n < 10; n++) {
					var obj = Instantiate(_prefabs[i]);
					obj.SetActive(false);

					var pooledObject = obj.AddComponent<PooledObject>();
					pooledObject.Prefab = _prefabs[i];

					list.Add(obj);
				}

				_pool.Add(_prefabs[i], list);
			}

		}

		private void Update() {

		}

		public GameObject Request(GameObject prefab) {
			if(_pool.TryGetValue(prefab, out var list)) {
				if(list.Count > 0) {
					var obj = list[list.Count - 1];
					list.Remove(obj);
					obj.SetActive(true);

					return obj;
				}else{
					var obj = Instantiate(prefab);
					obj.SetActive(true);

					var pooledObject = obj.AddComponent<PooledObject>();
					pooledObject.Prefab = prefab;

					return obj;
				}
			} else {
				throw new KeyNotFoundException($"Key: {prefab.name}");
			}
		}

		public void Return(GameObject obj) {
			if(obj.TryGetComponent(out PooledObject pooledObject)) {
				if(_pool.TryGetValue(pooledObject.Prefab, out var list)) {
					list.Add(obj);

					obj.SetActive(false);
				}
			}
		}

	}
}
