namespace Internship_3_OOP.Models
{
    internal abstract class Entity
    {
        public Guid Id { get; } = Guid.NewGuid();
        public DateTime CreatedAt { get; } = DateTime.Now;

        public DateTime UpdatedAt { get; protected set; } = DateTime.Now;

        protected void Touch()
        {
            UpdatedAt = DateTime.Now;
        }


    }
}
