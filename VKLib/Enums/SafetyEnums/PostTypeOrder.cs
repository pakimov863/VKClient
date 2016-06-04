using System;
using VKLib.Utils;

namespace VKLib.Enums.SafetyEnums
{
	/// <summary>
	/// Способ сортировки приложений
	/// </summary>
	[Serializable]
	public sealed class PostTypeOrder : SafetyEnum<PostTypeOrder>
	{
		/// <summary>
		/// Популярные за день (по умолчанию);
		/// </summary>
		public static readonly PostTypeOrder Post = RegisterPossibleValue("post");

		/// <summary>
		/// По посещаемости
		/// </summary>
		public static readonly PostTypeOrder Copy = RegisterPossibleValue("copy");
	}
}