using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : Character<GameManager, GameManagerState, GameManagerStateInput> {

	override protected void Init()
    {
        stateInput.stateMachine = this;
        stateInput.gameManagerController = GetComponent<GameManagerController>();
    }

    override protected void SetInitialState()
    {
        ChangeState<GameManagerBeginState>();
    }

    public GameManagerStateInput GetStateInput() {
        return stateInput;
    }

    public GameManagerState GetState() {
        return state;
    }

}

public abstract class GameManagerState : CharacterState<GameManager, GameManagerState, GameManagerStateInput>
{

}

public class GameManagerStateInput : CharacterStateInput
{
    public GameManagerController gameManagerController;
    public GameManager stateMachine;
    public GameManagerVariableHolder variableHolder;
    public GameObject spawnWalls;
    public int runNum;
    public int currentRun = 0;
}

