
using LivePlay.Models.Enum;

namespace LivePlay.Services;

internal class ActionTimer(DirectionAction directionTimer, Action<object?>? periodAction = null, Action? endAction = null)
{
    private Thread? TimerThread;
    private Timer? SendCodeTimer;
    private readonly Action<object?>? PeriodAction = periodAction;
    private readonly Action? EndAction = endAction;
    private readonly DirectionAction DirectionTimer = directionTimer;
    private volatile bool StopThreadSignal = true;
    public int Seconds { get; private set; }

    public void Start(int seconds, int periodicTic)
    {
        Seconds = seconds;
        TimerThread = new Thread(new ParameterizedThreadStart((obj) => { StartThread(periodicTic); }));
        TimerThread.Start();
    }

    public void Stop()
    {
        if (TimerThread?.IsAlive ?? false)
            StopThreadSignal = false;
    }

    private void StartThread(int periodicTic)
    {
        SendCodeTimer = new(new(HandleTimer), PeriodAction, 0, periodicTic);
        while (Seconds > 0 && StopThreadSignal)
            Thread.Sleep(250);
        StopThreadSignal = false;
        StopThread();
    }

    private void StopThread()
    {
        SendCodeTimer?.Dispose();
        Application.Current!.Dispatcher.Dispatch(() =>
        {
            EndAction?.Invoke();
        });
    }

    private void HandleTimer(object? obj)
    {
        if (obj is Action<object?> act)
            Application.Current!.Dispatcher.Dispatch(() =>
            {
                act(Seconds);
            });
        Seconds += (DirectionTimer == DirectionAction.Down) ? -1 : 1;
    }
}
