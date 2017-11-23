using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestcontroll : MonoBehaviour {

    public GameObject smoke;
    public GameObject lamp;
    public GameObject dino;

    private int dino_flag = 0;

	// Use this for initialization
	void Start () {
        smoke.SetActive(false);
        lamp.SetActive(false);
        dino.SetActive(false);
        dino_flag = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("Space is pressed");

            Vector3 temp = transform.eulerAngles;
            temp -= new Vector3(50, 0, 0);
            transform.eulerAngles = temp;

            StartCoroutine(chest_top_open());

        }

        if (Input.GetKeyDown(KeyCode.Z)) {

            smoke.SetActive(false);
            
        }

        if (Input.GetKeyDown(KeyCode.D) && dino_flag == 1) {

            StartCoroutine(dino_());
        
        }

	}

    IEnumerator chest_top_open() {

        smoke.SetActive(true);
        lamp.SetActive(true);

        yield return new WaitForSeconds(3f);

        Vector3 temp = smoke.transform.position;
        Vector3 temp_lamp = lamp.transform.position;
        Vector3 temp_lamp_ori = lamp.transform.eulerAngles;
        Vector3 temp_lamp_size = lamp.transform.localScale;

        for (int i = 0; i < 40; i++) {
            temp.y += 1;
            smoke.transform.position = temp;
            temp_lamp.y += 2f;
            
            if (temp_lamp_size == new Vector3(1.5f, 1.5f, 1.5f))
                break;
            else {
                temp_lamp_size += new Vector3(.1f, .1f, .1f);
                lamp.transform.localScale = temp_lamp_size;
            
            }

            lamp.transform.position = temp_lamp;
            yield return new WaitForSeconds(0.1f);

        }

        for (int i = 0;i < 195 ; i++) {
            //lamp.transform.Rotate(0, 500, 0);
            //lamp.transform.Rotate();
            temp_lamp_ori += new Vector3(0, 0, 2);
            lamp.transform.eulerAngles = temp_lamp_ori;

            if (i > 150 && i < 190)
            {
                temp.y -= 1;
                smoke.transform.position = temp;
            }

         /*   temp_lamp_size += new Vector3(.1f, .1f, .1f);
            lamp.transform.localScale = temp_lamp_size;

            if (temp_lamp_size == new Vector3(2, 2, 2))
                break;
            */
            yield return new WaitForSeconds(0.05f);
            dino_flag = 1;
        }


        //lamp.transform.eulerAngles = new Vector3(-90, 90, 90);

    }

    IEnumerator dino_() {


        
        Vector3 temp = smoke.transform.position;
        Vector3 temp_size_dino = dino.transform.localScale;
        for (int i = 0; i < 50; i++)
        {
            temp.y += 1;
            smoke.transform.position = temp;

            temp_size_dino += new Vector3(0.25f, 0.25f, 0.25f);
            dino.transform.localScale = temp_size_dino;
            
            yield return new WaitForSeconds(0.05f);

        }
        lamp.SetActive(false);
        smoke.SetActive(false);
        dino.SetActive(true);

        Vector3 temp_dino = dino.transform.position;
        for (int i = 0; i < 6; i++)
        {
            temp_dino += new Vector3(0.5f, 0, 0);
            dino.transform.position = temp_dino;
            yield return new WaitForSeconds(1.0f);

        }


        yield return new WaitForSeconds(0.05f);
    }
}
