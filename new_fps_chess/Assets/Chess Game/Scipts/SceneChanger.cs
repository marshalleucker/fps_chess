using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private Piece friendlyPiece;
    [SerializeField] private Piece enemyPiece;

    private Piece[,] savedGrid;

    private void ChangeScenes(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

    public void ChangeToCombat(Piece fPiece, Piece ePiece, Piece[,] grid)
    {
        friendlyPiece = fPiece;
        enemyPiece = ePiece;
        savedGrid = grid;
        ChangeScenes("CombatScene");
    }
}
