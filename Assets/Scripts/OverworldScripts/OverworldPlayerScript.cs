using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverworldPlayerScript : MonoBehaviour
{

    public float movSpeed = 1f;
    public int encounterRate;
    int timer = 0;
    public int gracePeriod;
    bool isMoving;
    private Vector3 target;
    public Transform player;
    public Transform upper;
    public Transform lower;
    public Transform left;
    public Transform right;

    void Start()
    {
        isMoving = false;
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1)){
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
            isMoving = true;
        }
        timer+=1;
        if(isMoving){
            float encounter = Random.Range(1, 100);
            if(timer*Time.deltaTime > gracePeriod && encounter <= encounterRate){
                Debug.Log("An encounter would have triggered here.");
                SceneManager.LoadScene("BattleScene");
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, target, movSpeed * Time.deltaTime);
        isMoving = false;
    }
}
