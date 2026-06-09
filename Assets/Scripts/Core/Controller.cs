using UnityEngine;

public class Controller : Mover
{
    public KeyCode GoUpKey = KeyCode.W;
    public KeyCode GoDownKey = KeyCode.S;
    public KeyCode GoLeftKey = KeyCode.A;
    public KeyCode GoRightKey = KeyCode.D;
    public KeyCode ShootKey = KeyCode.F;
    public KeyCode ShiftUp = KeyCode.UpArrow;
    public KeyCode ShiftDown = KeyCode.DownArrow;
    public KeyCode ShiftLeft = KeyCode.LeftArrow;
    public KeyCode ShiftRight = KeyCode.RightArrow;
    public KeyCode GoSlow = KeyCode.LeftShift;
    public KeyCode GoFast = KeyCode.RightShift;
    public KeyCode Teleport = KeyCode.T;

    public int VerticalDirection = 0;
    public int HorizontalDirection = 0;
    public bool SpeedIncrease = false;
    public bool SpeedDecrease = false;
   
    protected override void Start()
    {
        base.Start(); 
    }

    void Update()
    {
        if (Input.GetKeyDown(GoUpKey)) { VerticalDirection = VerticalDirection + 1; }
        if (Input.GetKeyUp(GoUpKey)) { VerticalDirection = VerticalDirection - 1; }
        if (Input.GetKeyDown(GoDownKey)) { VerticalDirection = VerticalDirection - 1; }
        if (Input.GetKeyUp(GoDownKey)) { VerticalDirection = VerticalDirection + 1; }
        if (Input.GetKeyDown(GoLeftKey)) { HorizontalDirection = HorizontalDirection - 1; }
        if (Input.GetKeyUp(GoLeftKey)) { HorizontalDirection = HorizontalDirection + 1; }
        if (Input.GetKeyDown(GoRightKey)) { HorizontalDirection = HorizontalDirection + 1; }
        if (Input.GetKeyUp(GoRightKey)) { HorizontalDirection = HorizontalDirection - 1; }

        if (Input.GetKeyDown(GoSlow)) { SpeedDecrease = true; }
        if (Input.GetKeyUp(GoSlow)) { SpeedDecrease = false; }
        if (Input.GetKeyDown(GoFast)) { SpeedIncrease = true; }
        if (Input.GetKeyUp(GoFast)) { SpeedIncrease = false; }

        if (Input.GetKeyDown(ShiftUp)) { base.ShiftPawn(1,0); }
        if (Input.GetKeyDown(ShiftDown)) { base.ShiftPawn(-1,0); }
        if (Input.GetKeyDown(ShiftLeft)) { base.ShiftPawn(0,-1); }
        if (Input.GetKeyDown(ShiftRight)) { base.ShiftPawn(0,1); }

        if (Input.GetKeyDown(Teleport)) { base.RandomPosition(); }
        if (Input.GetKeyDown(ShootKey)) { base.MakeShot(HorizontalDirection, VerticalDirection); }

        if (VerticalDirection != 0 || HorizontalDirection != 0)
        {
            base.MovePawn(VerticalDirection, HorizontalDirection, SpeedIncrease, SpeedDecrease);
        }
    }
}
