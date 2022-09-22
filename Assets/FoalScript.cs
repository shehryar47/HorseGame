using UnityEngine;

public class FoalScript : MonoBehaviour
{
    public Animation anim;
    public string animationName;
    // Start is called before the first frame update
    void Start()
    {
        if (anim = GetComponent<Animation>())
        {

            anim = GetComponent<Animation>();
        }
        else
        {
            anim = GetComponentInChildren<Animation>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        anim.Play("idle");

    }
}
