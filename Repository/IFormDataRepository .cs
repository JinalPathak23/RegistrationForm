using RegistrationForm.Domain;

namespace RegistrationForm.Services
{
    public interface IFormDataRepository
    {

        IEnumerable<FormData> GetAll();

        /// <summary>
        /// Retrieves a specific form data entry by its identifier from the database.
        /// </summary>
        /// <param name="id">The identifier of the form data entry.</param>
        /// <returns>The form data entry with the specified identifier, or null if not found.</returns>
        FormData GetById(int id);

        /// <summary>
        /// Adds a new form data entry to the database.
        /// </summary>
        /// <param name="formData">The form data entry to add.</param>
        void Add(FormData formData);

        /// <summary>
        /// Updates an existing form data entry in the database.
        /// </summary>
        /// <param name="formData">The updated form data entry.</param>
        void Update(FormData formData);

        /// <summary>
        /// Deletes a form data entry from the database.
        /// </summary>
        /// <param name="id">The identifier of the form data entry to delete.</param>
        void Delete(int id);
    }
}
