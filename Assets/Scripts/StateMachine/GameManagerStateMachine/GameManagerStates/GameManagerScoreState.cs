using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScoreState : GameManagerState
{
    private float stateTime = 7f;
    private float stateTimer;
    public override void Enter(GameManagerStateInput stateInput, CharacterStateTransitionInfo transitionInfo = null)
    {
        stateTimer = stateTime;

    }

    public override void Update(GameManagerStateInput stateInput)
    {
        if (stateTimer >= 0)
        {
            stateTimer -= Time.deltaTime;
        }
        else {
            if (stateInput.currentRun == stateInput.runNum)
            {
                stateInput.gameManagerController.endGame();
            }
            else {
                character.ChangeState<GameManagerBeginState>();
            }
            
        }
    }

    public override void ForceCleanUp(GameManagerStateInput stateInput)
    {
        base.ForceCleanUp(stateInput);
        stateInput.gameManagerController.respawnAllPlayers();
    }
}
