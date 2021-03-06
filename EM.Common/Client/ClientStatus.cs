﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Common.Client
{
  public class ClientStatus
  {
    public ClientStatus()
    {
      LastRun = DateTime.MinValue;
      LastLifeSign = DateTime.MinValue;
      NextRun = DateTime.MaxValue;
    }

    public DateTime LastRun { get; set; }
    public DateTime LastLifeSign { get; set; }
    public DateTime NextRun { get; set; }

    public ClientStatus Clone()
    {
      return (ClientStatus)this.MemberwiseClone();
    }
  }
}
