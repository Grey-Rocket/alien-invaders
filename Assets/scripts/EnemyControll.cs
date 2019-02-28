using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyControll : MonoBehaviour
{

    public List<int> positions;

    public Object enemy;
    public Object bigBullet;

    public int[,] arrayOfUnits;
    public int stillAlive;

    // Start is called before the first frame update
    void Start()
    {
        //first one is at -12.5f,7
        float x = -12.5f;
        float y = 7f;

        arrayOfUnits = new int[11,3];

        for (int k = 0; k < 3; k++)
        {
            for (int i = 0; i < 11; i++) {
                Instantiate(enemy, new Vector3(x, y), Quaternion.identity);
                x += 2.5f;
                arrayOfUnits[i,k] = 1;
            }
            x = -12.5f;
            y -= 2;
        }

        positions = new List<int>();
        stillAlive = 12;
        for (int i = 0; i < 11; i++)
        {
            positions.Add(i);
        }

        InvokeRepeating("Attack",0f, 1f);
        /*
        for (int k = 2; k >= 0; k--)
        {
            for (int i = 0; i < 11; i++)
            {
                Debug.Log("k = " + k + " i = " + i + " vrednost = " + arrayOfUnits[i,k]);
            }
        }
        */
    }

    void Attack()
    {
        Debug.Log((int)(Random.Range(0,stillAlive)));
        Instantiate(bigBullet, new Vector3(1f, 1f), Quaternion.identity);
        stillAlive = 1;
    }

    private void Update()
    {
        if (stillAlive <= 1)
        {
            CancelInvoke("Attack");
        }
    }
}
