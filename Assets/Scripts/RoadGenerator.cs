using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoadGenerator : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject prefabPlane;
    
    [Header("Settings")]
    [SerializeField] private Transform player;
    [SerializeField] private List<GameObject> current;
    [Range(1, 5)] [SerializeField] private int startCount = 2;

    [Header("Other")]
    [SerializeField] private float spawn;
    [SerializeField] private float length = 100;
    [SerializeField] private float offset = 2.5f;

    private void Start()
    {
        for (var i = 0; i < startCount; i++)
        {
            SpawnTile();
        }
    }

    private void FixedUpdate()
    {
        Debug.Log($"current {spawn}, player {player.position.x}, first {current.First().transform.position.x}");

        if (player.position.x - length > current.First().transform.position.x)
        {
            DeleteTile();
        }

        if (player.position.x > spawn - length * offset)
        {
            SpawnTile();
        }
    }

    private void DeleteTile()
    {
        Destroy(current[0]);
        current.RemoveAt(0);
    }

    private void SpawnTile()
    {
        var clone = Instantiate(prefabPlane,
            Vector3.right * spawn,
            Quaternion.identity,
            transform);

        clone.GetComponent<Renderer>().material.color = Random.ColorHSV();
        current.Add(clone);

        spawn += length;
    }
}