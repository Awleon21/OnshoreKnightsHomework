namespace IntelligentVacuum.Agent
{
    using System;
    using System.Collections.Generic;
    using Environments;

    public class Agent
    {        
            int? PrevX = null;
            int? PrevY = null;

        public Agent()
        {
            
        }

        public AgentAction DecideAction(Room room)
        {
            int X = room.XAxis;
            int Y = room.YAxis;

            AgentAction lAgent;
            bool isDirty = room.IsDirty;

            if(isDirty)
            {
                lAgent = AgentAction.CLEAN;
            }
            else
            {
                lAgent = FindNextRoom(X, Y, PrevX, PrevY, room);
                PrevX = X;
                PrevY = Y;
            }

            return lAgent;
        }

        private AgentAction FindNextRoom(int x, int y, int? prevX, int? prevY, Room room)
        {
            AgentAction lAgent = AgentAction.NONE;

            //if y is odd then move right
            if(isEven(y))
            {
                if(x == prevX && y == prevY)
                {
                    lAgent = AgentAction.MOVE_DOWN;
                }
                else
                {
                        lAgent = AgentAction.MOVE_RIGHT;
                }
            }
            else
            {
                //if y is even move left
                if(x == prevX && y == prevY)
                {
                    lAgent = AgentAction.MOVE_DOWN;
                }
                else
                {
                    lAgent = AgentAction.MOVE_LEFT;
                }
            }
            //if x == prev x then move down

            return lAgent;
        }

        private bool isEven(int Coordinate)
        {
            bool isEven = false;
            if(Coordinate % 2 == 0)
            {
                isEven = true;
            }
            else
            {
                isEven = false;
            }
            return isEven;
        }
    }
}