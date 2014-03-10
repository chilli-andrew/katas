namespace Tennis
{
    public class Game
    {
        private readonly Point _servicePoint = new Point();
        private readonly Point _receiverPoint = new Point();

        public string Score
        {
            get
            {
                if (_servicePoint.ToString().Equals(Point.FORTY) && (_receiverPoint.ToString().Equals(Point.FORTY)))
                {
                    return "DEUCE";
                }
                return string.Format("{0}-{1}", _servicePoint, _receiverPoint);
            }
        }

        public void ScoreToService()
        {
            _servicePoint.Score(_receiverPoint);
        }

        public void ScoreToReceiver()
        {
            _receiverPoint.Score(_servicePoint);
        }
    }
}