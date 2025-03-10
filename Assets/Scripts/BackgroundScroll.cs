using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("how fast should the texture scroll?")]

    public float scrollSpeed;

    //이 스크립트가 스크롤 속도를 제어하는 Speed와 Mesh Renderer에 권한을 가질 수 있게 하는 코드
    [Header("References")]

    public MeshRenderer meshRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() //프레임에 의존안하는 법은 Time.deltaTime을 곱해주는 것.
    {
        meshRenderer.material.mainTextureOffset += new Vector2(scrollSpeed * GameManager.Instance.CalculateGameSpeed()/20 * Time.deltaTime, 0); //y축은 고정
    }
}
