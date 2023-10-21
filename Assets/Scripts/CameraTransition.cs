using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    public Camera[] roomCameras; // An array of cameras associated with different rooms
    public Camera mainCam;
    private int activeCam = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(mainCam.enabled) {
                mainCam.enabled = false;
            }

            // Get the room's index based on the collider's name
            int roomIndex = int.Parse(gameObject.name);
            
            //int.TryParse(gameObject.name, out roomIndex);
            Debug.Log("Entered room: " + roomIndex);

            // Ensure the room index is within a valid range
            if (roomIndex >= 0 && roomIndex < roomCameras.Length)
            {
                // Deactivate all cameras
                foreach (Camera camera in roomCameras)
                {
                    camera.gameObject.SetActive(false);
                }

                // Activate the camera associated with the current room
                if(activeCam == roomIndex) { 
                    //Exiting room
                    roomCameras[0].gameObject.SetActive(true);
                    activeCam = 0;
                } else { 
                    //Entering new room
                    roomCameras[roomIndex].gameObject.SetActive(true);
                    activeCam = roomIndex;
                }
                
            }
        }
    }
}
