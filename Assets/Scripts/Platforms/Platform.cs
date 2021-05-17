using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EdgeCollider2D))]
[RequireComponent(typeof(PlatformEffector2D))]
public class Platform : MonoBehaviour
{
    [SerializeField]
    protected bool isOneWay = true;

    [SerializeField]
    protected bool isDisappearing = true;

    [SerializeField]
    protected float timeToDisappear = 2f;
    protected float timePassed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isOneWay)
            handleOneWayPlatform();

        if (isDisappearing)
            handleDissapearingPlatform();
    }

    protected void handleOneWayPlatform()
    {
        if (Input.GetAxis("Vertical") < 0f)
            gameObject.GetComponent<PlatformEffector2D>().rotationalOffset = 180;
        else
            gameObject.GetComponent<PlatformEffector2D>().rotationalOffset = 0;
    }

    protected void handleDissapearingPlatform()
    {
        timePassed += Time.deltaTime;
        if (timePassed > timeToDisappear)
        {
            timePassed = 0f;
            if (gameObject.GetComponent<EdgeCollider2D>().enabled == false)
                reappearPlatform();
            else
                dissapearPlatform();
        }
    }

    public void dissapearPlatform()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<EdgeCollider2D>().enabled = false;
    }

    public void reappearPlatform()
    {
        gameObject.GetComponent<Renderer>().enabled = true;
        gameObject.GetComponent<EdgeCollider2D>().enabled = true;
    }
}
