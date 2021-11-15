using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{


    [SerializeField] public float DoorSpeed = 0; // The speed with which the doors open and close
    [SerializeField] int CloseAfterSeconds = 2;  // The Doors close automatically after [CloseAfterSeconds] seconds
    [SerializeField] GameObject LeftDoor = default;
    [SerializeField] GameObject RightDoor = default;
    [SerializeField] float MoveDistance = 1.5f;  // The distance the doors move when opened.

    AudioSource doorSound;
    
    bool isClosed = true;
    bool isMoving = false;

    float targetPositionClosedRight = 0f;
    float targetPositionOpenedRight = 0f;
    float targetPositionClosedLeft = 0f;
    float targetPositionOpenedLeft = 0f;
    


    void Start()
    {

        SetTargetPositions();

        // get audiosource
        doorSound = GetComponent<AudioSource>();

    }

    
    void Update()
    {
       
           HandleDoorMovement(); 
      
        
    }

    private void SetTargetPositions()
    {
        // set target positions (position of doors when open and closed)
        targetPositionClosedRight = RightDoor.transform.localPosition.x;
        targetPositionOpenedRight = targetPositionClosedRight + MoveDistance;
        targetPositionClosedLeft = LeftDoor.transform.localPosition.x;
        targetPositionOpenedLeft = targetPositionClosedLeft - MoveDistance;

    }

    private void OnTriggerEnter(Collider other)
    {
        OpenDoor(); // Open the door
        StartCoroutine(CloseDoor(CloseAfterSeconds)); // and close it 

    }


    public void HandleDoorMovement()
    {
        if (isMoving) { 

            if (isClosed)
            {
                // door needs to open
                if (LeftDoor.transform.localPosition.x > targetPositionOpenedLeft)
                {
                    Vector3 newPosition = new Vector3(LeftDoor.transform.localPosition.x - DoorSpeed * Time.deltaTime,
                                                    LeftDoor.transform.localPosition.y,
                                                    LeftDoor.transform.localPosition.z);

                    LeftDoor.transform.localPosition = newPosition;
                }

                if (RightDoor.transform.localPosition.x < targetPositionOpenedRight)
                {
                    Vector3 newPosition = new Vector3(RightDoor.transform.localPosition.x + DoorSpeed * Time.deltaTime,
                                                    RightDoor.transform.localPosition.y,
                                                    RightDoor.transform.localPosition.z);

                    RightDoor.transform.localPosition = newPosition;
                }

                // door is opened
                if (LeftDoor.transform.localPosition.x <= targetPositionOpenedLeft)
                {
                    Vector3 newPosition = new Vector3(targetPositionOpenedLeft, LeftDoor.transform.localPosition.y, LeftDoor.transform.localPosition.z);
                    LeftDoor.transform.localPosition = newPosition;
                    isClosed = false;
                    isMoving = false;
                }

                if (RightDoor.transform.localPosition.x >= targetPositionOpenedRight)
                {
                    Vector3 newPosition = new Vector3(targetPositionOpenedRight, RightDoor.transform.localPosition.y, RightDoor.transform.localPosition.z);
                    RightDoor.transform.localPosition = newPosition;
                    isClosed = false;
                    isMoving = false;
                }


            }
                else
            {

                // Door needs to close;
                if (LeftDoor.transform.localPosition.x < targetPositionClosedLeft)
                {
                    Vector3 newPosition = new Vector3(LeftDoor.transform.localPosition.x + DoorSpeed * Time.deltaTime,
                                                    LeftDoor.transform.localPosition.y,
                                                    LeftDoor.transform.localPosition.z);

                    LeftDoor.transform.localPosition = newPosition;
                }

                if (RightDoor.transform.localPosition.x > targetPositionClosedRight)
                {
                    Vector3 newPosition = new Vector3(RightDoor.transform.localPosition.x - DoorSpeed * Time.deltaTime,
                                                    RightDoor.transform.localPosition.y,
                                                    RightDoor.transform.localPosition.z);

                    RightDoor.transform.localPosition = newPosition;
                }

                // door is Closed
                if (LeftDoor.transform.localPosition.x >= targetPositionClosedLeft)
                {
                    Vector3 newPosition = new Vector3(targetPositionClosedLeft, LeftDoor.transform.localPosition.y, LeftDoor.transform.localPosition.z);
                    LeftDoor.transform.localPosition = newPosition;
                    isClosed = true;
                    isMoving = false;
                }

                if (RightDoor.transform.localPosition.x <= targetPositionClosedRight)
                {
                    Vector3 newPosition = new Vector3(targetPositionClosedRight, RightDoor.transform.localPosition.y, RightDoor.transform.localPosition.z);
                    RightDoor.transform.localPosition = newPosition;
                    isClosed = true;
                    isMoving = false;
                }



            }



        }
    }


    public void OpenDoor()
    {
        // only take action when door is closed (isCLosed = true)
        isMoving = isClosed;
        if (isMoving)
        {
            doorSound.Play(0);
        }
    }


    public IEnumerator CloseDoor(int closeAfterSeconds)
    {
       
        yield return new WaitForSeconds(closeAfterSeconds);
        
        // only take action when door is open (isCLosed = false)
        isMoving = !isClosed;

        if (isMoving)
        {

            doorSound.Play(0);
            
        }

    }

}
