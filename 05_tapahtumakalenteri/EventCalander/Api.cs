//using Microsoft.Data.SqlClient;

//namespace EventCalander
//{
//    public class Api
//    {
//        /// <summary>
//        /// add event to database
//        /// </summary>
//        public void AddEvent(Event @event)
//        {
//            // create connection
//            using var connection = new SqlConnection("Server=localhost;Database=EventCalander;Trusted_Connection=True;");
//            connection.Open();

//            // create command
//            using var command = connection.CreateCommand();
//            command.CommandText = "INSERT INTO Events (Title, Description, StartDate, EndDate, Location, CategoryId, CreatedBy) VALUES (@Title, @Description, @StartDate, @EndDate, @Location, @CategoryId, @CreatedBy)";
//            command.Parameters.AddWithValue("@Title", @event.Title);
//            command.Parameters.AddWithValue("@Description", @event.Description);
//            command.Parameters.AddWithValue("@StartDate", @event.StartDate);
//            command.Parameters.AddWithValue("@EndDate", @event.EndDate);
//            command.Parameters.AddWithValue("@Location", @event.Location);
//            command.Parameters.AddWithValue("@CategoryId", @event.CategoryId);
//            command.Parameters.AddWithValue("@CreatedBy", @event.CreatedBy);

//            // execute command
//            command.ExecuteNonQuery();
//            connection.Close();
//        }
//    }
//}

using Microsoft.EntityFrameworkCore;

namespace EventCalander
{
    public class Api
    {
        private readonly ApplicationDbContext _context;

        public Api(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddEvent(Event @event)
        {
            // Add the event to the database context
            _context.Events.Add(@event);

            // Save the changes to the database
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
    }
}

