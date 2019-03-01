using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    //character move and gravity variables
    public float movespeed;
    public float gravity;

    //line renderer variables
    private LineRenderer lr;
    public float linevelocity; //the velocity that the projectile will go in for the physics eqn
    public float rAngle; //the launch angle in radians
    public int resolution; //how many nodes there will be to smoothen the line
    private float distance; //distance travelled by arc in the x direction
    private Vector3 mouse; //player mouse position

    //control variables
    private bool canFire; //is allowed to shoot (if a projectile is in the air he can't shoot again)
    public Vector2 startPos; //players original transform
    public GameObject proj;
    public GameObject corpse;
	private Rigidbody2D rb;
	private float fallmultiplier = 0.8f;

    
    public Vector3 newmouse;
    private GameObject lastFired;
	static public GameObject sl;


    private void Awake()
    {
        lr = gameObject.GetComponent<LineRenderer>();
        startPos = gameObject.transform.position;
        newmouse = Input.mousePosition;
        rb = gameObject.GetComponent<Rigidbody2D>();
        canFire = true;
    }

    void Start () {

    }

    //decides how many nodes required for arc and where they should be located
    void RenderArc()
    {
        lr.positionCount = resolution+1; //sets to the variable that decides the number of nodes + the endpoint
        lr.SetPositions(CalculateArcArray());
    }

    Vector3[] CalculateArcArray() //decides the positions of the points of the arc rendering
    {
        Vector3[] array = new Vector3[resolution + 1];
        mouse = Camera.main.ScreenToWorldPoint(newmouse);
        rAngle = Mathf.Atan2(newmouse.y-gameObject.transform.position.y, newmouse.x - gameObject.transform.position.x);
        distance = linevelocity * linevelocity * Mathf.Sin(2 * rAngle) / gravity;  //physics equation of distance travelled in an arc

        array[0] = gameObject.transform.position;
        for(int i = 1; i < array.Length; i++)
        {
            float space = (float)i / (float)resolution;  //evenly spaces nodes by casting the variables to floats for decimal preciseness
            array[i] = CalculateArcPoint(space, distance);
        }

        return array;
    }

    Vector3 CalculateArcPoint(float space, float maxDistance) //calculates x and y of each node 
    {
        Vector3 vector;
        float x = space * maxDistance;
        float y = (x * Mathf.Tan(rAngle)) - (gravity*x*x)/(2*(linevelocity*Mathf.Cos(rAngle))*(linevelocity * Mathf.Cos(rAngle)));
        vector = new Vector3(x, y, 0);
        return vector;
    }















    void FixedUpdate () { //FixedUpdate inorder to pause physics
        PlayerMove();
        PlayerTeleport();
        if (Time.timeScale == 1)
        { //Check if time scale is 1 inorder to display indicator when mouse clicked
            PlayerMouse();
        }
    }

    public void PlayerMove()
    {
		if (rb.velocity.y <= 0) {
			rb.velocity += Physics2D.gravity.y * Vector2.down * (fallmultiplier - 1) * Time.deltaTime;
		}
		if (Input.GetAxis ("Horizontal") != 0) {
			
			rb.velocity = new Vector2 (Input.GetAxis ("Horizontal") * movespeed, rb.velocity.y);
		} else {
			rb.velocity = new Vector2 (0, rb.velocity.y);
		}
    }

    public void PlayerMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lr.enabled = true;
            RenderArc();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Fire();
            lr.enabled = false;
        }
    }

    public void PlayerTeleport()
    {
        if (lastFired && Input.GetMouseButtonDown(1))
        {
            SoundManagerScript.PlaySound("grow");
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            projectile t = lastFired.GetComponent<projectile>();
            Vector2 vel = rb.velocity;
			t.Teleport(rb.velocity,this.gameObject);
            Die();
        }
    }

    public GameObject Fire()
    {
		SoundManagerScript.PlaySound ("slash");
		GameObject projectile = Instantiate(proj);
        projectile.transform.position = transform.position + new Vector3(0, 0.9f, 0);
        Rigidbody2D projRB = projectile.gameObject.GetComponent<Rigidbody2D>();
        projRB.AddForce(new Vector2(Mathf.Cos(rAngle), Mathf.Sin(rAngle))*linevelocity, ForceMode2D.Impulse);
        return projectile;
    }

    /*public Vector3 GetAim()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 AB = (mouse - transform.position);
        float theta = Mathf.Atan2(AB.y, AB.x);
        Vector3 aim = new Vector3(Mathf.Cos(theta), Mathf.Sin(theta),0);
        return aim;
    }
    
    public List<Vector3> DrawAim(Vector3 aim)
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float y0, x0, yi, xi;
        Vector3 v0;
        List<Vector3> line = new List<Vector3>();
        line.Add(transform.position); // first point is player position
        Vector3 AB = (mouse - transform.position);
        float theta = Mathf.Atan2(AB.y, AB.x);
        y0 = line[0].y;
        x0 = line[0].x;
        v0.x = Mathf.Cos(theta)*throw_strength*1.25f;
        v0.y = Mathf.Sin(theta)*throw_strength*1.25f;
        for (float i=0.1f; i<2.0f; i+=0.1f)
        {
            yi = y0 + v0.y * i - .5f * gravity * (i * i);
            xi = x0 + v0.x * i;
            line.Add(new Vector3(xi,yi,0.0f));
        }
        return line;
    }*/

    void Die()
    {
        GameObject cor = Instantiate(corpse);
        cor.gameObject.transform.position = this.transform.position;
        Destroy(this.gameObject);
    }
}