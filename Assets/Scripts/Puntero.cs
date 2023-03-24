using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntero : MonoBehaviour
{
    [SerializeField] private projectile ProjectilePrefab;
    [SerializeField] private Transform shootPosition;
    
    private Camera cam;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseWorldPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mouseWorldPoint - (Vector2)transform.position;
        transform.right = direction;


        if (Input.GetMouseButtonDown(0))
        {
           projectile Projectile = Instantiate(ProjectilePrefab, shootPosition.position, transform.rotation);
           Projectile.LaunchProjectile(transform.right);
        }
        
        
    }
}
