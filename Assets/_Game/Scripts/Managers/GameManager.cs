using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { Menu, GamePlay, Finish }

public class GameManager : Singleton<GameManager>
{
    private GameState gameState;

    public void ChangeState(GameState gameState)
    {
        this.gameState = gameState;
    }

    public bool IsState(GameState gameState)
    {
        return this.gameState == gameState;
    }
    
    public GameState getCurentState()
    {
        return gameState;
    }
    private void Awake()
    {
        ChangeState(GameState.Menu);
    }
}
