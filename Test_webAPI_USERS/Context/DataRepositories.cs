using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Test_webAPI_USERS.Model;

namespace Test_webAPI_USERS.Context
{
	public  class DataRepositories : IDataRepository
	{

		AppDBcontext _appDBcontext;

		public DataRepositories(AppDBcontext appDBcontext)
		{
			_appDBcontext = appDBcontext;
		}
		public  async Task<bool> Create(Users user)
		{
			try
			{
				await	_appDBcontext.AddAsync(user);
				return _appDBcontext.SaveChanges() >= 1;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public async Task<bool> Update(Guid id, string name, int gender, DateTime? date)
		{
			try
			{
				var res= await _appDBcontext.UserDB.SingleOrDefaultAsync(x=>x.Guid.Equals(id));
				if (res != null) { 
					res.Name = name;
					res.Gender = gender;
					res.Birthday = date;
					return	await _appDBcontext.SaveChangesAsync()>=1;
				}
				else
					return false;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public async Task<bool> UpdateLogin(Guid id, string login)
		{
			try
			{
				 var res = await _appDBcontext.UserDB.SingleOrDefaultAsync(x=>x.Guid.Equals(id)); 
				if (res != null)
				{
					res.Login = login;
					return	await _appDBcontext.SaveChangesAsync()>=1;
				}
				else
					return false;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public async Task<bool> UpdatePassword(Guid id, string password)
		{
			try
			{
				var res = await _appDBcontext.UserDB.SingleOrDefaultAsync(x=>x.Guid.Equals(id));
				if (res != null)
				{
					res.Password = password;
				  return	await _appDBcontext.SaveChangesAsync() >= 1;
				}
				else return false;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public async Task<List<Users>> GetAllUsers()
		{
			return await _appDBcontext.UserDB.ToListAsync();
		}

		public  async Task<Users> GetUsersByLogin(string login)
		{
			return await _appDBcontext.UserDB.FirstAsync(x=>x.Login.Equals(login));
		}

		public async Task<Users> GetUsersByLoginPassword(string login, string password)
		{
			return await _appDBcontext.UserDB.FirstAsync(x=>x.Login.Equals(login) && x.Password.Equals(password));
		}

		public async Task<List<Users>> GetUsersOldDateAges(DateTime? date)
		{
			return await _appDBcontext.UserDB.Where(x=>x.Birthday>date).ToListAsync();
		}

		public async Task<bool> DeleteUsersByLogin(string login)
		{
			try
			{
				var res= await _appDBcontext.UserDB.FirstAsync(x=>x.Login.Equals(login));
				if (res != null)
				{
								 _appDBcontext.UserDB.Remove(res);
					return await _appDBcontext.SaveChangesAsync() >= 1;
				}
				else
					return false;
			}
			catch (Exception)
			{
				return false;
			}
		}

		
	}
}
