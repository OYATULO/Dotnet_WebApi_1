using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Test_webAPI_USERS.Model
{
	public class Users
	{
		[Key]
        public Guid Guid { get; set; } //Уникальный идентификатор пользователя
									   //[DisplayName("Логин")]
		[Required]
		public string Login { get; set; } = string.Empty; // Уникальный Логин (запрещены все символы кроме латинских букв и цифр),
														  //[DisplayName("Пароль")]
		[Required]
		public string Password { get; set; } = string.Empty; //- Пароль(запрещены все символы кроме латинских букв и цифр),
															 //[DisplayName("Имя")]
		[Required]
		public string Name { get; set; } = string.Empty; //- Имя (запрещены все символы кроме латинских и русских букв)
		//[DisplayName("Пол")]
		public int Gender { get; set; } //- Пол 0 - женщина, 1 - мужчина, 2 - неизвестно
		//[DisplayName("даты рождения")]
		public DateTime? Birthday { get; set; } // поле даты рождения может быть Null
		public bool Admin { get; set; } //Указание - является ли пользователь админом
		public DateTime CreatedOn { get; set; } //Дата создания пользователя
		public string CreatedBy { get; set; } = string.Empty; //Логин Пользователя, от имени которого этот пользователь создан
		public DateTime ModifiedOn { get; set; } //Дата изменения пользователя
		public string ModifiedBy { get; set; } = string.Empty; //Логин Пользователя, от имени которого этот пользователь изменён
		
		public DateTime RevokedOn { get; set; } //Дата удаления пользователя
		public string RevokedBy { get; set; } = string.Empty; // - Логин Пользователя, от имени которого этот пользователь удалён
	}

}
