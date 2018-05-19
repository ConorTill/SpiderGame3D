using Assets.Scripts.Units;
using Assets.Scripts.Units.Spiders;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Selection
{
    public class SelectedUnits
    {
        public List<GameObject> selectedUnits;

        public SelectedUnits()
        {
            selectedUnits = new List<GameObject>();
        }

        public void add(GameObject selectedUnit)
        {
            if (!selectedUnit.GetComponent<SelectableComponent>())
                return;
            if (selectedUnits.Contains(selectedUnit))
            {
                remove(selectedUnit);
                return;
            }
            selectedUnits.Add(selectedUnit);
            selectedUnit.GetComponent<SelectableComponent>().selected = true;
        }

        public void remove(GameObject selectedUnit)
        {
            if (selectedUnits.Contains(selectedUnit))
            {
                selectedUnits.Remove(selectedUnit);
                selectedUnit.GetComponent<SelectableComponent>().selected = false;
            }
        }

        public bool contains(GameObject selectedUnit)
        {
            return selectedUnits.Contains(selectedUnit);
        }

        public void deselectAll()
        {
            foreach(GameObject selectedUnit in selectedUnits)
            {
                selectedUnit.GetComponent<SelectableComponent>().selected = false;
            }
            selectedUnits.Clear();
        }
    }
}
