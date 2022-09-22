using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoalBirth : MonoBehaviour
{
    public List<Texture2D> BirthTextures = new List<Texture2D>();
    public GameObject father, mother;
    void Start()
    {
        var fatherTextures = father.GetComponent<TextureSet>().GetParentTexture();
        var motherTextures = mother.GetComponent<TextureSet>().GetParentTexture();

        foreach(Texture2D fatherTex in fatherTextures)
        {
            BirthTextures.Add(fatherTex);
        }foreach(Texture2D motherTex in motherTextures)
        {
            BirthTextures.Add(motherTex);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
