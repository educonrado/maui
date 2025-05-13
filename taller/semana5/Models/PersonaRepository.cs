using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace econradoS5B.Models
{
    public class PersonaRepository
    {

        string dbPath;
        private SQLiteConnection conn;
        public string Message {  get; set; }

        private void Init()
        {
            if (conn is not null)
            {
                return;
            }

            conn = new(dbPath);
            conn.CreateTable<Persona>();
        }

        public PersonaRepository(string path)
        {
            dbPath = path;
            Init();
        }

        public void AddNewPersona(string name)
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(name))
                {
                    throw new Exception("El nombre es requerido.");
                }
                Persona persona = new () { Name = name };
                
                result = conn.Insert(persona);

                Message = string.Format($"Dato ingresado {0}", result, name);
            }
            catch (Exception ex)
            {

                Message = string.Format($"Error {0}", ex);
            }
        }

        public List<Persona> GetAllPersonas()
        {
            try
            {
                Init();
                return conn.Table<Persona>().ToList();
            }
            catch (Exception ex)
            {

                Message = string.Format("Error {0}", ex);
            }
            return new List<Persona>();
        }

        public void EliminarPersonaById(int personaId)
        {
            try
            {
                Init();
                conn.Delete<Persona>(personaId);

            }
            catch (Exception ex)
            {

                Message = string.Format("Error al eliminar persona: {0}", personaId);
            }
        }

        internal void EditarPersona(Persona persona)
        {
            try
            {
                Init();
                conn.Update(persona);
                Message = $"Persona con id {persona.Id} actualizada.";
            }
            catch (Exception ex)
            {
                Message = $"Error al editar persona con Id {persona?.Id}: {ex.Message}";
            }
        }
    }
}
