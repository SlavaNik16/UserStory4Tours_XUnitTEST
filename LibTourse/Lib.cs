using UserStory4Tours.models;
namespace LibTourse
{
    public class Lib
    {
        public List<DateTime> tours = new List<DateTime>();

        #region ButtonTest
        public List<DateTime> GetList()
        {
          
            return tours;
        }
        public DateTime Add(DateTime time)
        {
            tours.Add(time);
            return time;
        }
        #endregion

        #region DirectionCount
        public int FillDirection()
        {
            var count = 0;
            foreach (Direction dir in Enum.GetValues(typeof(Direction)))
            {
                count++;
            }
            return count;
        }
        #endregion

        #region Sum
        public int Sum(int NumberNight, int NumberVac, int CostVac, int Surcharges)
        {
            var sum = (NumberNight* NumberVac* CostVac)+Surcharges;
            return sum;
        }
        #endregion
    }
}