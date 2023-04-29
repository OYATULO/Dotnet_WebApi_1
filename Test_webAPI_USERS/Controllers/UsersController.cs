using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System.Web.Http.Results;
using Test_webAPI_USERS.Context;
using Test_webAPI_USERS.Model;
using static Test_webAPI_USERS.Context.AppDBcontext;

namespace Test_webAPI_USERS.Controllers
{
	[Route("api/Users")]
	[ApiController]
	public class UsersController : Controller
	{
		private	 readonly IDataRepository _repository;
		public UsersController(IDataRepository repository)
		{
			_repository = repository;
		}

		#region Получить всех пользователей
			[HttpGet("GetAllUsers")]
			public async Task<List<Users>> GetAllUsers()
			{
				return await _repository.GetAllUsers();
			}
		#endregion

		#region Создать пользователя
			[HttpPost("Create")]
			public async Task<IActionResult> Create(string login = "", string password = "", string username = "", int gender = 0, DateTime birthday = new DateTime())
			{
				Users users1 = new Users
				{
					Guid = Guid.NewGuid(),
					Name = username,
					Login = login,
					Password = password,
					Gender = gender,
					Birthday = birthday,
					Admin = true,
					CreatedOn = DateTime.Now,
					CreatedBy = "admin",
					ModifiedBy = "admin",
					ModifiedOn = DateTime.Now,
					RevokedBy = "admin",
					RevokedOn = DateTime.Now
				};

				bool created = await _repository.Create(users1);
				if (created)
					return Ok("Создано успешно !");
				else
					return BadRequest();
			}
		#endregion

		#region Обновлять
			[HttpPut("Update")]
			public async Task<IActionResult> Update(Guid id, string name, int gender, DateTime? date)
			{
				bool Updated = await _repository.Update(id, name, gender, date);
				if (Updated)
					return Ok("Обновлено успешно");
				return BadRequest();
			}
		#endregion

		#region обновить пароль
			[HttpPut("UpdatePassword")]
			public async Task<IActionResult> UpdatePassword(Guid id, string password)
			{
				bool update = await _repository.UpdatePassword(id, password);
				if (update)
					return Ok("Обновлено успешно");
				else
					return BadRequest();
			}
		#endregion

		#region обновить логин
			[HttpPut("UpdateLogin")]
			public async Task<IActionResult> UpdateLogin(Guid id, string login)
			{
				bool update = await _repository.UpdateLogin(id, login);
				if (update)
					return Ok("Обновлено успешно");
				else
					return BadRequest();
			}
		#endregion

		#region получить пользователя по логину
			[HttpGet("GetUserByLogin")]
			public async Task<IActionResult> GetUsersByLogin(string login)
			{
				try
				{
					var data = await _repository.GetUsersByLogin(login);
					return Ok(data);
				}
				catch (Exception)
				{

					return BadRequest();
				}
			}
		#endregion

		#region получить пользователя по логину и паролю
			[HttpGet("GetUsersByLoginPassword")]
			public async Task<IActionResult> GetUsersByLoginPassword(string login, string password)
			{
				try
				{
					var data = await _repository.GetUsersByLoginPassword(login, password);
					return Ok(data);
				}
				catch (Exception)
				{
					return BadRequest();
				}
			}
		#endregion

		#region Запрос всех пользователей старше определённого возраста
			[HttpGet("GetUsersOldDateAges")]
			public async Task<IActionResult> GetUsersOldDateAges(DateTime? date)
			{
				var data = await _repository.GetUsersOldDateAges(date);

				if (data.Count > 0)
					return Ok(data);
				else
					return BadRequest("Пользователь не найден");
			}
		#endregion

		#region удалить пользователя по логину
			[HttpDelete("DeleteUsersByLogin")]
			public async Task<IActionResult> DeleteUsersByLogin(string login)
			{
				try
				{
					var data = await _repository.DeleteUsersByLogin(login);
					if (data)
						return Ok("Удален успешно!");
					else
						return Ok("Не удалено");
				}
				catch (Exception)
				{
					return BadRequest();
				}
			}
		#endregion
	}
}
