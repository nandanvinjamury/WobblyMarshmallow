using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parenting : MonoBehaviour {

	Rigidbody m_Rigidbody;

	bool orphan = true;

	// Use this for initialization
	void Start () {
		m_Rigidbody = GetComponent<Rigidbody>();		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnCollisionEnter(Collision collision)
	{
		if(orphan){
			Debug.Log("Hi Mom!", gameObject);
			orphan = false;


			transform.rotation = collision.transform.rotation;

			transform.parent = collision.transform;

			float x_noise = (float) ((Random.value-.5)/4f); // [-0.25, 0.25]
						Debug.Log(x_noise, gameObject);

 			transform.localPosition = new Vector3(x_noise,2,0);

			m_Rigidbody.constraints = 
				RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX |
				RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationY |
				RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ;

		}


	}

}
