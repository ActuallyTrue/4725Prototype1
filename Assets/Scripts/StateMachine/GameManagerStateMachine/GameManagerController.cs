using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using TMPro;

public class GameManagerController : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject playerPrefab;
    public List<Transform> spawnPoints;
    public List<StatePlayerController> playerControllers;
    public GameObject crownPrefab;
    
    //Scorboard Stuff
    public GameObject scoreboardCanvas;
    public Transform scoreboardPlayerList;
    public Transform scoreboardScoreList;
    public TextMeshProUGUI[] playerScoreNameList;
    public TextMeshProUGUI[] playerScoreList;

    

    [SerializeField]
    private Image CurrentLawSprite;

    public Animation lawBlinkAnimation;

    private bool lawActive;

    public Camera lawCamera;

    private int playerIndex = -1;

    // Start is called before the first frame update
    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    //just teleports the player back to their original spawnpoint
    //make this function run a death animation on the player and have the player get teleported after the animation
    public void respawnPlayer(PlayerStateInput stateInput) {
        stateInput.playerController.gameObject.transform.position = spawnPoints[stateInput.playerController.playerIndex].position;
    }

    public void respawnAllPlayers() {
        for (int i = 0; i < playerControllers.Count; i++) {
            playerControllers[i].gameObject.transform.position = spawnPoints[playerControllers[i].playerIndex].position;
        }
    }

    public void endGame() {
            Destroy(playerControllers[0].gameObject);
            foreach (Rewired.Player player in Rewired.ReInput.players.Players) {
                player.controllers.ClearAllControllers();
            }
            //SceneManager.LoadScene("Launcher");
    }

}
