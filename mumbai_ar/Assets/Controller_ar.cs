using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_ar : MonoBehaviour {

    public GameObject heli;

    public GameObject car_;

    Animator anim_car;



	// Use this for initialization
	void Start () {
        car_.SetActive(false);
        heli.SetActive(false);
        anim_car = car_.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.A)) {
            Debug.Log("a is pressed.");
            StartCoroutine(helicopter());
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("b is pressed.");
            StartCoroutine(car1());
        }



	}

    IEnumerator helicopter() {
        heli.SetActive(true);

        Vector3 ori_temp = heli.transform.eulerAngles;
        Vector3 pos_temp = heli.transform.position;
        
        Vector3 temp_ori = heli.transform.eulerAngles;


        this.transform.LookAt(this.transform.forward);
        for (int i = 0; i < 240; i++)
        {
            heli.transform.position += heli.transform.forward * Time.deltaTime * 200;

            if (i < 120)
            {
                temp_ori += new Vector3(0.1f, 0, 0);
                heli.transform.eulerAngles = temp_ori;
            }
            else
            {
                temp_ori -= new Vector3(0.1f, 0, 0);
                heli.transform.eulerAngles = temp_ori;

            }

            if (i % 7 == 0)
            {
                temp_ori -= new Vector3(0, 0, Random.Range(-2, 2));
                heli.transform.eulerAngles = temp_ori;
            }

            yield return new WaitForSeconds(0.00001f);
        }

        yield return new WaitForSeconds(0.005f);

        heli.transform.eulerAngles = ori_temp;
        heli.transform.position = pos_temp;

    }

    IEnumerator car() {

        car_.SetActive(true);

        Vector3 temp_pos = car_.transform.position;
        Quaternion temp_ori = car_.transform.rotation;
        int i,j,k;

        int fac = 3, fac1 = 5;

        for (i = 0; i < 320 / fac; i++)
        {
            temp_pos.x += 0.75f * fac;
            temp_pos.z -= 1 * fac;

            if (i > (320 / fac) - 45)
            {
                anim_car.SetBool("wheel_ghum", false);
                temp_ori.y -= 1 * Time.deltaTime;
            }
            //temp_pos.x += 1 * Mathf.Cos(temp_ori.y);
            //temp_pos.z += 1 * Mathf.Sin(temp_ori.y);

            car_.transform.position = temp_pos;
            car_.transform.rotation = temp_ori;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.5f);
        anim_car.SetBool("wheel_ghum", true);

/*
        for (i = 0; i < 180 / fac; i++)
        {
            temp_pos.x += 0.75f * fac;
            //temp_pos.z -= 1 * fac;

            if (i > (320 / fac) - 45)
            {
                anim_car.SetBool("wheel_ghum", false);
                temp_ori.y -= 1 * Time.deltaTime;
            }
            //temp_pos.x += 1 * Mathf.Cos(temp_ori.y);
            //temp_pos.z += 1 * Mathf.Sin(temp_ori.y);

            car_.transform.position = temp_pos;
            car_.transform.rotation = temp_ori;
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(0.5f);
        anim_car.SetBool("wheel_ghum", true);
        for (i = 0; i < 320 / fac; i++)
        {
            temp_pos.x += 0.75f * fac;
            temp_pos.z += 1 * fac;

            if (i > (320 / fac) - 45)
                temp_ori.y -= 1 * Time.deltaTime;

            //temp_pos.x += 1 * Mathf.Cos(temp_ori.y);
            //temp_pos.z += 1 * Mathf.Sin(temp_ori.y);

            car_.transform.position = temp_pos;
            car_.transform.rotation = temp_ori;
            yield return new WaitForSeconds(0.00f);
        }
        yield return new WaitForSeconds(0.5f);
        car_.SetActive(false);
        */
    }

    IEnumerator car1() {

        car_.SetActive(true);

        Vector3 ori_temp = car_.transform.eulerAngles;
        Vector3 pos_temp = car_.transform.position;

        for (int i = 0; i < 60; i++)
        {
            car_.transform.position += car_.transform.forward * Time.deltaTime * 400;
            yield return new WaitForSeconds(0.00001f);
        }

        Vector3 temp_ori = car_.transform.eulerAngles;
        for (int i = 0; i < 25; i++)
        {
            temp_ori -= new Vector3(0, 2 ,0);
            car_.transform.eulerAngles = temp_ori;
            yield return new WaitForSeconds(0.00001f);
        }

        for (int i = 0; i < 30; i++)
        {
            car_.transform.position += car_.transform.forward * Time.deltaTime * 400;
            yield return new WaitForSeconds(0.00001f);
        }

        temp_ori = car_.transform.eulerAngles;
        for (int i = 0; i < 25; i++)
        {
            temp_ori -= new Vector3(0, 2, 0);
            car_.transform.eulerAngles = temp_ori;
            yield return new WaitForSeconds(0.00001f);
        }
        for (int i = 0; i < 60; i++)
        {
            car_.transform.position += car_.transform.forward * Time.deltaTime * 400;
            yield return new WaitForSeconds(0.00001f);
        }

        yield return new WaitForSeconds(0.00f);

        heli.transform.eulerAngles = ori_temp;
        heli.transform.position = pos_temp;

    }
}
