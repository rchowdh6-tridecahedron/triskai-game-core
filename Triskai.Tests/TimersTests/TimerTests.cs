using Xunit;
using Timer = Triskai.Core.Timer;

public class TimerTests
{
    [Fact]
    public void Timer_StartsAndStopsCorrectly()
    {
        var timer = new Timer();

        bool startCalled = false;
        bool stopCalled = false;

        timer.OnTimerStart += () => startCalled = true;
        timer.OnTimerStop += () => stopCalled = true;

        timer.Start();
        timer.Tick(1.0f);

        Assert.True(timer.IsRunning);
        Assert.Equal(1.0f, timer.ElapsedTime);
        Assert.True(startCalled);

        timer.Stop();
        Assert.False(timer.IsRunning);
        Assert.True(stopCalled);
    }
}