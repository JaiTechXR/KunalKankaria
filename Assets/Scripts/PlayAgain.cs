using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayAgain : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject button;
    public GameObject text;
    [SerializeField] float fadeInTime;
    float timer;
    Image image;
    private void Awake()
    {
        timer = 0f;
        image = button.GetComponent<Image>();
    }
    public void _PlayAgain()
    {

        SceneManager.LoadScene("SampleScene");
    }
    private void Update()
    {
        timer += Time.deltaTime;
        image.color = new Color(image.color.r, image.color.g, image.color.b, timer / fadeInTime);
        if(timer>=fadeInTime)
        {
            text.SetActive(true);
        }
    }
}
