using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalController : MonoBehaviour
{
    public GameManager gameManager;

    void Start() {
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.layer == 9) {
            //signal that it's time to change to score state
            if (gameManager.GetState() is GameManagerRaceState) {
                GameManagerRaceState raceState = (GameManagerRaceState) gameManager.GetState();
                StatePlayerController player = collider.gameObject.GetComponent<StatePlayerController>();
            }
        }

    }
}
