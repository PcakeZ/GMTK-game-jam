using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorStart : MonoBehaviour
{
    public GameObject linkingElevator;
    public GameObject player;
    public GameObject fader;
    public int debugStartRoom;
    public Sprite elevatorOpen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "PlayerTag")
        {
            NextLevel();
        }
    }

    void NextLevel()
    {
        
    }
}
