using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] itemPrefab;

    public float minTime = 1f;
    public float maxTime = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnCoRoutine(0));
    }

    IEnumerator SpawnCoRoutine(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Instantiate(itemPrefab[Random.Range(0, itemPrefab.Length)], new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        StartCoroutine(SpawnCoRoutine(Random.Range(minTime, maxTime)));
    }

    // Update is called once per frame
    void Update()
    {

    }
}