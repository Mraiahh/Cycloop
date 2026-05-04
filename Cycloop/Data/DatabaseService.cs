using Cycloop.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Cycloop.Data
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection _database;

        private async Task Init()
        {
            if (_database is not null)
                return;

            //define o caminho do banco no celular
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "Cycloop.db3");

            _database = new SQLiteAsyncConnection(databasePath);

            // cria a tabela do ciclo, caso ela ainda não exista
            await _database.CreateTableAsync<Ciclo>();
            await _database.CreateTableAsync<Usuario>();
        }

        public async Task<int> SalvarCicloAsync(Ciclo ciclo) //salva ou atualiza um ciclo
        {
            await Init();
            if(ciclo.Id != 0)
            {
                return await _database.UpdateAsync(ciclo);
            }
            else
            {
                return await _database.InsertAsync(ciclo);
            }
        }

        public async Task<List<Ciclo>> GetCiclosAsync() //busca todos os ciclos
        {
            await Init();
            return await _database.Table<Ciclo>().OrderByDescending(x => x.DataInicio).ToListAsync();
        }

        public async Task<int> DeletarCicloAsync(Ciclo ciclo) //deletar um ciclo
        {
            await Init();
            return await _database.DeleteAsync(ciclo);
        }

    }
}
