using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : Piece
{
    // Omnidirectional movements
    private Vector2Int[] directions = new Vector2Int[] {
        Vector2Int.left,
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        new Vector2Int(1, 1),
        new Vector2Int(1, -1),
        new Vector2Int(-1, 1),
        new Vector2Int(-1, -1)
    };

    public override List<Vector2Int> SelectAvailableSquares()
    {
        availableMoves.Clear();
        float range = Board.BOARD_SIZE;

        foreach (var direction in directions)
        {
            for (int i = 1; i <= range; i++)
            {
                Vector2Int nextCoords = occupiedSquare + direction * i;
                Piece piece = board.GetPieceOnSquare(nextCoords);

                if (!board.CheckIfCoordinatesAreOnBoard(nextCoords))    // If off board break to next direction
                    break;
                if (piece == null)                                      // If no piece add to moves
                    TryToAddMove(nextCoords);
                else if (!piece.IsFromSameTeam(this))                   // If enemy team add to moves and break to next direction
                {
                    TryToAddMove(nextCoords);
                    break;
                }
                else if (piece.IsFromSameTeam(this))                    // If same team break to next direction
                    break;
            }
        }

        return availableMoves;
    }
}