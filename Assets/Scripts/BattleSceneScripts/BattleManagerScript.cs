using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleManagerScript : MonoBehaviour
{
    bool passTurn = false;
    public Player player;
    public Enemy enemy;
    public Slider playerHealthUI;
    public Slider enemyHealthUI;
    public GameObject battleMenu;
    public GameObject fightMenu;
    public GameObject victory;
    public GameObject defeat;

    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        //TODO: This is placeholder. Ideally player hp will be constant,
        //enemy HP will be set based on the encounter. For testing purposes, this is fine.
        player.priority = true;
        enemy.HP = 20;
        playerHealthUI.value = player.HP;
        enemyHealthUI.maxValue = enemy.HP;
    }

    // Update is called once per frame
    void Update()
    {

        //If player has no remaining HP, end the game.
        if(player.HP <= 0){
            battleMenu.SetActive(false);
            defeat.SetActive(true);
        }

        //If the fightMenu is gone and the player no longer has priority, the enemy takes their turn.
        //If the enemy has no hp remaining, end the encounter.
        if(fightMenu.activeInHierarchy == false){  
            if(enemy.HP > 0){
                if(player.priority == false){
                    enemyTurn();
                    player.priority=true;
                }   
            }
            //TODO: Should change scene back to the overworld.
            else{
                victory.SetActive(true);
                battleMenu.SetActive(false);
                transition(100);
            }
        }
        //If the player has moved, set the enemy's health bar and disable the fightMenu
        if(player.priority == false){
            fightMenu.SetActive(false);
            moveSlider(enemyHealthUI, enemy.HP);
        }
        
    }
    void enemyTurn(){
        player.takeDamage(enemy.ATK);
        moveSlider(playerHealthUI, player.HP);
        passTurn = false;
        battleMenu.SetActive(true);
        Debug.Log(player.HP);

    }
    public void playerAttacking(){
        battleMenu.SetActive(false);
        fightMenu.SetActive(true);
    }   
    public void back(){
        fightMenu.SetActive(false);
        battleMenu.SetActive(true);
    }
    public void run(){
        float escape = Random.Range(1, 100);
        if(escape < 51){
            transition(1);
        }
        else{
            Debug.Log("Escape failed");
            player.priority = false;
        }
    }

    void moveSlider(Slider slider, int currentHP){
        slider.value = currentHP;
    }
    void transition(float seconds){
        // while(timer < seconds){
        //     Debug.Log(timer);
        //     timer+= Time.deltaTime;
        // }
        SceneManager.LoadScene("OverworldScene");

    }
    
}
