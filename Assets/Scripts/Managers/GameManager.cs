using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    #region singleton
    private static GameManager instance;

    // Optional: Add public variables or properties for game-related data

    private void Awake()
    {
        // Ensure only one instance of the GameManager exists
        if (instance == null)
        {
            // Set the instance to this object if it doesn't exist
            instance = this;
        }
        else
        {
            // Destroy any additional instances that are created
            Destroy(gameObject);
        }
    }

    // Optional: Add public methods or functions for game-related functionality

    public static GameManager Instance
    {
        get { return instance; }
    }


    #endregion


    private void OnEnable()
    {
        //DataCollector.Instance.SaveDataEvent += SaveData;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
    public void Exit()
    {
        Application.Quit();
    }

    void SaveData()
    {
       
    }

}


    


