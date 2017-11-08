using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class TestAutopilot
{
	[Test]
	public void TestAutopilotOn(){
		AutopilotModel ap = new AutopilotModel ();
		ap.setAutopilotOn (true);
		Assert.IsTrue (ap.isAutopilotOn ());
	}

	[Test]
	public void TestAutopilotOff(){
		AutopilotModel ap = new AutopilotModel ();
		ap.setAutopilotOn (true);
		ap.setAutopilotOn (false);
		Assert.IsFalse (ap.isAutopilotOn ());
	}

	[Test]
	public void TestAutopilotHeading(){
		AutopilotModel ap = new AutopilotModel ();
		ap.setTargetHeading (120f);
		Assert.AreEqual ( 120f, ap.getTargetHeading());
	}

	[Test]
	public void TestAutopilotHeadingLessThanZero(){
		AutopilotModel ap = new AutopilotModel ();
		ap.setTargetHeading (-10f);
		Assert.AreEqual ( 350f, ap.getTargetHeading());
	}
	[Test]
	public void TestAutopilotHeadingAbove360(){
		AutopilotModel ap = new AutopilotModel ();
		ap.setTargetHeading (400f);
		Assert.AreEqual ( 40f, ap.getTargetHeading());
	}
}
