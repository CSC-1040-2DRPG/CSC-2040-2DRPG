using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MyTest
{

    [SetUp]
    public void Setup()
    {
        GameObject testObject = new GameObject();
        //I cannot get our custom classes to load in a test class.
        DataPersistanceManager dataManager = new DataPersistanceManager();
    }

    [Test]
    public void AddTwoNumbersTest()
    {
        int result = 1 + 1;
        Assert.AreEqual(2, result);
    }

    [Test]
    public void SubtractTwoNumbersTest()
    {
        int result = 5 - 3;
        Assert.AreEqual(2, result);
    }

    [UnityTest]
    public void test1(){
    }

}