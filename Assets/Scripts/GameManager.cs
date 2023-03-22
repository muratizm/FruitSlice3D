using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int goalCount;
    public int tourLimit;
    private int tourCount;
    public Score scoreObject;
    bool gameHasEnded = false;
    public GameObject endOfLevelUI;
    public GameObject[] fruits;
    public GameObject finalPosition;
     
     private void Start() {
         scoreObject = FindObjectOfType<Score>();
         goalCount = 0;
         tourCount = 0;
     }
    public void CompleteLevel(){
        endOfLevelUI.SetActive(true);
    }

    public void EndGame(int finalScore){
        if(gameHasEnded == false){
            gameHasEnded = true;
            CompleteLevel();
        }
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public int getCount(){
        return goalCount;
    }

    public void setCount(int value){
        goalCount = value;
    }

    public int getTourCount(){
        return tourCount;
    }

    public void setTourCount(int value){
        tourCount = value;
    }

    public void teleport(string name){
        for(int i = 0 ; i < fruits.Length; i++){
            if(fruits[i].name == name){
                Debug.Log("OLDUUUUUUU");
                Instantiate(fruits[i], finalPosition.transform, false);
            }
        }

    }
}
