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
    public Button openItemMenu;
    public GameObject battleMenu;
    public GameObject fightMenu;
    public GameObject itemMenu;
    public GameObject victory;
    public GameObject defeat;

    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        //TODO: This is placeholder. Ideally player hp will be constant,
        //enemy HP will be set based on the encounter. For testing purposes, this is fine.
        player.priority = true;
        player.HP = 100;
        enemy.HP = 20;
        enemy.MaxHP = 20;
        playerHealthUI.maxValue = player.MaxHP;
        playerHealthUI.value = player.HP;
        enemyHealthUI.maxValue = enemy.HP;
        checkEmptyInventory();
    }

    // Update is called once per frame
    void Update()
    {

        //If player has no remaining HP, end the game.
        if(player.HP <= 0){
            battleMenu.SetActive(false);
            defeat.SetActive(true);
            StartCoroutine("transitionToMainMenu", 3.5f);
        }

        //If the fightMenu is gone and the player no longer has priority, the enemy takes their turn.
        //If the enemy has no hp remaining, end the encounter.
        if(fightMenu.activeInHierarchy == false && itemMenu.activeInHierarchy == false){  
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
                StartCoroutine("transitionToOverworld", 3.5f);
            }
        }
        //If the player has moved, set the enemy's health bar and disable the fightMenu or itemMenu
        if(player.priority == false){
            Debug.Log(itemMenu.activeInHierarchy);
            fightMenu.SetActive(false);
            itemMenu.SetActive(false);
            checkEmptyInventory();
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
    public void item(){
        battleMenu.SetActive(false);
        itemMenu.SetActive(true);
    }
    public void itemBack(){
        itemMenu.SetActive(false);
        battleMenu.SetActive(true);
    }   
    public void back(){
        fightMenu.SetActive(false);
        battleMenu.SetActive(true);
    }
    public void run(){
        float escape = Random.Range(1, 100);
        if(escape < 51){
            StartCoroutine("transitionToOverworld", 1);
        }
        else{
            Debug.Log("Escape failed");
            player.priority = false;
        }
    }

    void moveSlider(Slider slider, int currentHP){
        slider.value = currentHP;
    }
    IEnumerator transitionToOverworld(float seconds){
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("OverworldScene");
    }
    IEnumerator transitionToMainMenu(float seconds){
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("MainMenu");
    }
    void checkEmptyInventory(){
        Debug.Log(player.items.Length);
        if(player.items.Length < 1){
            openItemMenu.interactable = false;
        }
    }
    
}
