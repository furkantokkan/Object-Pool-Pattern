using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public Vector3 velocity;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            collision.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
    void Update()
    {
        this.transform.Translate(velocity);
    }
}
