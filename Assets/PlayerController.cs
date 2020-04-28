using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 15;
    public Rigidbody2D rb;
    public Vector3 tempVect;
    public bool sprinting;
    // Start is called before the first frame update
    void Start()
    {
        sprinting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            sprinting = !sprinting;
        }
            if (sprinting == true)
            {
                //Debug.Log("sprinting");
                float h = Input.GetAxis("Horizontal");
                float v = Input.GetAxis("Vertical");

                tempVect = new Vector3(h, v, 0);
                tempVect = tempVect.normalized * speed * Time.deltaTime;
                rb.MovePosition(rb.transform.position + tempVect);
            }
            else
            {
                //Debug.Log("walking");
                float h = Input.GetAxis("Horizontal");
                float v = Input.GetAxis("Vertical");

                tempVect = new Vector3(h, v, 0);
                tempVect = tempVect.normalized * speed / 2 * Time.deltaTime;
                rb.MovePosition(rb.transform.position + tempVect);
            }
    }
}
