using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class EnemyControll : MonoBehaviour
{
    public int[] positions;

    public Text endText;

    public Object enemy;
    public Object bigBullet;

    public int[] arrayOfUnits;
    public int stillAlive;

    float fXPosition;

    // Start is called before the first frame update
    void Start()
    {
        //first one is at -12.5f,7
        fXPosition = -12.5f;
        float y = 7f;

        arrayOfUnits = new int[11];

        //pointers to positions
        positions = new int[11];
        stillAlive = 11;

        //better way of doing this would be to switch these two for
        //loops, but I don't want to bother with tuning the spawn positions
        for (int k = 0; k < 3; k++)
        {
            for (int i = 0; i < 11; i++)
            {
                //spawns a prefab
                GameObject mySon = (GameObject)Instantiate(enemy, new Vector3(fXPosition, y), Quaternion.identity);
                mySon.transform.parent = this.transform;

                fXPosition += 2.5f;

                //just to track how many enemies are still in columns
                arrayOfUnits[i] = 3;

                //
                positions[i] = i;
            }
            fXPosition = -12.5f;
            y -= 2;
        }

        //repeatedly calls a function every 0.5f seconds, 0f seconds from the call
        InvokeRepeating("Attack", 0f, 0.2f);
    }

    void Attack()
    {
        int bulletX = positions[(int)(Random.Range(0, stillAlive))];
        //Debug.Log(bulletX);

        Instantiate(bigBullet, new Vector3(fXPosition + 2.5f * bulletX, 7.5f-2*arrayOfUnits[bulletX]), Quaternion.identity);
    }

    private void Update()
    {
        if (stillAlive < 1)
        {
            End();
        }
    }

    public void UnitKilled(float objPosition)
    {
        int index = (int)((objPosition - fXPosition) / 2.5f);

        arrayOfUnits[index]--;

        if (arrayOfUnits[index] == 0)
        {
            //changes position
            for (int i = 0; i < stillAlive; i++)
            {
                if (positions[i] == index)
                {
                    positions[i] = positions[stillAlive-1];
                    stillAlive--;

                    if (stillAlive == 1)
                    {
                        CancelInvoke("Attack");
                        InvokeRepeating("Attack", 0f, 0.5f);
                    }
                    break;
                }
            }
        }
    }

    public void End()
    {
        //stops function
        CancelInvoke("Attack");
        if (stillAlive < 1)
        {
            endText.text = "YOU WIN";
        }
        else
        {
            endText.text = "YOU LOOSE";
        }
        endText.gameObject.SetActive(true);
    }
}