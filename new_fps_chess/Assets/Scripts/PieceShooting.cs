using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PieceShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public string pieceType; // Assign this in the Inspector or dynamically

    private float fireTimer;
    private float fireRate;
    private bool isInCombatScene;

    void Start()
    {
        // Check if the piece is in the combat scene and is the taken piece
        isInCombatScene = CheckIfInCombatScene() && CheckIfTakenPiece();

        // Set fire rates based on piece type
        SetFireRates();
    }

    void Update()
    {
        if (!isInCombatScene) return;

        fireTimer += Time.deltaTime;

        switch (pieceType)
        {
            case "Pawn":
                SingleFire();
                break;
            case "Knight":
                KnightFire();
                break;
            case "Bishop":
                BishopFire();
                break;
            case "Rook":
                RookFire();
                break;
            case "Queen":
                QueenFire();
                break;
        }
    }

    bool CheckIfInCombatScene()
    {
        // Implement your logic to check if the piece is in the combat scene
        return SceneManager.GetActiveScene().name == "CombatScene";
    }

    bool CheckIfTakenPiece()
    {
        // Implement your logic to check if this is the taken piece
        return GameData.instance.takenPiece == this.gameObject;
    }

    void SetFireRates()
    {
        switch (pieceType)
        {
            case "Pawn":
                fireRate = 2f; // Slower fire rate
                break;
            case "Knight":
                fireRate = 1f; // Faster fire rate
                break;
            case "Bishop":
            case "Rook":
                fireRate = 0.8f; // Even faster fire rate
                break;
            case "Queen":
                fireRate = 0.5f; // Fastest fire rate
                break;
        }
    }

    void SingleFire()
    {
        if (fireTimer >= fireRate)
        {
            FireProjectile(firePoint.forward);
            fireTimer = 0;
        }
    }

    void BurstFire()
    {
        if (fireTimer >= fireRate)
        {
            for (int i = 0; i < 4; i++)
            {
                FireProjectile(firePoint.forward);
            }
            fireTimer = 0;
        }
    }

    void WaveFire()
    {
        if (fireTimer >= fireRate)
        {
            for (int i = -2; i <= 2; i++)
            {
                FireProjectile(firePoint.forward + firePoint.right * i * 0.2f);
            }
            fireTimer = 0;
        }
    }

    void KnightFire()
    {
        SingleFire();
        // Occasionally shoot WaveFire
        if (Random.Range(0, 10) < 2) WaveFire();
    }

    void BishopFire()
    {
        BurstFire();
        // Sometimes shoot WaveFire
        if (Random.Range(0, 10) < 2) WaveFire();
    }

    void RookFire()
    {
        BishopFire(); // Similar pattern to Bishop
    }

    void QueenFire()
    {
        SingleFire();
        WaveFire(); // Constant WaveFire
    }

    void FireProjectile(Vector3 direction)
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = direction.normalized * 10f; // Adjust the speed as needed
    }
}
