using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PieceData
{
    public string pieceType;
    public string pieceColor;
    public int health;
    public int attack;
    public GameObject pieceGameObject;
    private GameData gameData;

    public void Initialize(GameData gameDataReference)
    {
        gameData = gameDataReference;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0) DestroyPiece();
    }

    public void DestroyPiece()
    {
        gameData.DestroyPiece(pieceType);
    }
}

public class GameData : MonoBehaviour
{
    public static GameData instance;

    public PieceData takerPiece;
    public PieceData takenPiece;

    [SerializeField] private Piece takerPiece_;
    [SerializeField] private Piece takenPiece_;

    [SerializeField] private SceneChanger sceneChanger;
    public Dictionary<string, PieceData> piecesDictionary = new Dictionary<string, PieceData>();
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        sceneChanger = FindObjectOfType<SceneChanger>();
        takerPiece_ = sceneChanger.friendlyPiece;
        takenPiece_ = sceneChanger.enemyPiece;
        piecesDictionary.Add(takerPiece.pieceType, takerPiece);
        piecesDictionary.Add(takenPiece.pieceType, takenPiece);

        //Invoke("ChangeToChess", 10f);
    }

    public void DestroyPiece(string pieceIdentifier)
    {
        if (piecesDictionary.ContainsKey(pieceIdentifier))
        {
            PieceData piece = piecesDictionary[pieceIdentifier];
            Destroy(piece.pieceGameObject);

            piecesDictionary.Remove(pieceIdentifier);

            ChangeToChess();
        }
    }

    public void ChangeToChess()
    {
        sceneChanger.ChangeToChess(takenPiece_);
    }

    public void SetCombatData(PieceData taker, PieceData taken)
    {
        takerPiece = taker;
        takenPiece = taken;
    }
}