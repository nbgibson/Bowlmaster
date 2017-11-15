using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

[TestFixture]
public class ActionMasterTest
{
    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;

    [Test]
    public void PassingTest()
    {
        Assert.AreEqual(1, 1);
    }    

    [Test]
    public void T01OneStrikeReturnsEndTurn()
    {
        ActionMaster actionMaster = new ActionMaster();
        Assert.AreEqual(endTurn, actionMaster.Bowl(10));
    }
}