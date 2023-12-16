using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public Piece friendlyPiece;
    public Piece enemyPiece;

    [SerializeField] private Board board;

    private Vector2Int coords;

    public void ChangeToCombat(Piece fPiece, Piece ePiece, Vector2Int coord)
    {
        friendlyPiece = fPiece;
        enemyPiece = ePiece;
        coords = coord;
        SceneManager.LoadScene("CombatScene", LoadSceneMode.Additive);
    }

    public void ChangeToChess(Piece losingPiece)
    {
        SceneManager.UnloadSceneAsync("CombatScene");
        Vector2Int occupied = friendlyPiece.occupiedSquare;
        board.TakePiece(losingPiece);
        if (losingPiece == friendlyPiece)
            board.UpdateBoardOnPieceMove(coords, occupied, enemyPiece, null);
        else
        {
            board.UpdateBoardOnPieceMove(coords, friendlyPiece.occupiedSquare, friendlyPiece, null);
            friendlyPiece.MovePiece(coords);
        }
        board.DeselectPiece();
        board.EndTurn();
    }
}