using System.Collections;
using UnityEngine;

public class ColliderCheck : MonoBehaviour
{

    private RandomPrefabGenerator randomPrefabGenerator;
    private SwipeD swipeD;
    void Start()
    {
        randomPrefabGenerator = GameObject.FindObjectOfType<RandomPrefabGenerator>();
        swipeD = GameObject.FindObjectOfType<SwipeD>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        randomPrefabGenerator.isGamePaused = true;
        Debug.Log("Objects colided and game paused");
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        randomPrefabGenerator.directionString = "null";
        swipeD.directionString = "null";
    }
}
