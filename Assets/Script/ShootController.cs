using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootController : MonoBehaviour
{

    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public string keyInput;
    public string winPlayer;
    public Text winDisplay; 
    private bool shooting = false;   

    // Start is called before the first frame update
    void Start()
    {
        
    }   

    // Update is called once per frame
    void Update()
    {

        if(!GameController.instance.playing)
        {
            shooting = true;
        }

        if(shooting && GameController.instance.playing && Input.GetKeyDown(keyInput))
        {
            Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
            shooting = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        winDisplay.text = winPlayer + " WIN";
        GameController.instance.endGame(); 
    }

    public void resetGun()
    {
        shooting = true;
    }
}
