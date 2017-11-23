using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour {

    public GameObject book_new;
    public GameObject book_old;
    public GameObject bubbles;

    public void enable_cards(){

        
    
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.C))
        {
            book_old.SetActive(false);
            book_new.SetActive(true);
            AudioSource audio = GetComponent<AudioSource>();
            if (audio != null)
            {
                audio.Play();
            }

            StartCoroutine(bubble());
        }
	}

    public IEnumerator bubble()
    {

        bubbles.SetActive(true);
        yield return new WaitForSeconds(10.0f);
        bubbles.SetActive(false);


    }
}
    