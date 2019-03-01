using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerThree : MonoBehaviour {
    CanvasCtrl cVas;
    Collider2D coll;
    private void Start()
    {
        cVas = GameObject.Find("Canvas").GetComponent<CanvasCtrl>();
        coll = this.gameObject.GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        coll.enabled = false;
        cVas.DisplayMessage(2);
    }
}
