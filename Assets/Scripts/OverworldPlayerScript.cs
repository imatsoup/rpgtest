using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldPlayerScript : MonoBehaviour
{

    public float movSpeed = 1f;
    public int encounterRate;
    int timer = 0;
    public int gracePeriod;
    bool isMoving;
    public Transform player;
    public Transform upper;
    public Transform lower;
    public Transform left;
    public Transform right;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer+=1;
        if(Input.GetKey(KeyCode.W) && (player.position.y + 0.5) < upper.position.y){
            transform.Translate(Vector3.up * movSpeed * Time.deltaTime);
            isMoving = true;
        }
        if(Input.GetKey(KeyCode.A) && (player.position.x - 0.5) > left.position.x){
            transform.Translate(Vector3.left * movSpeed * Time.deltaTime);
            isMoving = true;
        } 
        if(Input.GetKey(KeyCode.S) && (player.position.y - 0.5) > lower.position.y){
            transform.Translate(Vector3.down * movSpeed * Time.deltaTime);
            isMoving = true;
        } 
        if(Input.GetKey(KeyCode.D) && (player.position.x + 0.5) < right.position.x){
            transform.Translate(Vector3.right * movSpeed * Time.deltaTime);
            isMoving = true;
        }
        if(isMoving){
            float encounter = Random.Range(1, 100);
            if(timer*Time.deltaTime > gracePeriod && encounter <= encounterRate){
                Debug.Log("An encounter would have triggered here.");
            }
        }
        isMoving = false;
    }
}
