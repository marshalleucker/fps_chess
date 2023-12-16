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
    // Add more stats as needed

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0) DestroyPiece();
    }

    private void DestroyPiece()
    {
        // Logic to remove the piece from both scenes

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

        Invoke("ChangeToChess", 3f);
    }

    private void ChangeToChess()
    {
        sceneChanger.ChangeToChess(takenPiece_);
    }

    public void SetCombatData(PieceData taker, PieceData taken)
    {
        takerPiece = taker;
        takenPiece = taken;
    }
}