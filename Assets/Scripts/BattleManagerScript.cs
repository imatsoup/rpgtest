using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManagerScript : MonoBehaviour
{
    bool passTurn = false;
    bool selectAttack = false;
    public Player player;
    public Enemy enemy;
    public Slider playerHealthUI;
    public Slider enemyHealthUI;
    public GameObject battleMenu;
    public GameObject fightMenu;
    public GameObject victory;

    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        player.HP = 100;
        player.priority = true;
        enemy.HP = 50;
        enemyHealthUI.maxValue = enemy.HP;
    }

    // Update is called once per frame
    void Update()
    {
        if(fightMenu.activeInHierarchy == false){  
            if(enemy.HP > 0){

                    if(passTurn == true){
                        enemyTurn();
                        player.priority=true;
                    }
                
            }
            else{
                victory.SetActive(true);
                battleMenu.SetActive(false);
            }
        }
        
    }
    void enemyTurn(){
        player.takeDamage(enemy.ATK);
        moveSlider(playerHealthUI, enemy.ATK);
        passTurn = false;
        battleMenu.SetActive(true);
        Debug.Log(player.HP);

    }
    public void playerAttacking(){
        selectAttack = true;
        battleMenu.SetActive(false);
        fightMenu.SetActive(true);
    }   
    public void useAttack(int attackID){
        enemy.HP = enemy.HP - player.attacks[attackID].damage;
        moveSlider(enemyHealthUI, player.attacks[attackID].damage);
        fightMenu.SetActive(false);
        passTurn = true;
        selectAttack = false;
    }
    public void firstAction(){
        if(player.attacks[0] != null){
            enemy.HP = enemy.HP - player.attacks[0].damage;
            moveSlider(enemyHealthUI, player.attacks[0].damage);
            fightMenu.SetActive(false);
            passTurn = true;
            selectAttack = false;

        }
    }
    public void secondAction(){
        if(player.attacks[1] != null){
            enemy.HP = enemy.HP - player.attacks[1].damage;
            moveSlider(enemyHealthUI, player.attacks[1].damage);
            fightMenu.SetActive(false);
            passTurn = true;
            selectAttack = false;

        }
    }
    public void thirdAciton(){
        if(player.attacks[2] != null){
            enemy.HP = enemy.HP - player.attacks[2].damage;
            moveSlider(enemyHealthUI, player.attacks[2].damage);
            fightMenu.SetActive(false);
            passTurn = true;
            selectAttack = false;

        }
    }
    public void back(){
        fightMenu.SetActive(false);
        battleMenu.SetActive(true);
        selectAttack = false;

    }
    void moveSlider(Slider slider, int atkDmg){
        slider.value = slider.value - atkDmg;
    }
    public void passEnemyTurn(){
        back();
        enemyTurn();
    }
    
}
