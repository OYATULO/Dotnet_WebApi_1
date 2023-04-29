using Test_webAPI_USERS.Model;

namespace Test_webAPI_USERS.Context
{
	public interface IDataRepository
	{
		//Create -> POST
		Task<bool> Create(Users user);
		//UPDATE 1 -> PUT
		Task<bool> Update(Guid id , string name , int gender, DateTime? date );
		Task<bool> UpdatePassword(Guid id , string password );
		Task<bool> UpdateLogin(Guid id , string login );

		//Read -> GET
		// 5) Запрос списка всех активных (отсутствует RevokedOn) пользователей, список отсортирован по  CreatedOn(Доступно Админам)
		Task<List<Users>> GetAllUsers();
		// 6)  Запрос пользователя по логину, в списке долны быть имя, пол и дата рождения статус активный или нет(Доступно Админам)
		Task<Users> GetUsersByLogin(string login);
		//7) Запрос пользователя по логину и паролю (Доступно только самому пользователю, если он активен(отсутствует RevokedOn))
		Task<Users> GetUsersByLoginPassword(string login , string password);
		//8) Запрос всех пользователей старше определённого возраста (Доступно Админам
		Task<List<Users>> GetUsersOldDateAges(DateTime? date);

		//Delete -> Delete 
		//9) Удаление пользователя по логину полное или мягкое (При мягком удалении должна 
		//происходить простановка RevokedOn и RevokedBy) (Доступно Админам)
		Task<bool> DeleteUsersByLogin(string login);

		//Update 2 -> PUT
		// 10) Восстановление пользователя - Очистка полей (RevokedOn, RevokedBy) (Доступно Админам)

	}
}
