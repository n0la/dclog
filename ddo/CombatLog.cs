using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibDDO.Combat
{
  public class CombatLog
  {
    private List<CombatLogMessage> combatlog = new List<CombatLogMessage>();
    private ILanguageParser parser = null;

    public CombatLog()
    {
      parser = new EnglishCombatLog();
    }

    public CombatLog(ILanguageParser p)
    {
      parser = p;
    }

    public List<CombatLogMessage> Messages
    {
      get { return combatlog; }
    }

    public void Add(CombatLogMessage msg)
    {
      // Parse the combat log and add it regardless.
      parser.Parse(msg);
      combatlog.Add(msg);
    }
  }
}
