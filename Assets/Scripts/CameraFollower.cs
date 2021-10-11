using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;
    
    // Start is called before the first frame update
    private void Start()
    {
        offset = transform.position - player.position;
    }

    private void FixedUpdate()
    {
        transform.position = player.position + offset;  
    }
}
