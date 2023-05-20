using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resurs_Ui : MonoBehaviour
{
    ManagerOfResources resManager;

    public Text Food;
    public Text Wood;
    public Text Stone;
    public Text Iron;
    public Text Coal;
    public Text Gold;

    void Start()     
    {
        resManager = FindObjectOfType<ManagerOfResources>();
    }
    
    void Update() 
    {
        Food.text = resManager.Food.ToString();
        Wood.text = resManager.Wood.ToString();
        Stone.text = resManager.Stone.ToString();
        Iron.text = resManager.Iron.ToString();
        Coal.text = resManager.Coal.ToString();
        Gold.text = resManager.Gold.ToString();
    }
}
