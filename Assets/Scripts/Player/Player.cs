using System;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{

    private void OnEnable()
    {
        //DataCollector.Instance.SaveDataEvent += SaveData;
    }

    //Performance performanceScript;
    [SerializeField] Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //deactivateRigidbody();
        //performanceScript = GameObject.FindObjectOfType<Performance>();
    }
    public void deactivateRigidbody()
    {
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
    }
    public void activateRigidbody()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;

    }
    public void push(Vector2 force)
    {
        rb.AddForce(force, ForceMode2D.Impulse);
    }

    public PlayerController _trajectoryObj;
    private void OnCollisionEnter2D(Collision2D collision)
    {
       // performanceScript.resetJumpCount();
        if (collision.collider.CompareTag("Finish"))
        {
            _trajectoryObj.resetJumpCount();
        }
        
    }

    public void Die()
    {


    }
    void Dead()
    {
        

    }

    private void Awake()
    {
       
    }

    private void FixedUpdate()
    {

        
    }

    private void Update()
    {

        
        
    }
   
    void SaveData()
    {
       
    }





}
