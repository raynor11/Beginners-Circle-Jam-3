using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
	public float force;
	public List<GameObject> allObjects = new List<GameObject>();

	private Rigidbody2D myRB;
	private float G;
	public Vector2 orbitalVelocity = new Vector2(0.0f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
		// Get own rigidbody
		myRB = GetComponent<Rigidbody2D>();

		// Get list of gameObjects that create gravity
		foreach (GameObject other in GameObject.FindGameObjectsWithTag("Gravity"))
		{
			if (!(other == gameObject))
			{
				allObjects.Add(other);
			}
		}

		// Get gravity
		G = GameObject.Find("God").GetComponent<Universal_Laws>().gravityConstant;

		// Calculate orbital velocity
		float m1, r;

		foreach (GameObject planet in allObjects)
		{
			// Get mass of planet (m2)
			m1 = planet.GetComponent<Rigidbody2D>().mass;

			// Get distance (r)
			r = Vector2.Distance(transform.position, planet.transform.position);
			
			orbitalVelocity *= Mathf.Sqrt(G*m1/r);
		}

		myRB.velocity = orbitalVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	// Called each pyshics frame
	void FixedUpdate()
	{
		float m1, m2, r;

		m2 = myRB.mass;
		foreach (GameObject planet in allObjects)
		{
			// Get mass of planet (m2)
			m1 = planet.GetComponent<Rigidbody2D>().mass;

			// Get distance (r)
			r = Vector2.Distance(transform.position, planet.transform.position);

			// Calculate gravitational forces on object
			// F = G*m1*m2/r^2
			force = G*m1*m2/(r*r);

			// Add gravitational force to object
			myRB.AddForce((planet.transform.position - transform.position) * force);
		}
	}
}
