namespace Hakkers.Enums
{
    public class Assignment
    {
        public enum Type
        {
            Gas = 1,
            Water = 2,
            Electricity = 3,
        }

        public enum Priority
        {
            Maintenance = 1,
            Malfunction = 2,
            Critical = 3,
        }

        public enum Status
        {
            Inactive = 1,
            Left = 2,
            Arived = 3,
            Started = 4,
            OnHold = 5,
            Finished = 6,
        }
    }
}