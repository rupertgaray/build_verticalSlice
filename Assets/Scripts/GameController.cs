using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static GameController instance;

    
    private bool isNewGame = false;
    private const string FILE_PATH = "saveGameData.dat";
    private SaveGameData saveGame;

    //Variaver para save
    public int vidas, save;
    public int estrelas, cristais, moedas, xp;
    public string nome;

    /*public GameState State { set; get; }
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

    //public enum GameScreens
    {
        MainMenu,
        Options,
        Credits,
        Game
    };*/


    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }


        /*State = GameState.None;
        currentScreen = GameScreens.MainMenu;*/
    }


    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Path.Combine(Application.streamingAssetsPath, FILE_PATH));

        SaveGameData save = new SaveGameData
        {
            lifes = vidas,
            coins = moedas
        };

        bf.Serialize(file, save);

        file.Close();
    }

    public void SaveGame(int val)
    {



        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Path.Combine(Application.streamingAssetsPath, FILE_PATH));

        SaveGameData save = new SaveGameData
        {
            lifes = vidas,
            coins = moedas
        };

        bf.Serialize(file, save);

        file.Close();
    }

    public void LoadGame()
    {
        if(File.Exists(Path.Combine(Application.streamingAssetsPath, FILE_PATH)))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Path.Combine(Application.streamingAssetsPath, FILE_PATH), FileMode.Open);

            SaveGameData save = (SaveGameData) bf.Deserialize(file);
            saveGame = save;

            file.Close();
        }
    }

    public void NovoJogo()
    {
        isNewGame = true;
        LoadStage(0);
    }

    public void CarregaGame()
    {
        isNewGame = false;
        LoadGame();
        LoadStage(saveGame.save);
    }

    public void LoadStage(int stage)
    {
        SceneManager.LoadScene(stage);
    }

    //Quando fechar o jogo ele salva
    private void OnApplicationQuit()
    {
        SaveGame();
    }

    void OnStageLoad(Scene scene, LoadSceneMode mode)
    {
        if(!isNewGame && saveGame != null && scene.name != "Menu")
        {
            vidas = saveGame.lifes;
            moedas = saveGame.coins;
            save = saveGame.save;

            //Player.instance.transform.position = new Vector3(saveGame.positionX, saveGame.positionY, saveGame.positionZ);

            isNewGame = true;

            //UIManager.instace.UpdateUI();
        }
    }

    
}

[Serializable]
class SaveGameData
{
    public int lifes, coins, save;
    //public float positionX, positionY, positionZ;
}