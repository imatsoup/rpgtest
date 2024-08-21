using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldUIScript : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject inventoryDisplay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("escape")) { 
            if(pauseUI.activeInHierarchy == true){
                if(inventoryDisplay.activeInHierarchy == true){
                    inventoryDisplay.SetActive(false);
                }
                else{
                    pauseUI.SetActive(false);
                }
            }
            else{
                pauseUI.SetActive(true);
            }
            
        }
    }
}
