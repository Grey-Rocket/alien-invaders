using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControll : MonoBehaviour
{

    public Object enemy;

    // Start is called before the first frame update
    void Start()
    {
        //first one is at -12.5f,7
        float x = -12.5f;
        float y = 7f;

        for (int k = 0; k < 3; k++)
        {
            for (int i = 0; i < 11; i++) {
                Instantiate(enemy, new Vector3(x, y), Quaternion.identity);
                x += 2.5f;
            }
            x = -12.5f;
            y -= 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
