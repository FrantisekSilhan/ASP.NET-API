namespace apitest.Data.Models {
    public class Student {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public required Classroom Classroom { get; set; }
        public int ClassroomId { get; set; }
    }
}
