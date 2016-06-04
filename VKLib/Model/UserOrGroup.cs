using System.Collections.Generic;
using VKLib.Utils;

namespace VKLib.Model
{
	/// <summary>
	/// Расширенная информация о пользователях или сообществах.
	/// </summary>
	public class UserOrGroup
	{
		/// <summary>
		/// Общее количество элементов.
		/// </summary>
		public ulong TotalCount { get;  private set; }

		/// <summary>
		/// Список пользователей.
		/// </summary>
		public List<User> Users { get; set; }

		/// <summary>
		/// Список групп.
		/// </summary>
		public List<Group> Groups { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		/// <exception cref="System.Exception">"Типа '{0}' не существует. Пожалуйста заведите задачу на сайте проекта: https://github.com/VKLib/vk/issues"</exception>
		internal static UserOrGroup FromJson(VkResponse response)
		{
			var userOrGroup = new UserOrGroup
			{
				Users = new List<User>(),
				Groups = new List<Group>()
			};

			if (response.ContainsKey("count"))
			{
				userOrGroup.TotalCount = response["count"];
			}

			VkResponseArray result = response;
			foreach (var item in result)
			{
				switch (item["type"].ToString())
				{
					case "group":
						{
							Group @group = item;
							userOrGroup.Groups.Add(@group);
						}
						break;
					case "profile":
						{
							User user = item;
							userOrGroup.Users.Add(user);
						}
						break;
					default:
						{
							throw new System.Exception(string.Format("Типа '{0}' не существует. Пожалуйста заведите задачу на сайте проекта: https://github.com/VKLib/vk/issues", item["type"]));
						}
				}
			}
			return userOrGroup;
		}
	}
}
