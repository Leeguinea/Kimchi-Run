using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Settings")]

    public float minSpawnDelay;
    
    public float maxSpawnDelay;

    [Header("References")]

    public GameObject[] gameObjects;

    //  ������Ʈ�� Ȱ��ȭ�� ������ ȣ��Ǵ� �޼���.
    void OnEnable() 
    {
        Invoke("Spawn", Random.Range(minSpawnDelay, maxSpawnDelay)); //���� �ð� �� ȣ��
    }


    void OnDisable()
    {
        CancelInvoke();
    }
   
 
    void Spawn()
    {
        GameObject randomObject = gameObjects[Random.Range(0, gameObjects.Length)];
        //GameObject ��� var�� ����ص� ��.
        //var randomObject = gameObject[Random.Range(0, gameObjects.Length)];
        Instantiate(randomObject, transform.position, Quaternion.identity);
        Invoke("Spawn", Random.Range(minSpawnDelay, maxSpawnDelay));
    }
}
