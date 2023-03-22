using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    
    private Inventory inventory;
    public GameObject itemButton;
    public GameObject tick;
    private GoalCreater goalCreater;
    private Score scoreObject;
    private GameManager gameManager;
    private Knife knife;

    // Start is called before the first frame update
    void Start()
    {
        knife = FindObjectOfType<Knife>();
        scoreObject = FindObjectOfType<Score>();
        inventory = GameObject.FindGameObjectWithTag("Knife").GetComponent<Inventory>();
        goalCreater = FindObjectOfType<GoalCreater>();
        gameManager = FindObjectOfType<GameManager>();
    }

        private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == ("Knife")){
            string[] goalNames = goalCreater.getGoalNames();
            if(goalNames[gameManager.getCount()]==itemButton.name){
                Instantiate(tick, inventory.slots[gameManager.getCount()].transform, false);
                gameManager.teleport(itemButton.name);
                knife.setCount(knife.getCount()+1);
                scoreObject.changeScore(10); 
                gameManager.setCount(gameManager.getCount()+1);
                if(gameManager.getCount() == goalNames.Length){
                    gameManager.setTourCount(gameManager.getTourCount()+1);
                    gameManager.setCount(0);
                    goalCreater.Delete();
                    goalCreater.Create();
                    for (int k = 0; k < inventory.slots.Length; k++)
                        {
                            Destroy(inventory.slots[k].transform.GetChild(0).gameObject);
                        }
                    if(gameManager.getTourCount() == gameManager.tourLimit){
                        gameManager.EndGame(scoreObject.score);
                    }
                }
            }
            else{
                scoreObject.changeScore(-2); 
                knife.setCount(0);
            }
            }
            
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Knife"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (!inventory.isFull[i])
                {
                    inventory.isFull[i] = true;
                    //Debug.Log(itemButton.name);
                    inventory.setSlotNames(i, itemButton.name);
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    scoreObject.changeScore(10); 
                    // burda her meyve aldıgında puan ekliyorım


                    if (i == inventory.slots.Length-1)
                    {
                        string[] goalNames = goalCreater.getGoalNames();
                        string[] pickupNames = inventory.getSlotNames();
                        
                        if (checkEquality(goalNames, pickupNames))
                        {
                            scoreObject.changeScore(50);
                        }
                        else
                        {
                            scoreObject.changeScore(-20);
                        }
                        
                        // bölüm sonu kodu

                        gameManager.EndGame(scoreObject.score);
                        inventory.isFull = new bool[] { false, false, false, false, false, false};
                        inventory.resetNames();
                        goalCreater.Delete();
                        //goalCreater.Create();
                        for (int k = 0; k < inventory.slots.Length; k++)
                        {
                            Destroy(inventory.slots[k].transform.GetChild(0).gameObject);
                        }
                        
                        }
                    break;

                }
            }
        }
    }
    */


    /*
    public static bool checkEquality<T>(T[] first, T[] second)
    {
        return Enumerable.SequenceEqual(first, second);
    }
    
    */
}