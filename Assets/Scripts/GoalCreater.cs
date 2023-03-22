using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCreater : MonoBehaviour
{
    public GameObject[] foodSlots;
    private string[] goalNames;
    private Inventory inventory;


    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Knife").GetComponent<Inventory>();
        goalNames = new string[inventory.goalSlots.Length];
        Create();
    }

    public void Create()
    {


        System.Random rnd = new System.Random();
        for (int i = 0; i < inventory.goalSlots.Length; i++)
        {
            int numb = rnd.Next(0, foodSlots.Length);
            GameObject itemButton = foodSlots[numb];
            goalNames[i] = foodSlots[numb].name;
            Instantiate(itemButton, inventory.goalSlots[i].transform, false);

        }
    }

    public void Delete()
    {
        for (int k = 0; k < inventory.slots.Length; k++)
        {
            Destroy(inventory.goalSlots[k].transform.GetChild(0).gameObject);
        }
    }

    public string[] getGoalNames()
    {
        return goalNames;
    }

}