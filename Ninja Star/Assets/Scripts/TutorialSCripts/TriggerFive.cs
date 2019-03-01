using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFive : MonoBehaviour {
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
        StartCoroutine("CallDisplay");
    }
    IEnumerator CallDisplay()
    {
        cVas.DisplayMessage(4);
        yield return new WaitForSeconds(4.7f);
        for (int msg = 5; msg < 8;)
        {
            cVas.DisplayMessage(msg);
            yield return new WaitForSeconds(4.7f);
            msg++;
        }
    }
}
