using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RegistrationForm.Data;
using RegistrationForm.Domain;

namespace RegistrationForm.Services
{
    public class FormDataRepository : IFormDataRepository
    {
        #region Field

        private readonly FormdbContext _context;

        #endregion

        #region Ctor
        public FormDataRepository(FormdbContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Retrieves all form data entries from the database.
        /// </summary>
        /// <returns>The collection of form data entries.</returns>
        public IEnumerable<FormData> GetAll()
        {
            return _context.FormDatas.FromSqlRaw("EXEC GetData").ToList();
        }

        /// <summary>
        /// Retrieves a specific form data entry by its identifier from the database.
        /// </summary>
        /// <param name="id">The identifier of the form data entry.</param>
        /// <returns>The form data entry with the specified identifier, or null if not found.</returns>
        public FormData GetById(int id)
        {
            return _context.FormDatas.FromSqlRaw("EXEC GetDataById @Id", new SqlParameter("@Id", id)).AsEnumerable().FirstOrDefault();
        }

        /// <summary>
        /// Adds a new form data entry to the database.
        /// </summary>
        /// <param name="formData">The form data entry to add.</param>
        public void Add(FormData formData)
        {
            SqlParameter addressParam = formData.Address != null ?
         new SqlParameter("@Address", formData.Address) :
         new SqlParameter("@Address", DBNull.Value);

            _context.Database.ExecuteSqlRaw("EXEC InsertData @Name, @Email, @Phone, @Address, @State, @City",
                new SqlParameter("@Name", formData.Name),
                new SqlParameter("@Email", formData.Email),
                new SqlParameter("@Phone", formData.Phone),
                addressParam,
                new SqlParameter("@State", formData.State),
                new SqlParameter("@City", formData.City));
            _context.SaveChanges(); // Save changes to the database
           
        }

        /// <summary>
        /// Updates an existing form data entry in the database.
        /// </summary>
        /// <param name="formData">The updated form data entry.</param>
        public void Update(FormData formData)
        {
            SqlParameter addressParam = formData.Address != null ?
         new SqlParameter("@Address", formData.Address) :
         new SqlParameter("@Address", DBNull.Value);

            _context.Database.ExecuteSqlRaw("EXEC UpdateData @Id, @Name, @Email, @Phone, @Address, @State, @City",
                new SqlParameter("@Id", formData.Id),
                new SqlParameter("@Name", formData.Name),
                new SqlParameter("@Email", formData.Email),
                new SqlParameter("@Phone", formData.Phone),
                addressParam,
                new SqlParameter("@State", formData.State),
                new SqlParameter("@City", formData.City));
            _context.SaveChanges(); // Save changes to the database
        }

        /// <summary>
        /// Deletes a form data entry from the database.
        /// </summary>
        /// <param name="id">The identifier of the form data entry to delete.</param>
        public void Delete(int id)
        {
            _context.Database.ExecuteSqlRaw("EXEC DeleteData @Id", new SqlParameter("@Id", id));
            _context.SaveChanges(); // Save changes to the database
        }

        #endregion
    }
}
