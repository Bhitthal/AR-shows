using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cards : MonoBehaviour {

    [SerializeField]
    public GameObject[] card;
    [SerializeField]
    public Text[] text;

    public float speed = 40.0f;

     Vector3[] position_science = new Vector3[13];

    string science = "ABHINAVTUSHAR";

    public void ena() {
        this.enabled = true;
    }

	// Use this for initialization
	void Start () {

        Vector3 temp_rott = new Vector3(0,180,0);
        card[4].SetActive(false);
        card[5].SetActive(false);
        card[6].SetActive(false);
        card[7].SetActive(false);
        card[8].SetActive(false);
        Debug.Log(card.Length);
        for (int i = 0; i < card.Length; i++)
        {
            
            card[i].transform.eulerAngles = temp_rott;
            text[i].text = "";

            position_science[i] = card[i].transform.position;
        }

        
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(science_play());
        }
	}

    public IEnumerator science_play(){

        bool flag = true;
        while (card[0].transform.eulerAngles.y > 0)
        {
            //Debug.Log(card[a].transform.eulerAngles.y != 0);
            for (int i = 0; i <= 12; i++)
            {
                Vector3 temp_rot = card[i].transform.eulerAngles;
                temp_rot -= new Vector3(0, 2, 0);
                card[i].transform.eulerAngles = temp_rot;
                
            }
            if (card[0].transform.eulerAngles.y < 100 && flag == true) {
                flag = false;
                for (int i = 0; i <= 12; i++) {
                    text[i].text = "" + science[i];
                }
            
            }
            yield return new WaitForSeconds(0.01f);
        }
        //only for odd cards
        yield return new WaitForSeconds(1.0f);
        int t = 500;
        int move_ = 70;
        while (t-- > 0)
        {
            
            for (int i = 0; i < 7; i++)
            {
                
                card[i].transform.position = Vector3.MoveTowards(card[i].transform.position, position_science[i] + new Vector3(0, move_, 0), speed*Time.deltaTime);
          
            }
            for (int i = 7; i < 13; i++)
            {

                card[i].transform.position = Vector3.MoveTowards(card[i].transform.position, position_science[i] - new Vector3(0, move_, 0), speed * Time.deltaTime);

            }
            yield return new WaitForSeconds(.0001f);
            if (card[1].transform.position.y == position_science[1].y + move_)
            {
                Debug.Log(t);
                break;
            
            }
            
        }

        card[4].SetActive(true);
        card[5].SetActive(true);
        card[6].SetActive(true);
        card[7].SetActive(true);
        card[8].SetActive(true);

        yield return new WaitForSeconds(2.0f);

        Vector3[] new_pos_sci = new Vector3[5];
        new_pos_sci[0] = position_science[9] + new Vector3(0, move_, 0);
        new_pos_sci[1] = position_science[10] + new Vector3(0, move_, 0);
        new_pos_sci[2] = position_science[11] + new Vector3(0, move_, 0);
        new_pos_sci[3] = position_science[2] + new Vector3(0, -move_, 0);
        new_pos_sci[4] = position_science[3] + new Vector3(0, -move_, 0);

        t = 500;
        while (t-- > 0)
        {
            for (int i = 0; i < 5; i++)
            {
                card[i + 4].transform.position = Vector3.MoveTowards(card[i + 4].transform.position, new_pos_sci[i], speed * Time.deltaTime);

            }
            yield return new WaitForSeconds(.0001f);
            if (card[3].transform.position.x == new_pos_sci[2].x)
                break;
            Debug.Log(t);
        }

        yield return new WaitForSeconds(1.0f);

        /*t = 500;
        while (t-- > 0) 
        {
            //if(t > 420)
            //transform.Rotate(0,0,50 * Time.deltaTime);
            for (int i = 0; i < 5; i++)
            {
                Debug.Log(((i+3)%5)+1);
                card[i + 1].transform.position = Vector3.MoveTowards(card[i + 1].transform.position, position_science[((i+3)%5)+1], speed * 1.7f * Time.deltaTime);

            }
            yield return new WaitForSeconds(.0001f);
            if (card[1].transform.position.x == position_science[4].x)
            {
                while (transform.eulerAngles.z > 0)
                {
                    //transform.Rotate(0, 0, -50 * Time.deltaTime);

                    
                    yield return new WaitForSeconds(0.01f);
                }
                Debug.Log(t);
                break;
            }
        }*/


    }

}
