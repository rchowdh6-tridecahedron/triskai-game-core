using Xunit;
using Triskai.Core;
using Timer = Triskai.Core.Timer;

public class TimerManagerTests
{
    [Fact]
    public void TimerManager_HandlesTimers()
    {
        var manager = new TimerManager();

        // we need new Timers
        Timer[] timers = new Timer[4]
        {
            new Timer(),
            new Timer(),
            new Timer(),
            new Timer()
        };

        // register all of the timers.
        for (int i = 0; i < timers.Length; i++)
        {
            manager.Register(timers[i]);
        }

        // check if all of the timers have received an id and has been
        // properly added
        bool timer0IdExists, timer1IdExists, timer2IdExists, timer3IdExists;

        timer0IdExists = manager.GetObject(timers[0].Id, out var timer0);
        timer1IdExists = manager.GetObject(timers[1].Id, out var timer1);
        timer2IdExists = manager.GetObject(timers[2].Id, out var timer2);
        timer3IdExists = manager.GetObject(timers[3].Id, out var timer3);

        // check if Ids exists
        Assert.True(timer0IdExists);
        Assert.True(timer1IdExists);
        Assert.True(timer2IdExists);
        Assert.True(timer3IdExists);

        // check if timers are equal.
        Assert.Equal(timers[0], timer0);
        Assert.Equal(timers[1], timer1);
        Assert.Equal(timers[2], timer2);
        Assert.Equal(timers[3], timer3);

        // start all timers
        manager.Start();

        // Tick
        manager.Tick(1.0f);

        // check is running
        Assert.True(timer0.IsRunning);
        Assert.True(timer1.IsRunning);
        Assert.True(timer2.IsRunning);
        Assert.True(timer3.IsRunning);

        // check 
        Assert.Equal(1.0f, timer0.ElapsedTime);
        Assert.Equal(1.0f, timer1.ElapsedTime);
        Assert.Equal(1.0f, timer2.ElapsedTime);
        Assert.Equal(1.0f, timer3.ElapsedTime);


        // stop all timers
        manager.Stop();

        Assert.False(timer0.IsRunning);
        Assert.False(timer1.IsRunning);
        Assert.False(timer2.IsRunning);
        Assert.False(timer3.IsRunning);
    }
}