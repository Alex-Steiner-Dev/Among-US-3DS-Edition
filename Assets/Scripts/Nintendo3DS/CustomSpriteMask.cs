using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(SpriteRenderer))]
public class CustomSpriteMask : MonoBehaviour
{
    // The Sprite that will be used as the mask
    public Sprite maskSprite;

    // The Sprite that defines the area of the mask
    public Sprite maskAreaSprite;

    // The material that will be used to mask the Sprite
    public Material maskMaterial;

    // The SpriteRenderer component on the GameObject
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        // Get the SpriteRenderer component
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Set the mask material on the SpriteRenderer
        spriteRenderer.material = maskMaterial;

        // Set the mask Sprite as the main texture of the mask material
        maskMaterial.mainTexture = maskSprite.texture;

        // Set the mask area Sprite as the secondary texture of the mask material
        maskMaterial.SetTexture("_MaskTex", maskAreaSprite.texture);
    }
}
