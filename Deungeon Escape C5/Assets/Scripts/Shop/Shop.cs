using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shop : MonoBehaviour
{
    public int currentSelectedItem;
    public int currentItemCost;
    private Player _player;

    public GameObject shopPanel;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
             _player = other.GetComponent<Player>();
            
            if (_player != null)
            {
                UIManager.instance.OpenShop(_player.diamond);
            }
            shopPanel.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            shopPanel.SetActive(false);
        }
    }

    public void SelectItem(int item)
    {
        Debug.Log("SelectItem()" + item);

        switch(item)
        {
            case 0:
                UIManager.instance.UpdateShopSelection(110);
                currentSelectedItem = 0;
                currentItemCost = 200;
                break;

            case 1:
                UIManager.instance.UpdateShopSelection(0);
                currentSelectedItem = 1;
                currentItemCost = 400;
                break;

            case 2:
                UIManager.instance.UpdateShopSelection(-90);
                currentSelectedItem = 2;
                currentItemCost = 100;
                break;
        }
    }
    
    public void ButItem()
    {
        
        if(_player.diamond >= currentItemCost)
        {
            if(_player.diamond >= currentItemCost)
            {
                if(currentSelectedItem == 2)
                {
                    GameManager.Instance.HasKeyToCastle = true;
                }
            }
            _player.diamond -= currentItemCost;
            Debug.Log("Purchased" + currentSelectedItem);
            Debug.Log("Remaining Gems" + _player.diamond);
            shopPanel.SetActive(false);
        }
        else
        {
            Debug.Log("You donot have enough gems");
            shopPanel.SetActive(false);
        }
    }
}
