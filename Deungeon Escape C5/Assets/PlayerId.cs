using System.Collections;
using System.Collections.Generic;
using Proyecto26;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerId : MonoBehaviour
{
    public Text idText;
    public InputField nameText;

    private System.Random random = new System.Random();

    public static int playerID;
    public static string playerName;


    // Start is called before the first frame update
    void Start()
    {
        playerID = random.Next(0, 101);
        idText.text = "ID: " + playerID;
    }

    public void OnSubmit()
    {
        playerName = nameText.text;
        PostToDatabase();
    }

    private void PostToDatabase()
    {
        User user = new User();
        RestClient.Post(url: "https://dungeon-escape-88446.firebaseio.com/.json", user);
    }
    
}
