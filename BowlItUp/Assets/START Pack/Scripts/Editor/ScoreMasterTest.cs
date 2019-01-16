using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;

[TestFixture]
public class ScoreTest
{
	private ActionMaster.Action endturn=ActionMaster.Action.EndTurn;
	private ActionMaster.Action tidy=ActionMaster.Action.Tidy;
	private ActionMaster.Action reset=ActionMaster.Action.Reset;
	private ActionMaster.Action endgame=ActionMaster.Action.EndGame;
	private List<int> pinfalls=new List<int>();

    [Test]
    public void PassingTest()
    {
        Assert.AreEqual(1, 1);
    }

	[Test]
	public void T01OneStrikeReturnsEndTurn()
	{
		ActionMaster actionMAster = new ActionMaster ();
		pinfalls.Add (10);
		Assert.AreEqual (endturn, ActionMaster.NextAction(pinfalls));
	}
	[Test]
	public void T02Bowl8ReturnsTidy()
	{
		ActionMaster actionMAster = new ActionMaster ();
		pinfalls.Add (8);
		Assert.AreEqual (tidy, ActionMaster.NextAction(pinfalls));
	}
	[Test]
	public void T03Bowl28SpareReturnsEndTurn()
	{
		ActionMaster actionMAster = new ActionMaster ();
		int[] rolls = { 2, 8 };
		Assert.AreEqual (endturn,ActionMaster.NextAction(rolls.ToList()));
	}
	[Test]
	public void T04CheckResetAtStrikeInLastFrame()
	{
		ActionMaster actionMAster = new ActionMaster ();
		int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,10 };
		Assert.AreEqual (reset,ActionMaster.NextAction(rolls.ToList()));
	}
	[Test]
	public void T05CheckResetAtSpareInLastFrame()
	{
		ActionMaster actionMAster = new ActionMaster ();
		int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1,9 };
		Assert.AreEqual (reset, ActionMaster.NextAction(rolls.ToList()));
	}
	[Test]
	public void T06YoutubeRollsEndInEndGame()
	{
		ActionMaster actionMAster = new ActionMaster ();
		int[] rolls = { 8,2,7,3,3,4,10,2,8,10,10,8,0,10,8,2,9 };
		Assert.AreEqual (endgame, ActionMaster.NextAction(rolls.ToList()));

	}
	[Test]
	public void T07GAmeEndsAtBowl20()
	{
		ActionMaster actionMAster = new ActionMaster ();
		int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1,1 };
		Assert.AreEqual (endgame, ActionMaster.NextAction(rolls.ToList()));
	}
	[Test]
	public void T08DarylBowlTest()
	{
		ActionMaster actionMAster = new ActionMaster ();
		int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,10,5 };
		Assert.AreEqual (tidy,ActionMaster.NextAction(rolls.ToList()));
	}
	[Test]
	public void T09BBEnsBowl20Test()
	{
		ActionMaster actionMAster = new ActionMaster ();
		int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,10,5 };
		Assert.AreEqual (tidy, ActionMaster.NextAction(rolls.ToList()));
	}
	[Test]
	public void T10NAthanBowlIndexTest()
	{
		ActionMaster actionMAster = new ActionMaster ();
		int[] rolls = {0,10,5,1 };
		Assert.AreEqual (endturn, ActionMaster.NextAction(rolls.ToList()));
	}
	[Test]
	public void T11Dondi10thFrameTurkey () {
		ActionMaster actionMAster = new ActionMaster ();
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1,10,10,10};
		Assert.AreEqual (endgame, ActionMaster.NextAction(rolls.ToList()));
	}
	[Test]
	public void T12ZeroOneGivesEndTurn(){
		ActionMaster actionMAster = new ActionMaster ();
		int[] rolls = { 0, 1 };
		Assert.AreEqual (endturn, ActionMaster.NextAction(rolls.ToList()));
	}
}