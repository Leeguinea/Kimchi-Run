using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("how fast should the texture scroll?")]

    public float scrollSpeed;

    //�� ��ũ��Ʈ�� ��ũ�� �ӵ��� �����ϴ� Speed�� Mesh Renderer�� ������ ���� �� �ְ� �ϴ� �ڵ�
    [Header("References")]

    public MeshRenderer meshRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() //�����ӿ� �������ϴ� ���� Time.deltaTime�� �����ִ� ��.
    {
        meshRenderer.material.mainTextureOffset += new Vector2(scrollSpeed * GameManager.Instance.CalculateGameSpeed()/20 * Time.deltaTime, 0); //y���� ����
    }
}
