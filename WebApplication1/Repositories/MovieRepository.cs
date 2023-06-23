using Dapper;
using Microsoft.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAll();
        Task<Movie> GetById(int id);
        Task<int> Add(Movie movie);
        Task<int> Update(Movie movie);  
        Task<int> Delete(int id);   
    }
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(IConfiguration configuration) : base(configuration)
        {

        }
        public override async Task<int> Add(Movie model)
        {
            var sqlCommand = string.Format(@"INSERT INTO [dbo].[Movie]([title],[url],[description],[video])
                                            VALUES (@title,@url,@description,@video)");
            using (var db = new SqlConnection(connectionString))
            {
                return await db.ExecuteAsync(sqlCommand, MappingParameter(model));
            }
        }

        public async override Task<int> Delete(int id)
        {
            var sqlCommand = string.Format(@"DELETE FROM [dbo].[Movie] WHERE [id] = @id");
            using (var db = new SqlConnection(connectionString))
            {
                return await db.ExecuteAsync(sqlCommand, new { id = id });
            }
        }

        public async override Task<int> Update(Movie model)
        {
            var sqlCommand = string.Format(@"UPDATE [dbo].[Movie]
                                               SET [url] = @url 
                                                ,[title] = @title
                                                ,[description] = @description
                                                ,[video] = @video
                                                 WHERE [id] = @id");
            using (var db = new SqlConnection(connectionString))
            {
                return await db.ExecuteAsync(sqlCommand, MappingParameter(model));
            }
        }

        private object MappingParameter(Movie model)
        {
            return new
            {
                Id = model.id,
                Title = model.title,
                Url = model.url,
                Description = model.description,
                Video = model.video,
            };
        }
    }
}
