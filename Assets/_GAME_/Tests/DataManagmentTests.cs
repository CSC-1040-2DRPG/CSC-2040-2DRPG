
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataPersistenceManagerTests : MonoBehaviour
{
    [Test]
    public void SingletonInitializationTest()
    {
        // Arrange
        GameObject obj = new GameObject();
        DataPer manager = obj.AddComponent<DataPesistenceManager>();
        
        // Act
        var instance = DataPesistenceManager.instance;
        
        // Assert
        Assert.IsNotNull(instance, "Instance should be initialized.");
        Assert.AreEqual(manager, instance, "The instance should refer to the correct object.");
    }
}
