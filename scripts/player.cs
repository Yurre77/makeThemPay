using Godot;
using System;

public partial class player : Area2D
{
	[Export]
	//Player movement speed in pixels/second
	public int speed {get; set;} = 400;

	//screensize in pixels
	public Vector2 screenSize;

	public override void _Ready(){
		screenSize = GetViewportRect().Size;
	}

	public override void _Process(double delta){
		var velocity = Vector2.Zero;

		if(Input.IsActionPressed("move_right")){
			velocity.X += 1;
		}
		if(Input.IsActionPressed("move_left")){
			velocity.X -= 1;
		}
		if(Input.IsActionPressed("move_up")){
			velocity.Y -= 1;
		}
		if(Input.IsActionPressed("move_down")){
			velocity.Y += 1;
		}

		var animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

		if(velocity.Length() > 0){
			velocity = velocity.Normalized() * speed;
			animatedSprite2D.Play("walk");
		} else {
			animatedSprite2D.Play("default");
		}

		Position += velocity * (float)delta;
		Position = new Vector2(
			x: Mathf.Clamp(Position.X, 0, screenSize.X),
			y: Mathf.Clamp(Position.Y, 0, screenSize.Y)
		);

		if (velocity.X != 0){
    		animatedSprite2D.Animation = "walk";
    		animatedSprite2D.FlipV = false;
    		animatedSprite2D.FlipH = velocity.X < 0;
		}
		else if (velocity.Y != 0){
    		animatedSprite2D.Animation = "up";
    		animatedSprite2D.FlipV = velocity.Y > 0;
		}
	}
}
