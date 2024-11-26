using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EnemyHealthTest
{
    private GameObject spawner;

    [SetUp]
    public void Setup()
    {
        // Load the spawner prefab from your project's Resources folder
        spawner = Object.Instantiate(Resources.Load<GameObject>("Spawner"));

        // Ensure the prefab has the Spawner_health component
       // Assert.IsNotNull(spawner.GetComponent<Spawner_health>(), "The spawner prefab must have the Spawner_health script.");
    }

    [Test]
    public void SpawnerHealthTest()
    {
        // Act: Get Spawner health from the Spawner_health component
       // float result = spawner.GetComponent<Spawner_health>().GetEnemyHealth();

        
        Assert.AreEqual(100, result, "The enemy health should initially be 100.");
    }

    [TearDown]
    public void TearDown()
    {
        // Clean up the instantiated spawner after the test
        Object.Destroy(spawner);
    }
}
