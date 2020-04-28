using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Vector3 mousePosition;
    public Vector3 laserRotation;
    public float rotZ;

    [Range(0, 5)]
    public float fireRate = 0.025f;
    [Range(0, 100)]
    public float speed = .5f;
    private float nextFire;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        laserRotation = mousePosition - transform.position;
        laserRotation.Normalize();
        rotZ = Mathf.Atan2(laserRotation.y, laserRotation.x) * Mathf.Rad2Deg;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }


    }

    void Fire()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject shot = AmmoPool.Instance.GetPooledShot();

            if (shot != null)
            {
                shot.transform.position = transform.position;
                shot.transform.rotation = Quaternion.Euler(0f, 0f, rotZ - 90);
                shot.SetActive(true);
            }

        }
    }
}
