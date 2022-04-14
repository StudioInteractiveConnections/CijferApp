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
	public override void Enter(Guard guard)
    {
		Debug.Log("Start patrolling!!!");
	}

	public override void Execute(Guard guard)
	{
		Debug.Log("Patrolling!!!");
		Debug.Log(guard);
		guard.Move();

		if (guard.canSeePlayer)
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
	public override void Enter(Guard guard)
	{
		Debug.Log("Following thief!!!");
	}

	public override void Execute(Guard guard)
	{
		Debug.Log("xxxx");
		guard.MoveToPlayer();

		if (!guard.canSeePlayer)
        {
			Exit(guard);
        }
	}

	public override void Exit(Guard guard)
	{
		guard.SwitchState(new StatePatrol());
	}
}

public class StateArrest : State
{
	public override void Enter(Guard guard)
	{

	}

	public override void Execute(Guard guard)
	{

	}

	public override void Exit(Guard guard)
	{

	}
}