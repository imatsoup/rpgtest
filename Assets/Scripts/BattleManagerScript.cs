using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        player.HP = 100;
        player.priority = true;
        enemy.HP = 50;
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
        //If the player has moved, set the enemy's health bart and disable the fightMenu
        if(player.priority == false){
            fightMenu.SetActive(false);
            moveSlider(enemyHealthUI, enemy.HP);
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
            }
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
    void moveSlider(Slider slider, int currentHP){
        slider.value = currentHP;
    }
    
}
