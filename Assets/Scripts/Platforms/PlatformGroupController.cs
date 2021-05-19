using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGroupController : MonoBehaviour
{
    [SerializeField]
    Transform[] groups;

    [SerializeField]
    float intervalTime = 3f;

    float passedTime = 0;

    int currentGroupNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform parentGroup in transform)
            dissappearAllPlatformsInGroup(parentGroup);

        reappearAllPlatformsInGroup(groups[currentGroupNum]);
    }

    // Update is called once per frame
    void Update()
    {
        passedTime += Time.deltaTime;
        if (passedTime > intervalTime)
        {
            passedTime = 0f;

            activateNextGroup();
        }
    }

    void activateNextGroup()
    {
        dissappearAllPlatformsInGroup(groups[currentGroupNum]);
        currentGroupNum = (currentGroupNum + 1) % groups.Length;
        reappearAllPlatformsInGroup(groups[currentGroupNum]);
    }

    void dissappearAllPlatformsInGroup(Transform group)
    {
        foreach (Transform child in group)
        {
            child.GetComponent<Platform>().dissapearPlatform();
        }
    }

    void reappearAllPlatformsInGroup(Transform group)
    {
        foreach (Transform child in group)
        {
            child.GetComponent<Platform>().reappearPlatform();
        }
    }
}
