using Godot;

public partial class Torpedo : Projectile
{
	[Export] public float VisualRotationSpeed = 0.05f;
	[Export] public float VisualRotationSpeedMax = 10;
	[Export] public double TimeToArm{get{return armTimer.WaitTime;} private set{armTimer.WaitTime = value;}}
	public float Acceleration = 100;
	public bool IsArmed  = false;
	public Node2D Target;
	private Timer armTimer = new Timer();
	private Node2D visuals;
	[Export] private AudioStream destroyedAudioSteam;
	[Export] private AudioStream explodedAudioSteam;

    public override void _EnterTree()
    {
		base._EnterTree();
		visuals = GetChild<Node2D>(2);
		armTimer.OneShot = true;
		armTimer.Timeout += OnArmTimerTimeout;
		AddChild(armTimer);
		armTimer.Start();
	}

    private void OnArmTimerTimeout()
    {
        IsArmed = true;
    }

	public void Shoot(float lifeTime, Vector2 velocilty, Node2D target, bool playerTeam){
		Shoot(lifeTime, velocilty, playerTeam);
		Target = target;
	}

    public override void _Process(double delta)
	{
		visuals.Rotation += (float)delta * Mathf.Clamp(Velocity.Length() * VisualRotationSpeed, 0, VisualRotationSpeedMax);

		if(!IsArmed){
			return;
		}
		
		if(Target == null){
			return;
		}

		if(!IsInstanceValid(Target)){
			return;
		}
		Velocity = (Target.GlobalPosition - GlobalPosition).Normalized() * (Velocity.Length()+ (Acceleration * (float)delta));
	}
}