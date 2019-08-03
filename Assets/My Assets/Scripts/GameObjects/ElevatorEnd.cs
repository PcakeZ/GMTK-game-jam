using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorEnd : MonoBehaviour
{
    public GameObject linkingElevator;
    public GameObject player;
    public GameObject fader;
    public int debugStartRoom;
    public Sprite elevatorClosed;
    public float nextLevelTimer;

    // Start is called before the first frame update
    void Start()
    {
        if (debugStartRoom != 0)
        {
            GameMaster.currentLevel = debugStartRoom;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerTag")
        {
            NextLevel();
        }
    }

    void NextLevel()
    {
        ++GameMaster.currentLevel;
        player.GetComponent<PlayerMovement>().canMove = false;
        fader.GetComponent<BlackFader>().isBlack = true;
    }
}
