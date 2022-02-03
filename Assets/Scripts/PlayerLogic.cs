public class PlayerLogic
{
	public int playerHealth = 100;
	public bool death;
	public float bulletForce = 5f;
	public float aliveTime = 0f;

	public void UpdateAliveTime(float deltaTime)
	{
		aliveTime += deltaTime;
	}
}