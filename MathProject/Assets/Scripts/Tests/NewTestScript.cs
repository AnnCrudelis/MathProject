using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


namespace Tests
{
    public class NewTestScript
    {
        //Enemy enemyScript;

        //private Spawner spawnerScript;
        private Bullet bulletScript;
        private Enemy enemyScript;
        private PlayerController playerScript;
        private Gun gunScript;
        private GameObject bulletGO;

        [SetUp]
        public void Setup()
        {
            GameObject enemyGO = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Enemy"));
            enemyScript = enemyGO.GetComponent<Enemy>();
            bulletGO = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Bullet"));
            bulletScript = bulletGO.GetComponent<Bullet>();
            //GameObject playerGO = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Player"));
            //playerScript = playerGO.GetComponent<PlayerController>();
            //gunScript = playerGO.GetComponentInChildren<Gun>();

        }

        [TearDown]
        public void Teardown()
        {
            //Object.Destroy(spawnerScript.gameObject);

        }


        [UnityTest]
        public IEnumerator DestroyOfABulletByAnEnemy()
        {
            GameObject enemy = MonoBehaviour.Instantiate(enemyScript.gameObject);
            enemy.transform.position = Vector3.zero;
            //GameObject bullet = MonoBehaviour.Instantiate(bulletGO);
            yield return new WaitForSeconds(0.1f);

            UnityEngine.Assertions.Assert.IsNull(bulletGO);
        }

        [UnityTest]
        public IEnumerator PlayerGetDamage()
        {
            GameObject enemy = MonoBehaviour.Instantiate(enemyScript.gameObject);
            enemy.transform.position = Vector3.zero;
            //GameObject bullet = MonoBehaviour.Instantiate(bulletGO);
            yield return new WaitForSeconds(0.1f);

            UnityEngine.Assertions.Assert.IsNull(bulletGO);
        }
        [UnityTest]
        public IEnumerator PlayerGetChangeGunBuff()
        {
            GameObject enemy = MonoBehaviour.Instantiate(enemyScript.gameObject);
            enemy.transform.position = Vector3.zero;
            //GameObject bullet = MonoBehaviour.Instantiate(bulletGO);
            yield return new WaitForSeconds(0.1f);

            UnityEngine.Assertions.Assert.IsNull(bulletGO);
        }


        //    [UnityTest]
        // public IEnumerator NewTestScriptWithEnumeratorPasses()
        // {
        //     GameObject enemy = enemyScript.gameObject;
        //     enemy.transform.position = Vector3.zero;
        //     GameObject bullet = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Bullet"));
        //     bullet.transform.position = Vector3.zero;
        //     yield return new WaitForSeconds(0.1f);

        //     UnityEngine.Assertions.Assert.IsNull(bullet);
        // }
    }
}