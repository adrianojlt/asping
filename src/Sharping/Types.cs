namespace Sharping
{
    public class Types
    {
        public Nullable<int> Count { get; set; } = new Nullable<int>();

        // nullable type. its the same as above
        public int? Size { get; set; } = new int?();

        public bool CountHasValues => Count.HasValue;

        public bool SizeHasValues => Size.HasValue;
    }
}
