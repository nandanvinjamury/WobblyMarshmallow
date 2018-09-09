using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject fallingMarshmallow;
	private float xRandom;
	[Range(1,5)] public float levelDifficulty;
	Collider2D spawnCreate;
	// Use this for initialization
	void Awake () {
		spawnCreate = gameObject.GetComponent<Collider2D>();
		levelDifficulty = levelDifficulty * .1f;
		InvokeRepeating("CreateMarshmallow", 1f, 5.3f - levelDifficulty);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void CreateMarshmallow() {
		xRandom = Random.Range(spawnCreate.bounds.min.x, spawnCreate.bounds.max.x);
		Instantiate(fallingMarshmallow, new Vector3(xRandom, gameObject.transform.position.y, 0), Quaternion.identity);
	}
}
