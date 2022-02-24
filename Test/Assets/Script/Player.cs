using UnityEngine;

public class Player : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    public float strength = 5f;

    public float gravity = -9.81f;
    //
    private Vector3 direction;

    public Sprite[] sprites;
    private int spriteIndex;

    
    private void Start()
    {
        //call an another function 
        InvokeRepeating(nameof(Animate), 0.15f, 0.15f);
    }
    //animate our bird, so we need to change sprite
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // 
     private void Update()
     {
      // Everytime we press spacebar the bird flap
      // Same for the mouse, when we press the left click the birf fly
      if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) 
      {
            // we went the direction to be up
            direction = Vector3.up * strength;
      }

        //Make sure to apply gravity to the direction
        direction.y += gravity * Time.deltaTime;
        //Update the position of our bird
        transform.position += direction * Time.deltaTime;
     }

     //
     private void Animate()
    {
        spriteIndex++;
        //loop to be sure to back to the beginning
        if (spriteIndex >= sprites.Length) {
            spriteIndex = 0;
        }
            spriteRenderer.sprite = sprites[spriteIndex];
        
    }
    
     private void OnTriggerEnter2D(Collider2D other)
    {
        //if we touch object with the tag "Obst" we lose and we call GameOver
        if (other.gameObject.CompareTag("Obst")) {
            FindObjectOfType<GameManager>().GameOver();
        } 
        //if we don't touch object with tag "Obst" the score Increase
        else if (other.gameObject.CompareTag("Score")) {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }
}
