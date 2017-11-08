using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;


public class TestThruster
{
	[Test]
	public void TestThrusterPower ()
	{
		ThrusterModel t = new ThrusterModel ();
		t.setPower (50);
		Assert.AreEqual (50, t.GetPower ());
	}

	[Test]
	public void TestThrusterMaxPower ()
	{
		ThrusterModel t = new ThrusterModel ();
		t.setPower (500);
		Assert.AreEqual (100, t.GetPower ());
	}

	[Test]
	public void TestThrusterMinPower ()
	{
		ThrusterModel t = new ThrusterModel ();
		t.setPower (-500);
		Assert.AreEqual (0, t.GetPower ());
	}

	[Test]
	public void TestThrusterOn()
	{
		ThrusterModel t = new ThrusterModel ();
		t.setOn (true);
		Assert.IsTrue (t.isOn ());
	}

	[Test]
	public void TestThrusterOff()
	{
		ThrusterModel t = new ThrusterModel ();
		Assert.IsFalse ( t.isOn ());
	}

	[Test]
	public void TestThrusterMinStrength()
	{
		ThrusterModel t = new ThrusterModel ();
		t.setStrength (0);
		Assert.AreEqual (10, t.GetForce());
	}
	[Test]
	public void TestThrusterTestForce()
	{
		ThrusterModel t = new ThrusterModel ();
		t.setStrength (20);
		t.setPower (50f);
		Assert.AreEqual (1000, t.GetForce());
	}

}
