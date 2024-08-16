using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class NameHolder : MonoBehaviour
{
    public static NameHolder Instance;
    public InputField playerName;
    public string currentPlayerName;
    private void Awake()
    {

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    public void SetPlayerName()

    {

        currentPlayerName = playerName.text;


    }

    public string GetPlayerName()

    {

        return currentPlayerName;

    }




}
