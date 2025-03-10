using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Settings")]

    public float minSpawnDelay;
    
    public float maxSpawnDelay;

    [Header("References")]

    public GameObject[] gameObjects;

    //  오브젝트가 활성화될 때마다 호출되는 메서드.
    void OnEnable() 
    {
        Invoke("Spawn", Random.Range(minSpawnDelay, maxSpawnDelay)); //일정 시간 후 호출
    }


    void OnDisable()
    {
        CancelInvoke();
    }
   
 
    void Spawn()
    {
        GameObject randomObject = gameObjects[Random.Range(0, gameObjects.Length)];
        //GameObject 대신 var를 사용해도 됨.
        //var randomObject = gameObject[Random.Range(0, gameObjects.Length)];
        Instantiate(randomObject, transform.position, Quaternion.identity);
        Invoke("Spawn", Random.Range(minSpawnDelay, maxSpawnDelay));
    }
}
