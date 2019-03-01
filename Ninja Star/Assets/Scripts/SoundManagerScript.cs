using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour {

	public static AudioClip jumpSound, slashSound, growthSound, jumpLandSound, bodyDropSound, pitFallSound, shockSound, backgroundSound;
	static AudioSource audioSrc; 

	// Use this for initialization
	void Start () {
		jumpSound = Resources.Load<AudioClip>("jump1");
		slashSound = Resources.Load<AudioClip> ("slash");
		growthSound = Resources.Load<AudioClip> ("growth");
		jumpLandSound = Resources.Load<AudioClip> ("jumplanding");
		bodyDropSound = Resources.Load<AudioClip> ("bodydrop");
		pitFallSound = Resources.Load<AudioClip> ("pitfall");
		shockSound = Resources.Load<AudioClip> ("shock");
		backgroundSound = Resources.Load<AudioClip> ("backgroundmusic2");

		audioSrc = GetComponent<AudioSource> ();


	}

	public static void PlaySound (string clip) {
		switch (clip) {
		case"jump":
			audioSrc.PlayOneShot (jumpSound);
			break;
		case "slash":
			audioSrc.PlayOneShot (slashSound);
			break;
		case "grow":
			audioSrc.PlayOneShot (growthSound);
			break;
		case "jumpland":
			audioSrc.PlayOneShot (jumpLandSound);
			break;
		case "bodyDrop":
			audioSrc.PlayOneShot (bodyDropSound);
			break;
		case "pitfall":
			audioSrc.PlayOneShot (pitFallSound);
			break;
		case "shock":
			audioSrc.PlayOneShot (shockSound);
			break;
		}
	}
}
