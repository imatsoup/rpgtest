using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject inventoryDisplay;
    public void inventory(){
        inventoryDisplay.SetActive(true);
    }
    public void back(){
        pauseUI.SetActive(false);
        if(inventoryDisplay.activeInHierarchy){
            inventoryDisplay.SetActive(false);
        }
    }
}
