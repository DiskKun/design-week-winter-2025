using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Tilemaps;
public class ZoneBehaviour : MonoBehaviour
{

    public ObjectManager objectManager;


    
    public Renderer fishbowlRenderer;
    public Renderer sinkRenderer;
    public Renderer windowRenderer;
    public Renderer foodRenderer;
    public Renderer stoveRenderer;

    public int seenState = 0;
    // SEENSTATE LEGEND:
    // 0: SEEN NOTHING!
    // 1: Seen the sink
    // 2: Seen the empty fishbowl
    // 3: Sink on
    // 4: Seen uncooked food
    // 5: Stove with fire ON and sink OFF
    // 6: Seen cooked food



    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        

        // If nothing seen, do nothing (0)

        // If sink seen, show empty fishbowl (1)
        if (sinkRenderer.isVisible && seenState == 0)
        {
            seenState = 1;
            objectManager.SetState("fishbowl", 1);
        }
        // If empty fishbowl seen, allow sink interaction (2) - see SinkZone.cs
        if (seenState == 1 && fishbowlRenderer.isVisible)
        {
            seenState = 2;
        }
        // If sink on (3), show full fishbowl
        if (seenState == 3)
        {
            seenState = 4;
            objectManager.SetState("fishbowl", 2);
        }

        // if seen fishbowl, show raw food
        if (seenState == 4 && fishbowlRenderer.isVisible)
        {
            objectManager.SetState("food", 1);
            seenState = 5;
        }

        // If raw food seen, allow stove interaction - see StoveZone.cs
        if (foodRenderer.isVisible && seenState == 5)
        {
            seenState = 6;
        }

        // If stove lit and sink off, show cooked food and window
        if ((seenState == 7 || seenState == 8) && objectManager.GetState("stove") == 2)
        {
            if (objectManager.GetState("sink") == 1)
            {
                objectManager.SetState("food", 2);
                objectManager.SetState("window", 1);
                seenState = 8;
            }
            else
            {
                objectManager.SetState("window", 0);
                objectManager.SetState("food", 1);
                seenState = 7;
            }
        }

        // if window seen, show pot
        if (seenState == 8 && windowRenderer.isVisible)
        {
            seenState = 9;
            objectManager.SetState("pot", 1);
        }

        if (seenState == 10)
        {
            seenState = 11;
            objectManager.SetState("pot", 2);
            objectManager.SetState("stove", 1);
        }

        if (seenState == 12)
        {
            seenState = 13;
            objectManager.SetState("pot", 3);
            objectManager.SetState("window", 2);
        }

     



        //// No matter what happens, if fishbowl, window, or food seen, turn off sink and stove.
        if (fishbowlRenderer.isVisible || windowRenderer.isVisible || foodRenderer.isVisible)
        {
            objectManager.SetState("sink", 1);
            objectManager.SetState("stove", 1);
        }




    }

    void ResetSinkStove()
    {
        objectManager.SetState("sink", 1);
        objectManager.SetState("stove", 1);
    }

}
