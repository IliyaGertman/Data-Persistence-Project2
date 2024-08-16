using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Button startGame;

    // Start is called before the first frame update

   
   public void BeginGame()
    {
        NameHolder.Instance.SetPlayerName();
        SceneManager.LoadScene(1);
        
    }
}
