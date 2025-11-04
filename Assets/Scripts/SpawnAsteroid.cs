using UnityEngine;

public class SpawnAsteroid : MonoBehaviour
{
    [Header("Paramètres de génération")]
    [SerializeField] private GameObject asteroidPrefab;   
    [SerializeField] private Transform sun;               
    [SerializeField] private float spawnRadius = 20f;     
    [SerializeField] private int maxAsteroids = 100;       

    private int asteroidCount = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) 
        {
            SpawnAsteroidAroundSun();
        }
    }

    void SpawnAsteroidAroundSun()
    {
 



        Vector3 randomDir = Random.onUnitSphere; 
        Vector3 spawnPos = sun.position + randomDir * spawnRadius;

        GameObject asteroid;
        if (asteroidPrefab != null)
        {
            asteroid = Instantiate(asteroidPrefab, spawnPos, Random.rotation);
        }
        else
        {
            asteroid = GameObject.CreatePrimitive(PrimitiveType.Cube);
            asteroid.transform.position = spawnPos;
            asteroid.transform.rotation = Random.rotation;

            var renderer = asteroid.GetComponent<Renderer>();
            if (renderer != null)
                renderer.material.color = Color.gray;
        }

        asteroid.AddComponent<RotateSelf>().rotationSpeed = Random.Range(5f, 20f);

        float scale = Random.Range(0.2f, 1f);
        asteroid.transform.localScale = Vector3.one * scale;

        asteroidCount++;
    }
}
