using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMenuScript : MonoBehaviour
{
    public Player player;
    public GameObject itemOptionPrefab;
    public GameObject itemPanel;

    // Start is called before the first frame update
    void Start()
    {
        populateItems();
    }

    public void populateItems(){
        foreach(Item i in player.items){
            GameObject option;
            option = Instantiate(itemOptionPrefab, itemPanel.transform, true);
            option.name= i.name;
        }
    }

}
