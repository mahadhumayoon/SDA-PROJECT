using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("UIMAnager has not been assigned yet");
            }
            return _instance;
        }
    }

    public Text playerGemsCountText;
    public Image selectionImg;
    public Text gemCountText;
    public Image[] healthBars;
    public void Awake()
    {
        _instance = this;
    }
    public void UpdateShopSelection(int yPos)
    {
        selectionImg.rectTransform.anchoredPosition= new Vector2(selectionImg.rectTransform.anchoredPosition.x, yPos);
    }

    public void OpenShop(int gemsCount)
    {
        playerGemsCountText.text = ""+ gemsCount + "G";
    }
   
    public void UpdateGemCount(int count)
    {
        gemCountText.text ="" + count;
    }

    public void UpdateLives(int LivesRemaining)
    { 
      for(int i = 0; i<=LivesRemaining; i++)
        {
            if(i == LivesRemaining)
            {
                healthBars[i].enabled = false;
            }
        }
    }
}
