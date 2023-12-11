using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece
{
    public override List<Vector2Int> SelectAvailableSquares()
    {
        availableMoves.Clear();
        
        Vector2Int direction = team == TeamColor.White ? Vector2Int.up : Vector2Int.down;
        float range = hasMoved ? 1 : 2;

        // Normal movement
        for (int i = 1; i <= range; i++)
        {
            Vector2Int nextCoords = occupiedSquare + direction * i;
            Piece piece = board.GetPieceOnSquare(nextCoords);

            if (!board.CheckIfCoordinatesAreOnBoard(nextCoords))    // If off board break
                break;
            if (piece == null)                                      // If no piece add to moves
                TryToAddMove(nextCoords);
            else if (piece.IsFromSameTeam(this))                    // If same team break
                break;
        }

        // Take movement is diagonal
        Vector2Int[] takeDirections = new Vector2Int[] {new Vector2Int(1, direction.y), new Vector2Int(-1, direction.y)};
        for (int i = 0; i < takeDirections.Length; i++)
        {
            Vector2Int nextCoords = occupiedSquare + takeDirections[i];
            Piece piece = board.GetPieceOnSquare(nextCoords);

            if (!board.CheckIfCoordinatesAreOnBoard(nextCoords))    // If off board break
                break;
            if (piece != null && !piece.IsFromSameTeam(this))       // If enemy team add to moves
                TryToAddMove(nextCoords);
        }

        return availableMoves;
    }
}