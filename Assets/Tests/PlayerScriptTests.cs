using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerScriptTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void TestIfMouseClickWillGenerateProjectile()
    {
        GameObject playerGameObject = GameObject.Instantiate(new GameObject());
        playerScript playerScript = playerGameObject.AddComponent<playerScript>();
        
        GameObject bulletSpawnPoint = new GameObject();
        playerScript.bulletSpawnPoint = bulletSpawnPoint.transform;

        Assert.AreEqual(0, playerScript.bulletSpawnPoint.transform.childCount); 
        
        //playerScript.OnMouseClickedEventInvoke();
        
        Assert.AreEqual(1, playerScript.bulletSpawnPoint.transform.childCount);
    }
}
