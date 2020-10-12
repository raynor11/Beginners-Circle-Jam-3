using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Universal_Laws : MonoBehaviour
{
	public float gravityConstant = 10;
	public int num = 3;
	public GameObject planet;

    // Start is called before the first frame update
    void Start()
    {
		for (int i = 0; i < num; i++)
		{
			GameObject clone;
			clone = Instantiate(planet, (Vector3)(new Vector2(0.0f, 0.0f)), Quaternion.identity);

			clone.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(Vector2.up * 1);
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
