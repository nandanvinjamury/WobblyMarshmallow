using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soul : MonoBehaviour {
	private Vector3 shooter;
	public GameObject pretarget;
	public static GameObject target;
	public static bool Showspirit = false;
	public float speed;
	// Use this for initialization
	void Start () {
		target = Instantiate(pretarget, this.gameObject.transform.position, this.transform.rotation);		
	}
	
	// Update is called once per frame
	void Update () {
		if (target!=null){
			GameObject chld = target.gameObject.transform.GetChild(0).gameObject;
			Vector3 delta = (transform.position-chld.transform.position);
			if(delta.magnitude<0.5){
				Showspirit=false;
			}else if(delta.magnitude<1.0){
				Showspirit=false;
				this.transform.position = this.transform.position - delta.normalized*Time.deltaTime*speed*2;
			}else{
				this.transform.position = this.transform.position - delta.normalized*Time.deltaTime*speed;
			}
		}
		this.GetComponent<SpriteRenderer>().enabled=Showspirit;
	}
}
