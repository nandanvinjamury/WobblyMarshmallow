using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parenting : MonoBehaviour {

	Rigidbody m_Rigidbody;

	public bool orphan = true;
	public bool parent = false;

	// Use this for initialization
	void Start () {
		m_Rigidbody = GetComponent<Rigidbody>();		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnCollisionEnter(Collision collision)
	{
		if(orphan && (collision.gameObject.tag == "Marshmallow" || collision.gameObject.tag == "StanMarsh") ){
			if (collision.gameObject.tag == "Marshmallow"){
				Parenting parentObject = collision.gameObject.GetComponent<Parenting>();
				if(parentObject.parent){
					return;
				}
				parentObject.parent = true;
			}
			
			if (collision.gameObject.tag == "StanMarsh"){
				StanMarsh parentObject = collision.gameObject.GetComponent<StanMarsh>();
				if(parentObject.parent){
					return;
				}
				parentObject.parent = true;
			}

			Debug.Log("Hi Mom!", gameObject);
			orphan = false;

			transform.rotation = collision.transform.rotation;
			transform.parent = collision.transform;

			float x_position_noise = (float) ((Random.value-.5)/4f); // [-0.125, 0.125]

 			transform.localPosition = new Vector3(x_position_noise,2,0);

			m_Rigidbody.constraints = 
				RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX |
				RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationY |
				RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ;

		}


	}

}
