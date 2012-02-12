using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibDDO.Combat
{
  public interface ILanguageParser
  {
    bool Parse(CombatLogMessage msg);
  }
}
