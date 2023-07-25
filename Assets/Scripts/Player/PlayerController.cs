using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JetBrains.Annotations;

public class PlayerController : MonoBehaviour
{

    [SerializeField] Player player;
    [SerializeField] float pushForce;
    [SerializeField] bool isDragging;

    [Space]
    [SerializeField] Vector2 startPoint;
    [SerializeField] Vector2 endPoint;
    [SerializeField] Vector2 direction;
    [SerializeField] Vector2 force;
    [SerializeField] float distance;
    [SerializeField] float minDistance, maxDistance;

    [Space]
    [SerializeField] Trajectory trajectory;

    public int jumpCount = 2;
    int jumpCounter;
    private void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        isDragging = false;

        jumpCounter = jumpCount;
    }
    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0) && jumpCounter > 0)
        {
            isDragging = true;
            onDragStart();
        }
        if (Input.GetMouseButtonUp(0))
        {
            jumpCounter--;
            isDragging = false;
            onDragEnd();
        }
#else

        if(Input.touchCount>0 && Input.GetTouch(0).phase==TouchPhase.Began)
        {
            isDragging = true;
            onDragStart();
        }
        if(Input.GetTouch(0).phase==TouchPhase.Ended)
        {
            isDragging = false;
            onDragEnd();
        }
#endif
        onDrag();
    }
    void onDragStart()
    {
   
        player.deactivateRigidbody();
#if UNITY_EDITOR
        startPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
#else
        
        startPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
#endif
        //Time.timeScale = .2f;

        trajectory.showDots();
    }
    void onDrag()
    {
        if (isDragging)
        {
#if UNITY_EDITOR
            endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
#else
            endPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
#endif
            direction = (startPoint - endPoint).normalized;
            distance = Mathf.Clamp(Vector2.Distance(startPoint, endPoint), minDistance, maxDistance);
            //distance = Mathf.Clamp(distance, minDistance, maxDistance);
            force = direction * pushForce * distance;
            //
            Debug.DrawLine(startPoint, endPoint, Color.green);


            trajectory.updateDots(player.transform.position, force);
        }

    }
    void onDragEnd()
    {
        //Time.timeScale = 1f;
        player.activateRigidbody();
        player.push(force);

        trajectory.hideDots();
    }
    public void resetJumpCount()
    {
        jumpCounter = jumpCount;
    }


}
