using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using System.Timers;
public class ship_controller : tickable
{
    public enum rotation_system
    {
        buttons,
        wheel
    }
    public float speed = 10f;

    public int movedir = 1;
    public float rotationSpeed = 100f;

    public rotation_system system_we_have = rotation_system.buttons;

    bool isTurningLeft = false;
    bool isMoveForward = false;
    bool isTurningRight = false;

    public AudioSource click_sound;
    public AudioSource engine_works;

    bool playing = false;
    float remember_timing;
    public float smoothSpeed = 0.25f;
    public Vector3 offset = new Vector3(0,0);

    public Vector3 initial_rotate = Vector3.zero;
    Camera c;

    public TrailRenderer trail_ref;
    public override void Init()
    {
        c = FindAnyObjectByType<Camera>();
        trail_status(false);
        base.Init();
    }

    public void set_spawnpoint(spawner spawn_here)
    {
        gameObject.transform.position = spawn_here.transform.position;
    }

    public void MoveForward()
    {
        click_sound.Play();
        

        isMoveForward = !isMoveForward;
        if(isMoveForward)
        {
            g.charges_we_have--;
            if(g.charges_we_have < 0)
            {
                g.on_lose();
                return;
            }
        }
        engine_status();
        g.update_info();        
    }

    public void TurnLeft()
    {
        click_sound.Play();
        isTurningLeft = !isTurningLeft;
        engine_status();
    }

    public void TurnRight()
    {
        click_sound.Play();
        isTurningRight = !isTurningRight;
        engine_status();
    }

    public void stop_ship()
    {
        if(g.rlb.isclicked) g.rlb.change_button_icon();
        if(g.rrb.isclicked) g.rrb.change_button_icon();
        if(g.mub.isclicked) g.mub.change_button_icon();
        g.charges_we_have = g.max_charges;
        isTurningRight = isTurningLeft = isMoveForward = false;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        engine_status();
    }
    public void engine_status()
    {
        if (isTurningRight || isTurningLeft || isMoveForward)
        {
            if(playing) return;
            engine_works.time = remember_timing;
            if(engine_works.clip != null && engine_works.time >= 0 && engine_works.time <= engine_works.clip.length)
            {
                engine_works.Play();
            }
            trail_status(true);
            playing = true;
        }
        else
        {
            remember_timing = engine_works.time;
            engine_works.Stop();
            trail_status(false);
            playing = false;
        }
    }

    void trail_status(bool do_trail)
    {   
        if(do_trail)
        {
            trail_ref.GetComponent<Renderer>().material.DOFade(1f, 0.5f);
        }
        else
        {
            trail_ref.GetComponent<Renderer>().material.DOFade(0f, 0.5f);
        }
    }

    public override void Tick()
    {
        if(isMoveForward)
        {
            transform.Translate(Vector3.up * speed * movedir * Time.deltaTime);
        }
        check_rotate();

        Vector3 desiredPosition = transform.position + offset;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        smoothedPosition.z = -100;
        c.transform.position = smoothedPosition;
    }

    public void change_move_dir(bool is_forward)
        {
            if(is_forward)
                {
                    movedir = 1;    
                }
            else
                {
                    movedir = -1;
                }
        }
        
    void check_rotate()
    {
        switch(system_we_have)
        {
            case rotation_system.buttons:
                if(isTurningRight)
                {
                    transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime);
                }
                if(isTurningLeft)
                {
                    transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
                }
                return;
            case rotation_system.wheel:
                transform.Rotate(0f, 0f, g.w.get_angel() * Time.deltaTime);
                return;
        }   
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.GetComponent<die_on_bump>())
        {
            g.on_lose();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<finish>())
        {
            g.station_entered();
        }
        if(other.gameObject.GetComponent<collectable>())
        {
            g.collect_box(other.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<finish>())
        {
    
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<finish>())
        {
    
            
        }
    }
}
