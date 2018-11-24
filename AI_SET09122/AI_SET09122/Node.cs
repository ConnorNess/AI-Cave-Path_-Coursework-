﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_SET09122
{
    class Node
    {
        public int X_coord { get; set; }
        public int Y_coord { get; set; }


        public bool beginNode = false;
        public bool endNode = false;
        public int caveid { get; set; }

        public double G { get; set; }
        public double H { get; set; }
        public double F { get; set; }

        public NodeState state { get; set; }
        public Node parentNode { get; set; }
        public void calcF()
        {
            F = G + H;
        }
    }

    public enum NodeState { Untested, Open, Closed}
}
