using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class DifficultyControl : MonoBehaviour
{

    private Button button;
    private GameManager gameManager;

    public int difficult;


    // Start is called before the first frame update
    void Start()
    {

        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        button.onClick.AddListener(SetDifficult);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDifficult()
    {
        gameManager.StartGame(difficult);
        //Debug.Log(gameObject.name + " was clicked");

    }
}
