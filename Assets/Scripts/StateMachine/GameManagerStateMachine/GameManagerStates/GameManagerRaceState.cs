using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerRaceState : GameManagerState
{

    public float countdownTimer;
    private float countdownTime = 30;

    public bool raceWon;
    public override void Enter(GameManagerStateInput stateInput, CharacterStateTransitionInfo transitionInfo = null)
    {
        raceWon = false;
        countdownTimer = countdownTime;
    }

    public override void Update(GameManagerStateInput stateInput)
    {
        if (raceWon) {
            character.ChangeState<GameManagerScoreState>();
        }
    }

    public override void ForceCleanUp(GameManagerStateInput stateInput)
    {
        base.ForceCleanUp(stateInput);
    }
}

