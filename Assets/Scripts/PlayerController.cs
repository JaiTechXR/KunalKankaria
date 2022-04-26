using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI systemid;
    public int coinCount;
    [SerializeField] float speed;
    [SerializeField] float portalReloadTime;
    Rigidbody rb;
    Vector3 movement;
    GameObject otherPortal;
    float timer;
    public TextMeshProUGUI score;
    public AudioSource music;
    public AudioSource deathSound;
    private void Awake()
    {
        coinCount = 0;
    }
    void Start()
    {
        systemid.SetText(SystemInfo.deviceUniqueIdentifier);
        music.Play();
        timer = 0f;
        rb = GetComponent<Rigidbody>();
    }
    void Win()
    {
        SceneManager.LoadScene("Win");
        Debug.Log("Won the game");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Portal"&&timer>portalReloadTime)
        {
            Debug.Log("Teleporting");
            otherPortal = other.GetComponent<Portal>().other;
            transform.position = otherPortal.transform.position;
            timer = 0f;           
        }
        if(other.tag=="Coin")
        {
            coinCount++;
            Debug.Log("Number of coins: "+coinCount);
            score.SetText("Score: {0}", coinCount);
            Destroy(other.gameObject);
            if(coinCount>=7)
            {
                Win();
            }
        }
        if(other.tag=="Trap")
        {
            Die();
        }
    }
    void Die()
    {
        SceneManager.LoadScene("GameOver");
        Debug.Log("Dying");
    }
    void Update()
    {
        if(transform.position.y<=-20f)
        {
            Die();
        }
        timer += Time.deltaTime;        
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        movement = new Vector3(h, 0f, v);
        rb.AddForce(movement * Time.deltaTime * speed);
    }
    
}
