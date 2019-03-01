using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceObject : MonoBehaviour {

    float slope;

	// Use this for initialization
	void Start () {
        if (transform.right.y < 0)
            slope = -1;
        else if (transform.right.y == 0)
            slope = 0;
        else
            slope = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Minions min = collision.gameObject.GetComponent<Minions>();
        if (slope > 0)
        {
            if (min.getDirection().x == 0)
            {
                if (min.getDirection().y < 0)
                    min.setDirection(new Vector2(1, 0));
                else
                    min.setDirection(new Vector2(-1, 0));
            }
            else
            {
                if (min.getDirection().x > 0)
                    min.setDirection(new Vector2(0, -1));
                else
                    min.setDirection(new Vector2(0, 1));
            }
        }
        else if (slope < 0)
        {
            if (min.getDirection().x == 0)
            {
                if (min.getDirection().y < 0)
                    min.setDirection(new Vector2(-1, 0));
                else
                    min.setDirection(new Vector2(1, 0));
            }
            else
            {
                if (min.getDirection().x > 0)
                    min.setDirection(new Vector2(0, 1));
                else
                    min.setDirection(new Vector2(0, -1));
            }
        }
        else
            min.setDirection(-min.getDirection());
    }
}
