using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MaterialSetter))]
[RequireComponent(typeof(InstantTweener))]

public class Piece : MonoBehaviour
{
    private MaterialSetter materialSetter;
    public Board board { protected get; set; }
    public Vector2Int occupiedSquare { get; set; }
    public TeamColor team { get; set; }
    public bool hasMoved { get; private set; }
    public List<Vector2Int> availableMoves;

    private InstantTweener tweener;

    private void Awake()
    {
        availableMoves = new List<Vector2Int>();
        tweener = GetComponent<InstantTweener>();
        materialSetter = GetComponent<MaterialSetter>();
        hasMoved = false;
    }

    public void SetMaterial(Material selectedMaterial)
    {
        if(materialSetter == null)
            materialSetter = GetComponent<MaterialSetter>();
        materialSetter.SetSingleMaterial(selectedMaterial);
    }

    public virtual List<Vector2Int> SelectAvailableSquares()
    {
        Debug.Log("Did not override");
        return null;
    }

    public bool IsFromSameTeam(Piece piece)
    {
        return team == piece.team;
    }

    public bool CanMoveTo(Vector2Int coords)
    {
        return availableMoves.Contains(coords);
    }

    public virtual void MovePiece(Vector2Int coords)
    {
        Vector3 targetPosition = board.CalculatePositionFromCoords(coords);
        occupiedSquare = coords;
        hasMoved = true;
        tweener.MoveTo(transform, targetPosition);
    }


    protected void TryToAddMove(Vector2Int coords)
    {
        availableMoves.Add(coords);
    }

    public void SetData(Vector2Int coords, TeamColor team, Board board)
    {
        this.team = team;
        occupiedSquare = coords;
        this.board = board;
        transform.position = board.CalculatePositionFromCoords(coords);
    }
}
