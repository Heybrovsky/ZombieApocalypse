public class PlayerLogic
{
	public int PlayerHealth = 100;
	public bool Death;
	public float BulletForce = 40f;
	public float AliveTime = 0f;
	public int BulletDamage = 75;

	public void UpdateAliveTime(float deltaTime)
	{
		AliveTime += deltaTime;
	}
}