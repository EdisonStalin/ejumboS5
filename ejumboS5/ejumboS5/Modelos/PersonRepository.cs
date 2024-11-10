using SQLite;
namespace ejumboS5.Modelos
{
    public class PersonRepository 
	{
		string _dbPath;
		private SQLiteConnection conn;

		public string StatusMessage { get; set; }

		private void Init()
		{
			if (conn is not null)
				return;
			conn = new(_dbPath);
			conn.CreateTable<Persona>();
		}

		public PersonRepository(string dbPath)
		{
			_dbPath = dbPath;
		}

        public void AddNewPerson(string nombre)
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(nombre))
                    throw new Exception("Nombre requerido");
                Persona persona = new() { Name = nombre };
                result = conn.Insert(persona);

                StatusMessage = string.Format("{0} record(s) added (Nombre: {1})", result, nombre);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1})", result, ex.Message);
            }
        }


        public List<Persona> GetAllPeople()
        {
            try
            {
                Init();
                return conn.Table<Persona>().ToList();

            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0})", ex.Message);
            }

            return new List<Persona>();
        }

        public void DeletePerson(int id)
        {
            int result = 0;
            try
            {
                Init();
                // Buscar la persona por ID
                var persona = conn.Find<Persona>(id);
                if (persona == null)
                    throw new Exception("Persona no encontrada");

                // Eliminar la persona
                result = conn.Delete(persona);
                StatusMessage = string.Format("{0} record(s) deleted (ID: {1})", result, id);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to delete. Error: {0}", ex.Message);
            }
        }

        public void UpdatePerson(int id, string nuevoNombre)
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(nuevoNombre))
                    throw new Exception("Nombre requerido");

                // Buscar la persona por ID
                var persona = conn.Find<Persona>(id);
                if (persona == null)
                    throw new Exception("Persona no encontrada");

                // Actualizar el nombre de la persona
                persona.Name = nuevoNombre;
                result = conn.Update(persona);
                StatusMessage = string.Format("{0} record(s) updated (ID: {1}, Nuevo Nombre: {2})", result, id, nuevoNombre);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to update. Error: {0}", ex.Message);
            }
        }

    }
}

