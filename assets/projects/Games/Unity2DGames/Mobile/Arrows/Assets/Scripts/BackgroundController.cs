using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null) return;
 
        float screenHeight = Camera.main.orthographicSize * 2;
        float screenWidth = screenHeight / Screen.height * Screen.width;
 
        transform.localScale = new Vector3(screenWidth / spriteRenderer.sprite.bounds.size.x, 
            screenHeight / spriteRenderer.sprite.bounds.size.y, -5);

        transform.position = new Vector3 (0,0,2);
    }
}
