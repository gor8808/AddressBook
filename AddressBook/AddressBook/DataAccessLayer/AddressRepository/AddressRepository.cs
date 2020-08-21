using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.Models;

namespace AddressBook.DataAccessLayer.AddressRepository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DataStorageConfiguration _dataStorageConfiguration;

        public AddressRepository(DataStorageConfiguration dataStorageConfiguration)
        {
            _dataStorageConfiguration = dataStorageConfiguration;
        }
        public async Task<List<AddressItem>> GetAllItems()
        {
            await using var connection = new SqlConnection(
                _dataStorageConfiguration.ConnectionString);
            await using var cmd = new SqlCommand(nameof(GetAllItems), connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            await connection.OpenAsync();

            var reader = await cmd.ExecuteReaderAsync();
            if (!reader.HasRows)
            {
                await connection.CloseAsync();
                return null;
            }

            var addresses = new List<AddressItem>();
            while (await reader.ReadAsync())
            {
                addresses.Add(
                    new AddressItem
                    {
                        Id = Convert.ToInt32(reader[0]),
                        FullName = reader[1].ToString(),
                        Email = reader[2].ToString(),
                        PhoneNumber = reader[3].ToString(),
                        PhysicalAddress = reader[4].ToString()
                    }
                    );
            }
            await connection.CloseAsync();

            return addresses;

        }

        public async Task<AddressItem> GetItemById(int id)
        {
            await using var connection = new SqlConnection(
                _dataStorageConfiguration.ConnectionString);
            await using var cmd = new SqlCommand(nameof(GetItemById), connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue(nameof(id), id);

            await connection.OpenAsync();

            var reader = await cmd.ExecuteReaderAsync();
            if (!reader.HasRows)
            {
                await connection.CloseAsync();
                return null;
            }

            await reader.ReadAsync();

            var address = new AddressItem
            {
                Id = Convert.ToInt32(reader[0]),
                FullName = reader[1].ToString(),
                Email = reader[2].ToString(),
                PhoneNumber = reader[3].ToString(),
                PhysicalAddress = reader[4].ToString()
            };

            await connection.CloseAsync();

            return address;
        }

        public async Task AddNewItem(AddressItem addressItem)
        {
            await using var connection = new SqlConnection(
                _dataStorageConfiguration.ConnectionString);
            await using var cmd = new SqlCommand(nameof(AddNewItem), connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue(nameof(addressItem.FullName), addressItem.FullName);
            cmd.Parameters.AddWithValue(nameof(addressItem.Email), addressItem.Email);
            cmd.Parameters.AddWithValue(nameof(addressItem.PhoneNumber), addressItem.PhoneNumber);
            cmd.Parameters.AddWithValue(nameof(addressItem.PhysicalAddress), addressItem.PhysicalAddress);

            await connection.OpenAsync();

            await cmd.ExecuteNonQueryAsync();

            await connection.CloseAsync();
        }

        public async Task EditItem(AddressItem addressItem)
        {
            await using var connection = new SqlConnection(
                _dataStorageConfiguration.ConnectionString);
            await using var cmd = new SqlCommand(nameof(EditItem), connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue(nameof(addressItem.Id), addressItem.Id);
            cmd.Parameters.AddWithValue(nameof(addressItem.FullName), addressItem.FullName);
            cmd.Parameters.AddWithValue(nameof(addressItem.Email), addressItem.Email);
            cmd.Parameters.AddWithValue(nameof(addressItem.PhoneNumber), addressItem.PhoneNumber);
            cmd.Parameters.AddWithValue(nameof(addressItem.PhysicalAddress), addressItem.PhysicalAddress);

            await connection.OpenAsync();

            await cmd.ExecuteNonQueryAsync();

            await connection.CloseAsync();
        }

        public async Task DeleteItem(int id)
        {
            await using var connection = new SqlConnection(
                _dataStorageConfiguration.ConnectionString);
            await using var cmd = new SqlCommand(nameof(DeleteItem), connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue(nameof(id), id);

            await connection.OpenAsync();

            await cmd.ExecuteNonQueryAsync();

            await connection.CloseAsync();
        }

        public async Task<List<AddressItem>> SearchItem(SearchModel model)
        {
            if (model.Id != 0)
            {
                return new List<AddressItem>
                {
                    await GetItemById(model.Id)
                };
            }

            await using var connection = new SqlConnection(
                _dataStorageConfiguration.ConnectionString);
            await using var cmd = new SqlCommand(nameof(SearchItem), connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            model.FullName ??= string.Empty;
            model.Email ??= string.Empty;
            model.PhoneNumber ??= string.Empty;
            model.PhysicalAddress ??= string.Empty;

            cmd.Parameters.AddWithValue(nameof(model.FullName), model.FullName);
            cmd.Parameters.AddWithValue(nameof(model.Email), model.Email);
            cmd.Parameters.AddWithValue(nameof(model.PhoneNumber), model.PhoneNumber);
            cmd.Parameters.AddWithValue(nameof(model.PhysicalAddress), model.PhysicalAddress);


            await connection.OpenAsync();

            var reader = await cmd.ExecuteReaderAsync();

            if (!reader.HasRows)
            {
                await connection.CloseAsync();
                return null;
            }

            var addresses = new List<AddressItem>();

            while (await reader.ReadAsync())
            {
                addresses.Add(
                    new AddressItem
                    {
                        Id = Convert.ToInt32(reader[0]),
                        FullName = reader[1].ToString(),
                        Email = reader[2].ToString(),
                        PhoneNumber = reader[3].ToString(),
                        PhysicalAddress = reader[4].ToString()
                    }
                );
            }
            await connection.CloseAsync();

            return addresses;
        }
    }
}
