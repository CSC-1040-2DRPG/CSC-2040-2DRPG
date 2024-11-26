using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EnemyHealthTest
{
    private GameObject spawner;

    [SetUp]
    public void Setup()
    {
        spawner = new GameObject("Spawner");


    }

    [Test]
    public void SpawnerHealthTest()
    {
        // get spawner health
        float result = spawner.GetComponent<Spawner_health>().GetEnemyHealth();

        // health should be 100
        Assert.AreEqual(100, result, "The enemy health should initially be 100.");
    }

    [TearDown]
    public void TearDown()
    {
        // Clean up after the test
        Object.Destroy(spawner);
    }
}
