using VKLib.Utils;

namespace VKLib.Enums
{
	/// <summary>
	/// Уровень доступа к содержимому.
	/// </summary>
	public enum WallContentAccess
	{
		/// <summary>
		/// Выключены
		/// </summary>
		[DefaultValue]
		Off = 0,
		/// <summary>
		/// Открытые
		/// </summary>
		Opened,
		/// <summary>
		/// Ограниченные
		/// </summary>
		Restricted,
		/// <summary>
		/// Закрытая
		/// </summary>
		Closed
	}
}