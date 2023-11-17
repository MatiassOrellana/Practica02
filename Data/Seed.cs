using Microsoft.Extensions.Options;
using Practica02Backend.Models;
using Practica02Backend.Models.PerfilesAtributos;
using System.Text.Json;

namespace Practica02Backend.Data
{
    /**Clase para procesar datos semilla**/
    public class Seed
    {

        /**Metodo para Acceder al proceso de deseriealizacion los archivos que están en formato JSON**/
        public static void SeedData(DataContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            CallEachSeeder(context, options);

        }
        /**Lee archivo por archivo en formato Json**/
        public static void CallEachSeeder(DataContext context, JsonSerializerOptions options)
        {
            SeedFirstOrderTables(context, options);
            SeedSecondOrderTales(context, options);

        }

        /**Estos métodos se llamaran primero**/
        private static void SeedFirstOrderTables(DataContext context, JsonSerializerOptions options)
        {
            SeedNiveles(context, options);
            SeedPerfiles(context, options);
            context.SaveChanges();
        }

        /**Estos métodos se llamaran Despues**/
        private static void SeedSecondOrderTales(DataContext context, JsonSerializerOptions options)
        {
            SeedFrameworks(context, options);
            SeedPasatiempos(context, options);
            context.SaveChanges();
        }

        private static void SeedNiveles(DataContext context, JsonSerializerOptions options)
        {
            var result = context.Niveles?.Any();
            if (result is true or null) return;//no lo entontro
            var nivelesData = File.ReadAllText("Data/Seeders/Niveles.json");//lee el archivo
            var nivelesLista = JsonSerializer.Deserialize<List<Nivel>>(nivelesData, options);//lo deserializa
            if (nivelesLista == null) return;//en caso que no hayan, pasa nada
            // Eso si siempre habrá una lista
            // El mansaje de advertencia
            if (context.Niveles == null) throw new Exception("No hay Niveles");
            context.Niveles.AddRange(nivelesLista);
            context.SaveChanges();
        }


        private static void SeedPerfiles(DataContext context, JsonSerializerOptions options)
        {
            var result = context.Perfiles?.Any();
            if (result is true or null) return;//no lo entontró
            var perfilesData = File.ReadAllText("Data/Seeders/Perfil.json");//lee el archivo
            var perfilesLista = JsonSerializer.Deserialize<List<Perfil>>(perfilesData, options);//lo deserializa
            if (perfilesLista == null) return;//en caso que no hayan, pasa nada


            if (context.Perfiles == null) throw new Exception("No hay Perfiles");

            context.Perfiles.AddRange(perfilesLista);
            context.SaveChanges();
        }

        private static void SeedFrameworks(DataContext context, JsonSerializerOptions options)
        {
            var result = context.PerfilFrameworks?.Any();
            if (result is true or null) return;//no lo entontró
            var FrameworksData = File.ReadAllText("Data/Seeders/Frameworks.json");//lee el archivo
            var FrameworksLista = JsonSerializer.Deserialize<List<PerfilFrameworks>>(FrameworksData, options);//lo deserializa
            if (FrameworksLista == null) return;//en caso que no hayan, pasa nada


            if (context.PerfilFrameworks == null) throw new Exception("No hay Frameworks");

            context.PerfilFrameworks.AddRange(FrameworksLista);
            context.SaveChanges();
        }

        private static void SeedPasatiempos(DataContext context, JsonSerializerOptions options)
        {
            //si encuentra algun tabla de usuario
            var result = context.Pasatiempos?.Any();
            if (result is true or null) return;//no lo entontró
            var PasatiemposData = File.ReadAllText("Data/Seeders/Pasatiempos.json");//lee el archivo
            var PasatiemposLista = JsonSerializer.Deserialize<List<PerfilPasatiempos>>(PasatiemposData, options);//lo deserializa
            if (PasatiemposLista == null) return;//en caso que no hayan, pasa nada


            if (context.Pasatiempos == null) throw new Exception("No hay Pasatiempos");

            context.Pasatiempos.AddRange(PasatiemposLista);
            context.SaveChanges();
        }

    }
}
