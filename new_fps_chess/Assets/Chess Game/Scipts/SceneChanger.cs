using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private Piece friendlyPiece;
    [SerializeField] private Piece enemyPiece;

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
        SceneManager.LoadScene("SampleScene");
        board.TakePiece(losingPiece);
        board.UpdateBoardOnPieceMove(coords, friendlyPiece.occupiedSquare, friendlyPiece, null);
        friendlyPiece.MovePiece(coords);
        board.DeselectPiece();
        board.EndTurn();
    }
}
