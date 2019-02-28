using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - 0.15f);

        if (this.transform.position.y < -10)
        { 
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
