using System;
using System.Collections.Generic;

namespace Tennis
{
    public class Point
    {
        public const string LOVE = "0";
        public const string FIFTEEN = "15";
        public const string THIRTY = "30";
        public const string FORTY = "40";
        public const string GAME = "GAME";
        public const string ADVANTAGE = "ADV";

        private string _score = LOVE;
        private Dictionary<string, Action<Point>> _pointMap;

        public Point()
        {
            BuildPointMap();
        }

        public override string ToString()
        {
            return _score;
        }

        public void Score(Point opponentPoint)
        {
            _pointMap[_score].Invoke(opponentPoint);
        }

        private void BuildPointMap()
        {
            _pointMap = new Dictionary<string, Action<Point>>
            {
                {Point.LOVE, o => { _score = Point.FIFTEEN; }},
                {Point.FIFTEEN, o => { _score = Point.THIRTY; }},
                {Point.THIRTY, o => { _score = Point.FORTY; }},
                {
                    Point.FORTY, o =>
                    {
                        if (o.ToString().Equals(Point.FORTY))
                        {
                            _score = ADVANTAGE;
                        }
                        else
                        {
                            _score = o.ToString().Equals(Point.ADVANTAGE) ? FORTY : GAME;
                        }
                    }
                },
                {Point.ADVANTAGE, o => { _score = GAME; }},
                {Point.GAME, o => { throw new ApplicationException("Game already completed!"); }}
            };
        }
    }
}