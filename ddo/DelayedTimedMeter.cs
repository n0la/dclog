using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace LibDDO.Combat.DPS
{
  public enum MeterState
  {
    Stopped = 0,
    Waiting,
    Running,
  }

  public delegate void DPSMeterTickedDelegate(DelayedTimedMeter meter);
  public delegate void DPSMeterStateChangedDelegate(DelayedTimedMeter meter, MeterState ny);

  public class DelayedTimedMeter : IDPSMeter
  {
    public event DPSMeterTickedDelegate Ticked;
    public event DPSMeterStateChangedDelegate StateChanged;

    private Timer timer = new Timer();
    private MeterState state = MeterState.Stopped;
    private uint passed = 0;

    protected MeterState State
    {
      get { return state; }
      set
      {
        state = value;
        Helper.RaiseEventOnUIThread(StateChanged, new object[] { this, value});
      }
    }

    public DelayedTimedMeter()
    {
      timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
      timer.Interval = 1000.0;
    }

    void timer_Elapsed(object sender, ElapsedEventArgs e)
    {
      if (state == MeterState.Running)
      {
        ++passed;
        Helper.RaiseEventOnUIThread(Ticked, new object[] { this });
      }
    }

    public virtual void Start()
    {
      timer.Stop();
      passed = 0;
      State = MeterState.Waiting;
      timer.Start();
    }

    public virtual void Stop()
    {
      timer.Stop();
      State = MeterState.Stopped;
    }

    public virtual void DamageDone(CombatLogMessage msg)
    {
    }

    public virtual void TargetKilled(CombatLogMessage msg)
    {
    }

    public virtual double Result { get { return 0.0; } }

    public uint SecondsPassed
    {
      get { return passed; }
    }

    public TimeSpan TimePassed
    {
      get
      {
        return TimeSpan.FromSeconds(passed);
      }
    }
  }
}
