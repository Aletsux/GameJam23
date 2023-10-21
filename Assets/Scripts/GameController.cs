using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    //roomNr: 0 = hallway, 1 = Kitchen, 2 = Bedroom, 3 = Livingroom
    private int currentRoom = 0;
    //public RatMovement ratMov;
    public GameObject[] rats;   
    private bool awake = false;

    public int getCurrentRoom() {
        return currentRoom;
    }

    public void setCurrentRoom(int value) {
        currentRoom = value;
    }
    void Start()
    {
        
        foreach(GameObject rat in rats) {
            if(rat == null) {
                Debug.Log("Rat = null");
            } 
            rat.GetComponent<RatMovement>().enabled = false;
        }
    }

    // Update is called once per frame
    async void Update()
    {
        if(currentRoom == 1) {
            awake = true;
        } else {
            awake = false;
        }

        if(awake) {
            wakeRats();
            return;
        }
    }

    private void wakeRats() {
        foreach(GameObject rat in rats) {
            rat.GetComponent<RatMovement>().enabled = true;
        }
    }
}
