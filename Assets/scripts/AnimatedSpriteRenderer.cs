using UnityEngine;

public class AnimatedSpriteRenderer : MonoBehaviour
{
   private SpriteRenderer SpriteRenderer;
   
   public Sprite idleSprite;
   public Sprite[] animationsprites;

   public float animationTime = 0.25f;
   private int animationFrame; 

   public bool loop = true;
   public bool idle = true;

   private void Awake()
   {
      SpriteRenderer = GetComponent<SpriteRenderer>();
   }

   private void OnEnable()
    {
        SpriteRenderer.enabled = true;
    }

    private void OnDisable()
   {
     SpriteRenderer.enabled = false;
   }

   private void Start()
   {
    InvokeRepeating(nameof(NextFrame), animationTime, animationTime);
   }

   private void NextFrame()
   {
    animationFrame++;

    if(loop && animationFrame >= animationsprites.Length){
        animationFrame = 0;
    }

    if(idle){
        SpriteRenderer.sprite = idleSprite;
    } else if(animationFrame >= 0 && animationFrame < animationsprites.Length) {
        SpriteRenderer.sprite = animationsprites[animationFrame];
    }
   }
}
