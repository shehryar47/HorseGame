using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureSet : MonoBehaviour
{

    public Texture2D[] Texture2D;
    
    public Texture2D[] GetParentTexture()
    {
        return Texture2D;
    }
}
