using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : MonoBehaviour
{
    [Range(0, 10)]
    public float shotLife = 10f;

    public float shotSpeed = 10f;

    public Vector3 mousePosition;
    public Vector3 laserRotation;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void OnEnable()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        laserRotation = mousePosition - transform.position;
        laserRotation.Normalize();

        rb.AddForce(laserRotation * shotSpeed);

        Invoke("ShotDelay", shotLife);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(laserRotation * shotSpeed);
    }

    void ShotDelay()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemies"))
        {
            gameObject.SetActive(false);
        }
    }
}
