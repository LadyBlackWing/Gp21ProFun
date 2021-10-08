using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assigment_4_Vector : ProcessingLite.GP21
{
	public Vector2 circlePosition;
	public Vector2 velocity;
	float maxSpeed = 150;
	public float diameter = 1;

	void Start()
	{
		circlePosition.x = diameter / 2 + 0.5f;
		circlePosition.y = diameter / 2 + 0.5f;
	}

	void Update()
	{
		Background(0);
		Circle(circlePosition.x, circlePosition.y, diameter);

		if (Input.GetMouseButtonDown(0))
		{
			if (MouseX > Width - 1)
			{
				circlePosition.x = Width - 1;
			}
			else if (MouseX < 1)
			{
				circlePosition.x = 1;
			}
			else
			{
				circlePosition.x = MouseX;
			}

			if (MouseY > Height - 1)
			{
				circlePosition.y = Height - 1;
			}
			else if (MouseY < 1)
			{
				circlePosition.y = 1;
			}
			else
			{
				circlePosition.y = MouseY;
			}

			velocity = Vector2.zero;
		}

		if (Input.GetMouseButton(0))
		{
			Line(circlePosition.x, circlePosition.y, MouseX, MouseY);
		}

		if (Input.GetMouseButtonUp(0))
		{
			velocity.x = MouseX - circlePosition.x;
			velocity.y = MouseY - circlePosition.y;

			if (velocity.magnitude > maxSpeed)
			{
				velocity.Normalize();
				velocity *= maxSpeed;

			}
		}

		circlePosition += velocity * Time.deltaTime;
		Bounce();

	}

	private void Bounce()
	{
		if (circlePosition.x > Width - 1 || circlePosition.x < 1)
		{
			if (velocity.x > maxSpeed)
			{
				velocity.Normalize();
				velocity.x *= -1;
			}
			else
			{
				velocity.x *= -1.1f;
			}
		}
		if (circlePosition.y > Height - 1 || circlePosition.y < 1)
		{
			velocity.y *= -1;
		}
	}

}
