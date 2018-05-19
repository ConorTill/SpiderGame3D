using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Units.Spiders
{
    public class SpidersList
    {
        public List<GameObject> spidersList;

        public SpidersList()
        {
            spidersList = new List<GameObject>();
        }

        public void addSpider(GameObject spider)
        {
            spidersList.Add(spider);
        }

        public void deleteDead()
        {
            foreach(var spider in spidersList)
            {
                if (!spider.GetComponent<HealthComponent>().alive)
                {
                    spidersList.Remove(spider);
                }
            }
        }

        public bool contains(GameObject spider)
        {
            return spidersList.Contains(spider);
        }

        public void remove(GameObject spider)
        {
            spidersList.Remove(spider);
        }

        public void Update()
        {
            deleteDead();
        }
    }
}
