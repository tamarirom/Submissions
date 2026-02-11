namespace lesson_04.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public Status myStatus { get; set; }
        public enum Status
        {
            ToDo,
            InAction,
            Completed
        }
    }
}
