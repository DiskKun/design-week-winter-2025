using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Tilemaps;
public class ZoneBehaviour : MonoBehaviour
{

    public ObjectManager objectManager;

    
    public Renderer fishbowlRenderer;
    public Renderer fireplaceRenderer;
    public Renderer sinkRenderer;

    public int seenState = 0;
    // SEENSTATE LEGEND:
    // 0: SEEN NOTHING!
    // 1: Seen the sink
    // 2: Seen the empty fishbowl
    // 3: Sink on
    // 4: Seen unlit fireplace
    // 5: Stove with fire ON and sink OFF
    // 6: Seen the fireplace with fire



    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // No matter what happens, if fishbowl seen, turn off sink and stove.
        if (fishbowlRenderer.isVisible)
        {
            objectManager.SetState("sink", 1);
            objectManager.SetState("stove", 1);
        }

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
        // If sink on (3), show full fishbowl and unlit fireplace
        if (seenState == 3)
        {
            objectManager.SetState("fishbowl", 2);
            objectManager.SetState("fireplace", 1);
        }
        // If unlit fireplace seen (4), allow stove interaction - see StoveZone.cs
        if (fireplaceRenderer.isVisible && seenState == 3)
        {
            seenState = 4;
        }

        // If stove lit and sink off, show lit fireplace
        if (seenState == 5 && objectManager.GetState("stove") == 2)
        {
            if (objectManager.GetState("sink") == 1)
            {
                objectManager.SetState("fireplace", 2);
            } else
            {
                objectManager.SetState("fireplace", 1);
            }
        }



        
    }

}
