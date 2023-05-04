using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class RandomPrefabGenerator : MonoBehaviour
{
    public GameObject prefab;
    private Vector2 initialPosition =new Vector2(0, 6);
    public float moveSpeed = 2f;
    public float minY = -6f;
    public float timer = 0.0f;
    public float interval = 1.0f;
    public string directionString;
    public TMP_Text dText;
    private SwipeD swipeD;
    private TimeManager timeManager;

    private Animation animatorW;

    private Animation animatorC;

    public GameObject correctScore;

    public GameObject wrongScore;

    private BoxCollider2D gameEndCollider;
    public TMP_Text scoreT;
    public int score;
    public bool isGamePaused; // new boolean to track pause state
    public bool anyCloneReachedZero = false; // remove this variable from its previous location

    void Start()
    {   
        CloneAction();
        timeManager = GameObject.FindObjectOfType<TimeManager>();
        swipeD = GameObject.FindObjectOfType<SwipeD>();
        GameObject gameEndColliderObject = GameObject.Find("GameEndCollider");
        gameEndCollider = gameEndColliderObject.GetComponent<BoxCollider2D>();
        score = 0;
        directionString = "null";
        animatorC = correctScore.GetComponent<Animation>();
        animatorW = wrongScore.GetComponent<Animation>();
    }
    public void CloneAction() {
            // Instantiate a new clone of the prefab
            GameObject clone = Instantiate(prefab);
            // Tagging the new clone
            string cloneTag = "Clone";
            clone.tag = cloneTag;
            // Set its position to be on top of the previous clone on the Y axis
            Vector2 position = initialPosition;
            clone.transform.position = position;
            // Import the sprite options "spriteRenderer"
            SpriteRenderer spriteRenderer = clone.GetComponent<SpriteRenderer>();
            // Randomly selet the color of the sprite (W,Y)
            // Define an array of two colors to choose from
            Color[] colors = {Color.white, Color.yellow};
            // Randomly select an index between 0 and 1
            int randomColor = UnityEngine.Random.Range(0, 2);
            // Set the color of the sprite renderer to the selected color
            spriteRenderer.color = colors[randomColor];

            // Define an array of four rotations to choose from
            Quaternion[] rotations = {
                Quaternion.Euler(0f, 0f, 0f), 
                Quaternion.Euler(0f, 0f, 90f), 
                Quaternion.Euler(0f, 0f, 180f), 
                Quaternion.Euler(0f, 0f, 270f)
            };
            // Randomly select an index between 0 and 3
            int randomRotation = UnityEngine.Random.Range(0, 4);
            // Set the rotation of the game clone to the selected rotation
            clone.transform.rotation = rotations[randomRotation];

            int cColor = randomColor;
            int cRotation = randomRotation;
            Debug.Log("New CLONE : C :" + cColor + " Rotation : " + cRotation);

        }

    private void CheckArrowDirection(GameObject clone) {
        // Initialize correctSwipe to false
        Color[] colors2 = {Color.white, Color.yellow, Color.green, Color.red};
                    
        //Declaring the directions to be used when compating
        Quaternion[] rotations2 = {
                Quaternion.Euler(0f, 0f, 0f), 
                Quaternion.Euler(0f, 0f, 90f), 
                Quaternion.Euler(0f, 0f, 180f), 
                Quaternion.Euler(0f, 0f, 270f)
        };
        // Get the SpriteRenderer of the middle circle into a new variable
        Sprite[] images = timeManager.images;
        SpriteRenderer spriteRendererCircle = timeManager.circle.GetComponent<SpriteRenderer>();

        //Get the SpriteRenderer of that specific clone into a new variable
        SpriteRenderer specificCloneRenderer = clone.GetComponent<SpriteRenderer>();
        //Get the position of the specific clone
        //If a swipe is finished
        directionString = swipeD.directionString;

        switch (directionString) {
            case "Right":
                if (clone.transform.rotation == rotations2[0] && specificCloneRenderer.color == colors2[0]) {
                        score += 36;
                        animatorC.Play("scoreUpdate");
                        isGamePaused = false;
                        Debug.Log("+ Correct Swipe ! +");
                        specificCloneRenderer.color = colors2[2];
                        spriteRendererCircle.sprite = images[1];
                        // exit the loop once a correct swipe is detected    
                } else if (clone.transform.rotation == rotations2[2] && specificCloneRenderer.color == colors2[1]) {
                        score += 36;
                        animatorC.Play("scoreUpdate");
                        isGamePaused = false;
                        Debug.Log("+ Correct Swipe ! +");
                        specificCloneRenderer.color = colors2[2];
                        spriteRendererCircle.sprite = images[1];
                        // exit the loop once a correct swipe is detected    
                } else {
                    if (score  > 0 ) {
                        score -= 1;
                    }
                        animatorW.Play("scoreUpdate");
                        isGamePaused = false;
                        specificCloneRenderer.color = colors2[3];
                        spriteRendererCircle.sprite = images[2];
                        Debug.Log("- Wrong Swipe -");
                }
                break;

            case "Up":
                if (clone.transform.rotation == rotations2[1] && specificCloneRenderer.color == colors2[0]) {
                        score += 36;
                        animatorC.Play("scoreUpdate");
                        isGamePaused = false;
                        Debug.Log("+ Correct Swipe ! +");
                        specificCloneRenderer.color = colors2[2];
                        spriteRendererCircle.sprite = images[1];
                        // exit the loop once a correct swipe is detected   
                } else if (clone.transform.rotation == rotations2[3] && specificCloneRenderer.color == colors2[1]) {
                        score += 36;
                        isGamePaused = false;
                        Debug.Log("+ Correct Swipe ! +");
                        specificCloneRenderer.color = colors2[2];
                        spriteRendererCircle.sprite = images[1];
                        // exit the loop once a correct swipe is detected       
                } else {
                    if (score  > 0 ) {
                        score -= 1;
                    }
                        isGamePaused = false;
                        animatorW.Play("scoreUpdate");
                        specificCloneRenderer.color = colors2[3];
                        spriteRendererCircle.sprite = images[2];
                        Debug.Log("- Wrong Swipe -");
                }
                break;

            case "Left":
                if (clone.transform.rotation == rotations2[2] && specificCloneRenderer.color == colors2[0]) {
                        score += 36;
                        animatorC.Play("scoreUpdate");
                        isGamePaused = false;
                        Debug.Log("+ Correct Swipe ! +");
                        specificCloneRenderer.color = colors2[2];
                        spriteRendererCircle.sprite = images[1];
                        // exit the loop once a correct swipe is detected  
                } else if (clone.transform.rotation == rotations2[0] && specificCloneRenderer.color == colors2[1]) {
                        score += 36;
                        animatorC.Play("scoreUpdate");
                        isGamePaused = false;
                        Debug.Log("+ Correct Swipe ! +");
                        specificCloneRenderer.color = colors2[2];
                        spriteRendererCircle.sprite = images[1];
                        // exit the loop once a correct swipe is detected 
                } else {
                    if (score  > 0 ) {
                        score -= 1;
                    }
                        isGamePaused = false;
                        animatorW.Play("scoreUpdate");
                        specificCloneRenderer.color = colors2[3];
                        spriteRendererCircle.sprite = images[2];
                        Debug.Log("- Wrong Swipe -");
                }
                break;

            case "Down":
                if (clone.transform.rotation == rotations2[3] && specificCloneRenderer.color == colors2[0]) {
                        score += 36;
                        animatorC.Play("scoreUpdate");
                        isGamePaused = false;
                        Debug.Log("+ Correct Swipe ! +");
                        specificCloneRenderer.color = colors2[2];
                        spriteRendererCircle.sprite = images[1];
                        // exit the loop once a correct swipe is detected 
                } else if (clone.transform.rotation == rotations2[1] && specificCloneRenderer.color == colors2[1]) {
                        score += 36;
                        animatorC.Play("scoreUpdate");
                        isGamePaused = false;
                        Debug.Log("+ Correct Swipe ! +");
                        specificCloneRenderer.color = colors2[2];
                        spriteRendererCircle.sprite = images[1];
                        // exit the loop once a correct swipe is detected 
                } else {
                    if (score  > 0 ) {
                        score -= 1;
                    }
                        isGamePaused = false;
                        animatorW.Play("scoreUpdate");
                        specificCloneRenderer.color = colors2[3];
                        spriteRendererCircle.sprite = images[2];
                        Debug.Log("- Wrong Swipe -");
                }
                break;
        }
    }

    void Update() { 

        // import the current Menu pause from timemanager
        bool isPaused = timeManager.isPaused;
        
        // UPDATING UI TEXTS
        // Updating the direction of the swipe
        dText.text = directionString;
        // Updating the score UI
        scoreT.text = score.ToString();
            
        // Get all the clones in the scene
        GameObject[] clones = GameObject.FindGameObjectsWithTag("Clone");

        // If GAME MENU IS NOT PAUSED && INGAME IS NOT PAUSED
        if (!isPaused && !isGamePaused){

            // Apply the modification to the timer variable to check for spawn possibility
            timer += Time.deltaTime;
            if (timer > interval) {
                Debug.Log("+ Creating New Clone !");
                CloneAction();
                timer = 0.0f;
            }

            // Go through every clone and move them down
            foreach (GameObject clone in clones) {
            Vector2 position = clone.transform.position;
            // Modify the Y positon of the clone so it goes down
            position.y -= moveSpeed * Time.deltaTime;
            //  Apply the modification to the position on Y
            clone.transform.position = position;
            }
        }

        if (isGamePaused) {
            foreach (GameObject clone in clones) {
                Vector2 position = clone.transform.position;
                if (position.y < 1.1f && position.y > -1.1f) {
                    CheckArrowDirection(clone);
                }
            }
        }
        // Destroy any Clone objects that reach the end of the screen Y = -6
        foreach (GameObject clone in clones) {
            // Get the position of all clones
            Vector2 position = clone.transform.position;
            // Destroy the clone if it falls below the minY value
            if (position.y < minY) {
                Destroy(clone);
            }
        }
        
    }
}