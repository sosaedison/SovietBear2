using UnityEngine;
using System.Collections;

public class FinalBossCombat : BossCombat {

    public GameObject chainsaw;
    public GameObject laserEye;

    bool secondPhase;
    bool shouldShootFire;

    //rotation lerp
    Vector3 startRot;
    Vector3 endRot;
    float startTime = 0;
    public float swingSpeed;
    float totalRot;
    float lerpTime;
    float pauseStartTime;
    float pauseEndTime;

    // Use this for initialization
    new void Start () {
        base.Start();
        mainAttacks = 3;
        nearDeathAttacks = 4;
    }
	
	// Update is called once per frame
	void Update () {
        if (!LevelManager.isPaused())
        {
            if (attacking)
            {
                if (attackIndex == 3)
                {
                    Vector2 direction = player.transform.position - chainsaw.transform.position;
                    float angle = Vector2.Angle(direction.normalized, Vector2.right);
                    float sign = 1.0f;
                    if (direction.y < 0) sign = -1.0f;
                    angle *= sign;
                    chainsaw.transform.rotation = Quaternion.Euler(0, 0, angle);
                    if (Time.time - startTime > 3)
                    {
                        attacking = false;
                        chainsaw.transform.rotation = Quaternion.Euler(Vector3.zero);
                    }
                }
                else
                {
                    float currentTime = Time.time - startTime - (pauseEndTime - pauseStartTime);
                    chainsaw.transform.rotation = Quaternion.Euler(Vector3.Lerp(startRot, endRot, currentTime / lerpTime));
                    if (currentTime >= lerpTime)
                    {
                        if (endRot == Vector3.zero)
                        {
                            attacking = false;
                            shouldShootFire = false;
                        }
                        else
                        {
                            if (secondPhase)
                                shouldShootFire = true;
                            startRot = endRot;
                            endRot = Vector3.zero;
                            totalRot = Vector3.Distance(startRot, endRot);
                            lerpTime = totalRot / swingSpeed;
                            startTime = Time.time;

                        }
                    }
                }
                chainsaw.GetComponent<Flamethrowing>().bulletOffset = new Vector2(Mathf.Cos(chainsaw.transform.rotation.eulerAngles.z / 180 * Mathf.PI) * 85f, Mathf.Sin(chainsaw.transform.rotation.eulerAngles.z / 180 * Mathf.PI) * 85f);
               
            }
        }
	}

    new void FixedUpdate()
    {
        base.FixedUpdate();
        if (!LevelManager.isPaused())
        {
            if (attacking && attackIndex == 3)
            {
                
                    
            }
            if (attacking && shouldShootFire)
                chainsaw.GetComponent<Flamethrowing>().AutoShoot(Vector2.right);
            
        }
    }

    protected override void Attack(bool nearDeath)
    {
        base.Attack(nearDeath);
        secondPhase = nearDeath;
        if (!attacking)
        {
            attacking = true;
            shouldShootFire = false;
            if (attackIndex == 0) //laser fire
            {
                attacking = false;
                Vector2 direction = player.transform.position - laserEye.transform.position;
                laserEye.GetComponent<Weapon>().FireBullet(direction);
            }
            else if (attackIndex == 1 || attackIndex == 2) //swing up
            {
                startRot = Vector3.zero;
                endRot = new Vector3(0, 0, 90f);
                if (attackIndex == 2)
                    endRot *= -1f;
                totalRot = Vector3.Distance(startRot, endRot);
                lerpTime = totalRot / swingSpeed;
                startTime = Time.time;
            }
            else if (attackIndex == 3) //shoot fire
            {
                shouldShootFire = true;
                startTime = Time.time;
            }
        }
    }

    void OnPause()
    {
        pauseStartTime = Time.time;
    }

    void OnUnpause()
    {
        pauseEndTime = Time.time;
        if (pauseStartTime == 0)
            pauseEndTime = 0;
    }

    void OnEnable()
    {
        LevelManager.OnPause += OnPause;
        LevelManager.OnUnpause += OnUnpause;
    }

    void OnDisable()
    {
        LevelManager.OnPause -= OnPause;
        LevelManager.OnUnpause -= OnUnpause;
    }
}
