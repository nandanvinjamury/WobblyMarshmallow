using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasCtrl : MonoBehaviour {
    Image img;
    Text[] texts;
    int currentMsg;
	// Use this for initialization
	void Start () {
        texts = GetComponentsInChildren<Text>();
        img = GetComponentInChildren <Image>();
        //{Intro,move,jump,toolong,whoyouare,howtoshoot,howtotp,beware,goodbye}
	}

    public void DisplayMessage(int msg)
    {
        if (msg != 0 && msg != 5)
        {
            if (texts[msg-1].enabled == true)
            {
                texts[msg - 1].enabled = false;
            }
        }
        img.CrossFadeAlpha(1.0f, 0.0f, false);
        texts[msg].enabled = true;
        currentMsg = msg;
        StartCoroutine("FadeMessage");
    }

    private IEnumerator FadeMessage()
    {
        yield return new WaitForSeconds(1.0f);
        texts[currentMsg].CrossFadeAlpha(0, 3.0f, false);
        img.CrossFadeAlpha(0, 3.4f, false);
        yield return new WaitForSeconds(2.0f);
        texts[currentMsg].enabled = false;
    }
}
