
using LivePlay.Front.Core.Enums;

namespace LivePlay.Front.Infrastructure;

public class ActionTimer
{
    private Thread? TimerThread;
    private Timer? BaseTimer;
    private readonly Action<object?>? PeriodAction;
    private readonly Action? EndAction;
    private readonly DirectionAction DirectionTimer;

    public int StartMilliseconds { get; private set; }
    public int FinalMilliseconds { get; private set; }

    public CancellationTokenSource StopThreadTokenSourse { get; private set; }
    public CancellationToken StopThreadToken { get; private set; }

    public ActionTimer(DirectionAction directionTimer, Action<object?>? periodAction = null, Action? endAction = null)
    {
        PeriodAction = periodAction;
        EndAction = endAction;
        DirectionTimer = directionTimer;

        StopThreadTokenSourse = new CancellationTokenSource();
        StopThreadToken = StopThreadTokenSourse.Token;
    }


    public void Start(int startMilliseconds, int finalMilliseconds, int periodicTicMilliseconds = 1000)
    {
        StartMilliseconds = startMilliseconds;
        FinalMilliseconds = finalMilliseconds;
        TimerThread = new Thread(new ParameterizedThreadStart((obj) => { DoTimerThread(periodicTicMilliseconds); }));         // INFO: нужно ли передовать токен
        TimerThread.Start();
    }

    public void Stop()
    {
        if (TimerThread?.IsAlive ?? false)
            StopThreadTokenSourse.Cancel();
    }

    private void DoTimerThread(int periodicTicMilliseconds)
    {
        BaseTimer = new(new(HandleTimer), PeriodAction, 0, periodicTicMilliseconds);
        while (StartMilliseconds > FinalMilliseconds && !StopThreadToken.IsCancellationRequested)
            Thread.Sleep(250);
        StopThread();
    }

    private void StopThread()
    {
        BaseTimer?.Dispose();
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
                act(StartMilliseconds);
            });
        StartMilliseconds += (DirectionTimer == DirectionAction.Down) ? -1000 : 1000;
    }
}
