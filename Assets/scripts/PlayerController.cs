using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//to das ce hoces vidt v inspectorju ta objkekt kot spremenljivko
//[System.Serializable]

public class PlayerController : MonoBehaviour
{

    public Image[] lifeIcons;
    int lives;

    public GameObject enemySquad;
    public Object bullet;
    // Start is called before the first frame update
    void Start()
    {
        lives = lifeIcons.Length;
        this.transform.position = new Vector2(-0.5f , -7.5f);
    }

    // Update is called once per frame
    void Update()
    {
        int movement = (int)Input.GetAxisRaw("Horizontal");


        if (movement == 1 && this.transform.position.x < 13)
        {
            this.transform.position = new Vector2(this.transform.position.x + 0.2f, this.transform.position.y);
        }

        else if (movement == -1 && this.transform.position.x > -13)
        {
            this.transform.position = new Vector2(this.transform.position.x - 0.2f, this.transform.position.y);
        }

        if (Input.GetButtonDown("Jump"))
        {
            Instantiate(bullet, new Vector3(this.transform.position.x -0.02f,-7), Quaternion.identity);
        }
    }

    public void IsHit()
    { 

        lives--;
        if (lives <= 0)
        {
            Destroy(lifeIcons[lives].gameObject);
            enemySquad.GetComponent<EnemyControll>().End();
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(lifeIcons[lives].gameObject);
        }
    }
}
