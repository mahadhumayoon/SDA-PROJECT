using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class User 
{
    public  string userName;
    public  int userId;

    public User()
    {
        userName = PlayerId.playerName;
        userId = PlayerId.playerID;
    }
    
}
