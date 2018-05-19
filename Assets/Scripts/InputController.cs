using Assets.Scripts.Factories;
using Assets.Scripts.Selection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

    private SelectedUnits selectedUnits;
    public SpiderFactory spiderFactory;

	// Use this for initialization
	void Start () {
        selectedUnits = new SelectedUnits();
	}

    private void FixedUpdate()
    {

    }

    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                selectedUnits.add(hitObject);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if (hit.transform.gameObject.GetComponent<HealthComponent>())
                {
                    //Attack Logic
                    foreach (GameObject unit in selectedUnits.selectedUnits)
                    {
                        unit.GetComponent<AttackComponent>().acquireTarget(hit.transform.gameObject);
                    }
                }
                else
                {
                    foreach (GameObject unit in selectedUnits.selectedUnits)
                    {
                        unit.GetComponent<NavigationComponent>().setDestination(hit.point);
                        unit.GetComponent<AttackComponent>().target = null;
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                spiderFactory.createSpider(hit.point);
            }
        }
    }
}
