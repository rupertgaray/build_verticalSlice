using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameState State { set; get; }
    public Stack<GameScreens> Screens = new Stack<GameScreens>();
    public GameScreens currentScreen;

    public enum GameState
    {
        None,
        Title,
        Playing,
        Paused,
        GameOver
    };

    public enum GameScreens
    {
        MainMenu,
        Options,
        Credits,
        Game
    };

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        State = GameState.None;
        currentScreen = GameScreens.MainMenu;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
