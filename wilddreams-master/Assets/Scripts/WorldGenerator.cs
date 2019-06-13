using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldGenerator : MonoBehaviour
{

    public GameObject CubeDirt;
    public GameObject CubeWall;
    public GameObject CubeWallBreakable;
    public GameObject Doors;
    public GameObject Button;
    public GameObject Key;
    public GameObject Guess;
    public GameObject Guess9;
    public GameObject Guess92;
    public GameObject Put;
    public GameObject winCanvas;
    public GameObject loseCanvas;

    public bool checkForCombo;
    public bool secondStage;
    public bool guess1;
    public bool guess2;
    public bool guess3;
    public bool guess4;
    public bool guess5;
    public bool isWinning = false;

    private GameObject playerOne;
    private GameObject playerTwo;
    private GameObject objects;
    private Map map;
    public static float timer;
    public TextMesh showTimer;

    private void InitializePlayerOne(int x, int y)
    {
        DrawDirt(x, y);
        playerOne = GameObject.Find("Pig");
        playerOne.transform.position = new Vector3(x, 0f, y);
        playerOne.GetComponent<Renderer>().material.color = Color.green;
    }

    private void InitializePlayerTwo(int x, int y)
    {
        DrawDirt(x, y);
        playerTwo = GameObject.Find("Chicken");
        playerTwo.transform.position = new Vector3(x, 0f, y);
        playerTwo.GetComponent<Renderer>().material.color = Color.red;
    }

    private void DrawWall(int x, int y) {
        DrawDirt(x, y);
        GameObject prefab = Instantiate(CubeWall) as GameObject;
        prefab.transform.position = new Vector3(x, 0f, y);
        prefab.transform.parent = objects.transform;
        prefab.AddComponent<Rigidbody>();
        prefab.GetComponent<Rigidbody>().isKinematic = true;
        prefab.GetComponent<Rigidbody>().useGravity = true;

    }

    private void DrawDirt(int x, int y)
    {
        GameObject prefab = Instantiate(CubeDirt) as GameObject;
        prefab.transform.position = new Vector3(x, -1f, y);
        prefab.transform.parent = objects.transform;
    }

    private void DrawWallBreakable(int x, int y)
    {
        DrawDirt(x, y);
        GameObject prefab = Instantiate(CubeWallBreakable) as GameObject;
        prefab.transform.position = new Vector3(x, 0f, y);
        prefab.AddComponent<Rigidbody>();
        prefab.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        prefab.transform.parent = objects.transform;
        prefab.name = "push" + x + y;
    }

    private void DrawDoor(int x, int y)
    {
        DrawDirt(x, y);
        GameObject prefab = Instantiate(Doors) as GameObject;
        prefab.transform.position = new Vector3(x, 0f, y);
        prefab.transform.parent = objects.transform;
        prefab.name = "door" + x + y;
        prefab.AddComponent<Rigidbody>();
        prefab.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void DrawKey(int x, int y)
    {
        DrawDirt(x, y);
        GameObject prefab = Instantiate(Key) as GameObject;
        prefab.transform.position = new Vector3(x, 0f, y);
        prefab.transform.parent = objects.transform;
        prefab.tag = "Key";
        prefab.GetComponent<Collider>().isTrigger = true;
    }

    private void DrawPut(int x, int y)
    {
        DrawDirt(x, y);
        GameObject prefab = Instantiate(Put) as GameObject;
        prefab.transform.position = new Vector3(x, -0.6f, y);
        prefab.transform.parent = objects.transform;
    }

    private void DrawButton(int x, int y)
    {
        DrawDirt(x, y);
        GameObject prefab = Instantiate(Button) as GameObject;
        prefab.transform.position = new Vector3(x, -0.46f, y);
        prefab.transform.parent = objects.transform;
        prefab.name = "button" + x + y;
    }

    private void DrawGuess(int x, int y)
    {
        DrawDirt(x, y);
        GameObject prefab = Instantiate(Guess) as GameObject;
        prefab.transform.position = new Vector3(x, -0.4f, y);
        prefab.transform.parent = objects.transform;
        prefab.name = "guess_" + x + y;
    }

    private void DrawGuess9(int x, int y)
    {
        DrawDirt(x, y);
        GameObject prefab = Instantiate(Guess9) as GameObject;
        prefab.transform.position = new Vector3(x, -0.4f, y);
        prefab.transform.parent = objects.transform;
        prefab.name = "guess9_" + x + y;
    }

    private void DrawGuess92(int x, int y)
    {
        DrawDirt(x, y);
        GameObject prefab = Instantiate(Guess92) as GameObject;
        prefab.transform.position = new Vector3(x, -0.4f, y);
        prefab.transform.parent = objects.transform;
        prefab.name = "guess92_" + x + y;
    }

    private void DrawObject(int x, int y, int type) 
    {
        switch(type) 
        {
            case 0:
                DrawDirt(x, y);
                break;
            case 1:
                DrawWall(x, y);
                break;
            case 2:
                InitializePlayerOne(x, y);
                break;
            case 3:
                DrawDoor(x, y);
                break;
            case 4:
                DrawWallBreakable(x, y);
                break;
            case 5:
                DrawButton(x, y);
                break;
            case 6:
                InitializePlayerTwo(x, y);
                break;
            case 7:
                DrawKey(x, y);
                break;
            case 8:
                DrawPut(x, y);
                break;
            case 9:
                DrawGuess(x, y);
                break;
            case 10:
                DrawGuess9(x, y);
                break;
            case 11:
                DrawGuess92(x, y);
                break;

        }
    }

    private void Draw2DMap(int [,] map) 
    {
        for (int x = 0; x < map.GetUpperBound(0) + 1; x++)
        {
            for (int y = 0; y < map.GetUpperBound(1) + 1; y++)
            {
                DrawObject(y, x, map[x, y]);
            }
        }
    }

    void Start()
    {
        checkForCombo = false;
        guess1 = false;
        guess2 = false;
        guess3 = false;
        guess4 = false;
        guess5 = false;
        secondStage = false;
        objects = GameObject.Find("Objects");
        map = new Playground(); 
        Draw2DMap(map.GetMap);
        this.SnapCameraToCenter(map.GetMap);
        winCanvas.SetActive(false);
        loseCanvas.SetActive(false);
        timer = Menu.startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= 0f && !PauseMenu.isPaused)
        {
            timer -= Time.deltaTime;
            showTimer.text = timer.ToString("f2");
        }
        if(timer <= 0f)
        {
            loseCanvas.SetActive(true);
        }
        if (checkForCombo && guess1 && guess2 && !secondStage) {
            Destroy(GameObject.Find("door118"));
            Destroy(GameObject.Find("door218"));
            checkForCombo = false;
            guess1 = false;
            guess2 = false;
            secondStage = true;
        }

        if(GameObject.Find("Pig").GetComponent<PigController>().hasObject && GameObject.Find("Chicken").GetComponent<ChickenController>().hasObject)
        {
            Destroy(GameObject.Find("door1618"));
            Destroy(GameObject.Find("door1718"));
        }

        if (checkForCombo && guess1 && guess2 && guess3 && guess4 && guess5 &&!isWinning)
        {
            Destroy(GameObject.Find("door424"));
            Destroy(GameObject.Find("door624"));
            Destroy(GameObject.Find("door524"));
            Destroy(GameObject.Find("door1224"));
            Destroy(GameObject.Find("door1424"));
            Destroy(GameObject.Find("door1324"));
            winCanvas.SetActive(true);
            isWinning = true;
        }
        this.SnapCameraToCenter(map.GetMap);
    }
    private void SnapCameraToCenter(int[,] map)
    {
        transform.position = new Vector3(9f, 10f, ((playerOne.transform.position.z + playerTwo.transform.position.z) / 2) - 4.5f);
        transform.rotation = Quaternion.Euler(45, 0, 0);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Challenge1");
        loseCanvas.SetActive(false);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

}
