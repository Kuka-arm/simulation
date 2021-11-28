using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone1 : MonoBehaviour
{
    private int currentColor, length;
    public LayerMask layer;
    Color[] colors = new Color[] { Color.green, Color.red, Color.blue, Color.yellow };

    public ParticleSystem slideParticles;
    void Start()
    {
        currentColor = 1; //Red
        length = colors.Length;
        GetComponent<Renderer>().material.color = colors[currentColor];
        
    }

    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;
        //    if (Physics.Raycast(ray, out hit, 100, layer))
        //    {
        //        currentColor = (currentColor + 1) % length;
        //        hit.transform.GetComponent<Renderer>().material.color = colors[currentColor];
        //    }
        //}
    }

    public static int counter = 0;

 /* //  NOT WORKING - UNABLE TO REFERENCE "Color_BLUE" IN DEFINITION
    Material ZoneMaterial;
    ZoneMaterial = Resources.Load<Material>("Color_Blue");
    MeshRenderer meshRenderer = GetComponent<MeshRenderer>();

    void Start()
    {

        // Get the current material applied on the GameObject
        Material oldMaterial = meshRenderer.material;
        Debug.Log("Zone 1 Material: " + oldMaterial.name);       
    }

    // ON CLICK change colour
    void OnMouseDown()
    {

        meshRenderer.material = ZoneMaterial;
    }
 */


    void OnTriggerEnter(Collider blockTrigger)
    {
        if (blockTrigger.transform.name == "woodenBlock(Clone)")
        {
            //Debug.Log("A block entered a placement area");
            counter += 1;
            slideParticles.Play();
        }
    }

/*
    void OnTriggerStay(Collider blockTrigger)
    {
        if (blockTrigger.transform.name == "woodenBlock(Clone)")
        {
            //Debug.Log("Block" + counter.ToString() + " has entered placement area"); //TODO Change wording, blocks do not have unique numbers
        }
    }
*/

    void OnTriggerExit(Collider blockTrigger)
    {
        if (blockTrigger.transform.name == "woodenBlock(Clone)")
        {
            //Debug.Log("Block" + counter.ToString() + "has left placement area");
            counter -= 1;
        }
    }

}
