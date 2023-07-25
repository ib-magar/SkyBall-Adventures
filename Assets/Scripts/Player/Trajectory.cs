using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    [SerializeField] int dotsCount;
    [SerializeField] GameObject dotsParent;
    [SerializeField] GameObject dotPrefab;
    [SerializeField] float spacing;
    [SerializeField] [Range(.01f, .05f)] float minDotScale;
    [SerializeField] [Range(.06f, .7f)] float maxDotScale;
    [Space]
    float timeStamp;
    Vector2 pos;
    float gravityValue;
    Transform[] dots;

    private void Start()
    {
        createDots();
        hideDots();

        timeStamp = 0f;
        gravityValue = Physics2D.gravity.magnitude;
    }
    public void createDots()
    {
         dots = new Transform[dotsCount];
        float dotScale = maxDotScale;
        float dotScaleFactor = maxDotScale / dotsCount;
        for (int i=0;i<dotsCount;i++)
        {
            dots[i] = Instantiate(dotPrefab,dotsParent.transform).transform;
            dots[i].localScale = Vector3.one * dotScale;    

              if (dotScale > minDotScale)
            dotScale -= dotScaleFactor;
        }
    }
    public void updateDots(Vector2 ballPos,Vector2 forceApplied)
    {
        timeStamp = spacing;
        
        for(int i=0;i<dotsCount;i++)
        {
            pos.x = (ballPos.x + forceApplied.x * timeStamp);
            pos.y = (ballPos.y + forceApplied.y * timeStamp) - (gravityValue * timeStamp * timeStamp) / 2f;
            dots[i].position = pos;
            timeStamp += spacing;
        }
    }
    public void showDots()
    {
        dotsParent.SetActive(true);
    }
    public  void hideDots()
    {
        dotsParent.SetActive(false);
    }
}
