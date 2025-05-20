using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;
using System.Threading.Tasks;

namespace Repository
{
    public static class Repository<T> where T : class, new()
    {
        private static readonly JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
        public static void Agregar(string archivo, T entidad)
        {
            var datos = Cargar(archivo); datos.Add(entidad); Guardar(archivo, datos);
        }
        public static List<T> ObtenerTodos(string archivo) => Cargar(archivo); public static void Eliminar(string archivo, Predicate<T> predicado)
        {
            var datos = Cargar(archivo); datos.RemoveAll(predicado); Guardar(archivo, datos);
        }
        public static void Actualizar(string archivo, Predicate<T> predicado, T nuevaEntidad)
        {
            var datos = Cargar(archivo); int index = datos.FindIndex(predicado); if (index != -1)
            {
                datos[index] = nuevaEntidad; Guardar(archivo, datos);
            }
        }
        private static void Guardar(string archivo, List<T> datos)
        {
            File.WriteAllText($"Repository/Data/{archivo}.json",
            JsonSerializer.Serialize(datos, options));
        }
        private static List<T> Cargar(string archivo)
        {
            string path = $"Repository/Data/{archivo}.json"; if (!File.Exists(path)) return new List<T>(); return
            JsonSerializer.Deserialize<List<T>>(File.ReadAllText(path), options) ?? new List<T>();
        }
        public static void GuardarLista(string archivo, List<T> datos)
        {
            try
            {
                string json = JsonSerializer.Serialize(datos, options);
                File.WriteAllText($"{archivo}.json", json);
            }
            catch (IOException ex)
            {
                Console.Error.WriteLine($"[ERROR] No se pudo guardar el archivo {archivo}.json: {ex.Message}");


            }
        }
    }
}