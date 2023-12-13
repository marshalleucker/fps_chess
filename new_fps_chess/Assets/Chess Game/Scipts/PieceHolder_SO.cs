using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Piece Holder")]
public class PieceHolder_SO : ScriptableObject
{
    private Piece friendlyPiece;
    private Piece enemyPiece;
    
    public void SetPieces(Piece fPiece, Piece ePiece)
    {
        friendlyPiece = fPiece;
        enemyPiece = ePiece;
    }
}
