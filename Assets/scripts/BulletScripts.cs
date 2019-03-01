using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScripts : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 1);

        if (this.transform.position.y > 10)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.tag.Equals("Player"))
        {
            if (other.transform.parent != null)
            {
                other.transform.parent.GetComponent<EnemyControll>().UnitKilled(other.transform.position.x);
            }
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}