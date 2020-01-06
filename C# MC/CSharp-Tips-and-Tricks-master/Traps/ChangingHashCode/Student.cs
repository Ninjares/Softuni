namespace ChangingHashCode
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode() ^ this.Name.GetHashCode();
        }
    }
}
