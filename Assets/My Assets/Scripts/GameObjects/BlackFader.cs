using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackFader : MonoBehaviour
{
    public float fadeSpeed;
    public bool isBlack = false;
    public float currentAlpha = 1f;
    

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isBlack == true)
        {
            if(currentAlpha < 1)
            {
                currentAlpha += Time.deltaTime * fadeSpeed;
            }
        }
        else
        {
            if (currentAlpha > 0)
            {
                currentAlpha -= Time.deltaTime * fadeSpeed;
            }
        }
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, currentAlpha);
    }
}
