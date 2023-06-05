using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controltemp : MonoBehaviour
{
    public bool actionQuery = false; //false is not currently doing action
    public double actionTimer = 10; //ten frames seems fine
    bool monster = false;
    bool monsterTurning = false;
    int xMoveSpeed = 2;
    int yMoveSpeed = 2;
    int currentFallVelocity = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float directionX = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2(directionX * xMoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        if (actionQuery == false)
        {
            if (monster == false)
            {
                xMoveSpeed = 2;
                yMoveSpeed = 0;
            }
            if (monster == true)
            {
                xMoveSpeed = 5;
                yMoveSpeed = 10;
            }
        }
        else
        {
            xMoveSpeed = 0;
            yMoveSpeed = 0;
        }
        if (Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, yMoveSpeed);
        }
        if (Input.GetKey("c") && actionQuery == false)
        {
            actionTimer = -20.0;
            if (monster == false && actionQuery == false)
            {
                xMoveSpeed = 0;
                yMoveSpeed = 0;
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
                actionQuery = true;
                monster = true;
                monsterTurning = true;
                print("yoooo");
            }
            if (monster == true && actionQuery == false)
            {
                xMoveSpeed = 0;
                yMoveSpeed = 0;
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
                actionQuery = true;
                monster = false;
                print("awwww");
            }
        }
        if (actionTimer <= 10.0)
        {
            actionTimer = actionTimer + 0.2;
        }
        if (actionTimer >= 10.0)
        {
            actionQuery = false;
        }
        if (actionQuery == true && actionTimer < 10.0 && monsterTurning == true && monster == true)
        {
            GetComponent<Animator>().SetBool("monster", true);
            GetComponent<Animator>().SetBool("monsterQuery", true);
        }
        else if (actionQuery == true && actionTimer < 10.0 && monsterTurning == true && monster == false)
        {
            GetComponent<Animator>().SetBool("monster", false);
            GetComponent<Animator>().SetBool("monsterQuery", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("monsterQuery", false);
        }
    }
}