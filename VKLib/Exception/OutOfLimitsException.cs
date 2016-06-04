using System;

namespace VKLib.Exception
{
	/// <summary>
	/// 103 - Выход за пределы
	/// </summary>
	/// <seealso cref="VKLib.Exception.VkApiException" />
	[Serializable]
    public class OutOfLimitsException : VkApiException
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="message">Описание исключения.</param>
        public OutOfLimitsException(string message) : base(message)
        {
        }
    }
}