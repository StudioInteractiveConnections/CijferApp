using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
	public abstract void Enter(Guard guard);
	public abstract void Execute(Guard guard);
	public abstract void Exit(Guard guard);
}

public class StatePatrol : State {

	private bool csp;

	public override void Enter(Guard guard)
    {
		Debug.Log("Start patrolling!!!");
	}

	public override void Execute(Guard guard)
	{
		csp = guard.GetCanSee();
		Debug.Log("Patrolling!!!");
		Debug.Log(guard);
		guard.Move();

		if (csp)
        {
			Exit(guard);
        }
	}

	public override void Exit(Guard guard)
	{
		guard.SwitchState(new StateFollow());
	}
}

public class StateFollow : State
{
	private bool csp;
	private bool cap;

	public override void Enter(Guard guard)
	{

	}

	public override void Execute(Guard guard)
	{
		csp = guard.GetCanSee();
		cap = guard.GetArrest();
		guard.MoveToPlayer();

		if (!csp || cap)
        {
			Exit(guard);
        }
	}

	public override void Exit(Guard guard)
	{
		if (!csp)
		{
			guard.SwitchState(new StatePatrol());
		}
		else if (cap)
        {
			guard.SwitchState(new StateArrest());
		}
	}
}

public class StateArrest : State
{
	public override void Enter(Guard guard)
	{
		Debug.Log("Arresting thief!!!");
	}

	public override void Execute(Guard guard)
	{
		Debug.Log("Arresting thief!!!");
		// play arrest animation
	}

	public override void Exit(Guard guard)
	{

	}
}