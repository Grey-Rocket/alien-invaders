using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScripts : MonoBehaviour
{
    public int owner;
    //1 == player, 2 == enemy

    // Start is called before the first frame update
    void Start()
    {
        owner = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (owner == 1)
        {
            this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 1);
        }

        if (this.transform.position.y > 10)
        {
            Destroy(this.gameObject);
        }
    }
}
