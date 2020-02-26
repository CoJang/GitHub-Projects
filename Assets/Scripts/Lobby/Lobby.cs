using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lobby : MonoBehaviour
{
    [SerializeField] Image PressAK;

    // Start is called before the first frame update
    void Start()
    {
        if (PressAK == null)
            PressAK = GameObject.Find("Press Any Key").GetComponent<Image>();

        //Blink Start
        StartCoroutine(BlinkSprite(true, 0.5f, 0.0f, new Color(1, 1, 1, 0.3f)));
    }

    private void Update()
    {
        if(Input.anyKeyDown)
            SceneManager.LoadScene("MenuScene");
    }


    IEnumerator BlinkSprite(bool IsRepeat, float BlinkTime, float DelayTime, Color dstColor)
    {
        Color srcColor = PressAK.color;
        

        //////////////////////////////////////////////////
        ////////// Starting First In This Area ///////////
        //////////////////////////////////////////////////

        for(float rate = 0.0f; rate < 1.0f; rate += Time.deltaTime / BlinkTime)
        {
            PressAK.color = Color.Lerp(srcColor, dstColor, rate);
            yield return null;
        }


        yield return new WaitForSecondsRealtime(DelayTime);

        //////////////////////////////////////////////////
        ///// Starting After "DelayTime" This Area ///////
        //////////////////////////////////////////////////

        for (float rate = 0.0f; rate < 1.0f; rate += Time.deltaTime / BlinkTime)
        {
            PressAK.color = Color.Lerp(dstColor, srcColor, rate);
            yield return null;
        }

        if (IsRepeat)
            StartCoroutine(BlinkSprite(true, BlinkTime, DelayTime, dstColor));



    }
}
