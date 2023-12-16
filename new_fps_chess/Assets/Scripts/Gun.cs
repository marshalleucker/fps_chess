using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Gun : MonoBehaviour
{
    // Start is called before the first frame update
    private StarterAssetsInputs _input;
    [SerializeField] 
    private GameObject bulletPrefab;
    [SerializeField]
    private GameObject bulletPoint;
    [SerializeField]
    private float bulletSpeed = 600f;
    void Start()
    {
        _input = transform.root.GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
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
        GameObject bullet = Instantiate(bulletPrefab, bulletPoint.transform.position, Quaternion.identity); // Use no rotation upon instantiation

        // Calculate the correct world space forward direction
        Vector3 worldSpaceForward = bulletPoint.transform.TransformDirection(Vector3.forward);

        bullet.GetComponent<Rigidbody>().AddForce(worldSpaceForward * bulletSpeed);
        Destroy(bullet, 2);

        // Debug line to visualize the forward direction in world space
        Debug.DrawLine(bullet.transform.position, bullet.transform.position + worldSpaceForward * 10, Color.red, 2);
    }
}
