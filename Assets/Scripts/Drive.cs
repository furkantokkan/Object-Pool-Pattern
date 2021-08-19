using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Drive : MonoBehaviour
{
    public float speed = 10.0f;
    public GameObject bullet;
    public Slider healthbar;
    public float health = 100f;
    void Update()
    {
        float translation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        transform.Translate(translation, 0, 0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Pool.instance.Get("Bullet");
            if (bullet != null)
            {
                Vector3 pos = transform.position;
                pos.y = -1.72f;
                bullet.transform.position = pos;
                bullet.SetActive(true);
            }
        }
        Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position) +
        new Vector3(2, -40, 0);
        healthbar.transform.position = screenPos;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            health -= 5;
            healthbar.value = health;
            if (health <= 0)
            {
                Destroy(healthbar);
                Destroy(this, 0.1f);
            }
        }
    }
}