using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class platformMovement : MonoBehaviour
{
    public GameObject character;
    public float Rotationspeed = 150f;
    public float amplitude = 5f;
    public float frequency = 0.4f;
    int choose;
   public  bool isCanMove = true;

    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        choose = Random.Range(0, 6);
    }

    // Update is called once per frame
    void Update()
    {
        if (isCanMove&& Time.time - startTime > 3f)
        {
            ChooseMovement(choose);
        } 
       
    }
    public void Movement1()
    {

        transform.Rotate(Vector3.up, Rotationspeed * Time.deltaTime);
    }
    public void Movement2()
    {
        //sin(?)=sin(2?ft)

        float xPosition = amplitude * Mathf.Sin(2 * Mathf.PI * frequency * Time.time);
        transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);


        transform.Rotate(Vector3.up, Rotationspeed * Time.deltaTime);


    }
    public void Movement3()
    {

        float zPosition = amplitude * Mathf.Sin(2 * Mathf.PI * frequency * Time.time);
        transform.position = new Vector3(transform.position.x, transform.position.y, zPosition);
        transform.Rotate(Vector3.up, Rotationspeed * Time.deltaTime);
    }

    public void Movement4()
    {
        Vector3 offset = character.transform.position - transform.position;
        float pos = Vector3.Dot(offset, Vector3.forward);
       
        if (pos < 0)
        {
            transform.Translate(Vector3.back * 2f * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.forward * 2f * Time.deltaTime);
        }
    }

    public void Movement5()
    {

        transform.Translate(Vector3.forward * 2f * Time.deltaTime);
    }

    public void Movement6()
    {

        transform.Translate(Vector3.back * 2f * Time.deltaTime);
    }
    private void OnDrawGizmos()
    {
     
      //  Debug.DrawRay(transform.position, transform.right * 15f, Color.red, 1f);
    }


    public void ChooseMovement(int i)
    {
        switch (i)
        {
            case 0:
                Movement1();
                break;
            case 1:
                Movement2();
                break;
            case 2:
                Movement3();
                break;
            case 3:
                Movement4();
                break;
            case 4:
                Movement5();
                break;
            case 5:
                Movement6();
                break;
           
            default:
                break;
        }

    }
}
