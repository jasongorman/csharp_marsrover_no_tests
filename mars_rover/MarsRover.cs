using System;
using System.Collections.Generic;

namespace mars_rover
{
    public class MarsRover
    {
        private readonly List<string> _compass = new List<string>{ "N", "E", "S", "W" };

        private readonly Dictionary<string, int[]> _vectors = new Dictionary<string, int[]>
        {
            {"N", new[]{0, 1}},
            {"S", new[]{0, -1}},
            {"E", new[]{0, 1}},
            {"W", new[]{-1, 0}}
        };
        
        private string _direction;
        private int _x;
        private int _y;

        public MarsRover(string direction, int x, int y)
        {
            _direction = direction;
            _x = x;
            _y = y;
        }

        public string Direction => _direction;

        public int X => _x;

        public int Y => _y;

        public void Go(string instructions)
        {
            Dictionary<char, Action> actions = new Dictionary<char, Action>
            {
                { 'L', Left },
                { 'R', Right },
                { 'F', Forward },
                { 'B', Backward }
            };
            
            foreach (var instruction in instructions.ToCharArray())
            {
                actions[instruction].Invoke();
            }
            
        }

        private void Left()
        {
            int currentDirection = _compass.IndexOf(Direction);
            _direction = _compass[(currentDirection - 1) % 4];
        }

        private void Right()
        {
            int currentDirection = _compass.IndexOf(Direction);
            _direction = _compass[(currentDirection + 1) % 4];
        }

        private void Forward()
        {
            int[] vector = _vectors[Direction];
            _x = X + vector[0];
            _y = Y + vector[1];
        }
        
        private void Backward()
        {
            int[] vector = _vectors[Direction];
            _x = X - vector[0];
            _y = Y - vector[1];
        }
        
    }
}