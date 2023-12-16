using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Gun : MonoBehaviour
{
    private StarterAssetsInputs _input;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private GameObject bulletPoint;
    [SerializeField]
    private float bulletSpeed = 600f;
    [SerializeField] private AudioClip shootingSound;
    private AudioSource audioSource;

    void Start()
    {
        _input = transform.root.GetComponent<StarterAssetsInputs>();
        audioSource = GetComponent<AudioSource>(); // Initialize the audioSource variable
    }

    void Update()
    {
        if (_input.shoot)
        {
            Shoot();
            _input.shoot = false;
        }
    }

    void Shoot()
    {
        Debug.Log("shoot!");
        GameObject bullet = Instantiate(bulletPrefab, bulletPoint.transform.position, Quaternion.identity);

        Vector3 worldSpaceForward = bulletPoint.transform.TransformDirection(Vector3.forward);

        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(worldSpaceForward * bulletSpeed);
        Destroy(bullet, 2);

        if (audioSource != null && shootingSound != null)
        {
            audioSource.PlayOneShot(shootingSound);
        }

        Debug.DrawLine(bullet.transform.position, bullet.transform.position + worldSpaceForward * 10, Color.red, 2);
    }
}
