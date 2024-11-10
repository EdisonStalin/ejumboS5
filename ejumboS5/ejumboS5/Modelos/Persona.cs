using SQLite;
namespace ejumboS5.Modelos
{
    [Table("Persona")]
    public class Persona
	{

        [PrimaryKey, AutoIncrement]

		public int Id { get; set; }

		[MaxLength(25), Unique]

		public string Name { get; set; }

    }

    
}

