using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpriteSwaper : MonoBehaviour
{
    [SerializeField] private string _spriteSheetName;
    
    private string LoadedSpriteSheetName;
    private Dictionary<string, Sprite> spriteSheet;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        LoadSpriteSheet();
    }
    
    private void LateUpdate()
    {
        // Check if the sprite sheet name has changed (possibly manually in the inspector)
        if (LoadedSpriteSheetName != _spriteSheetName)
        {
            // Load the new sprite sheet
            LoadSpriteSheet();
        }

        // Swap out the sprite to be rendered by its name
        // Important: The name of the sprite must be the same!
        spriteRenderer.sprite = spriteSheet[spriteRenderer.sprite.name];
    }

    // Loads the sprites from a sprite sheet
    private void LoadSpriteSheet()
    {
        // Load the sprites from a sprite sheet file (png). 
        // Note: The file specified must exist in a folder named Resources
        var sprites = Resources.LoadAll<Sprite>(_spriteSheetName);
        spriteSheet = sprites.ToDictionary(x => x.name, x => x);

        // Remember the name of the sprite sheet in case it is changed later
        LoadedSpriteSheetName = _spriteSheetName;
    }
    
}