using Assets.Scripts.Units.Spiders;
using UnityEngine;

namespace Assets.Scripts.Factories
{
    public class SpiderFactory : MonoBehaviour
    {
        public GameObject prefab;
        public SpidersList spiderList;

        public void createSpider(Vector3 pos)
        {
            GameObject spider = Instantiate(prefab) as GameObject;
            spider.transform.position = pos;
            //spiderList.addSpider(spider);
        }
    }
}
